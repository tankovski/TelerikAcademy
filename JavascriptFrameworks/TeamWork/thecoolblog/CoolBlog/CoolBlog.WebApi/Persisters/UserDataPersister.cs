namespace CoolBlog.WebApi.Persisters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CoolBlog.Model;
    using CoolBlog.WebApi.Models;

    public class UserDataPersister : BaseDataPersister
    {
        private const string SessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const int SessionKeyLen = 50;
        private const int Sha1CodeLength = 40;
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private const string ValidNicknameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";
        private const int MinUsernameNicknameChars = 4;
        private const int MaxUsernameNicknameChars = 30;

        private static void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey.Length != SessionKeyLen || sessionKey.Any(ch => !SessionKeyChars.Contains(ch)))
            {
                throw new ServerErrorException("Invalid Password", "ERR_INV_AUTH");
            }
        }

        private static string GenerateSessionKey(int userId)
        {
            StringBuilder keyChars = new StringBuilder(50);
            keyChars.Append(userId.ToString());
            while (keyChars.Length < SessionKeyLen)
            {
                int randomCharNum;
                lock (rand)
                {
                    randomCharNum = rand.Next(SessionKeyChars.Length);
                }
                char randomKeyChar = SessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }
            string sessionKey = keyChars.ToString();
            return sessionKey;
        }

        private static void ValidateUsername(string username)
        {
            if (username == null || username.Length < MinUsernameNicknameChars || username.Length > MaxUsernameNicknameChars)
            {
                throw new ServerErrorException(string.Format("Username should be between {0} and {1} symbols long", MinUsernameNicknameChars, MaxUsernameNicknameChars), "INV_USR_LEN");
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ServerErrorException("Username contains invalid characters", "INV_USR_CHARS");
            }
        }

        private static void ValidateNickname(string nickname)
        {
            if (nickname == null || nickname.Length < MinUsernameNicknameChars || nickname.Length > MaxUsernameNicknameChars)
            {
                throw new ServerErrorException(string.Format("Nickname should be between {0} and {1} symbols long", MinUsernameNicknameChars, MaxUsernameNicknameChars), "INV_NICK_LEN");
            }
            else if (nickname.Any(ch => !ValidNicknameChars.Contains(ch)))
            {
                throw new ServerErrorException("Nickname contains invalid characters", "INV_NICK_CHARS");
            }
        }

        private static void ValidateAuthKey(string authCode)
        {
            if (authCode.Length != Sha1CodeLength)
            {
                throw new ServerErrorException("Invalid user authentication", "INV_USR_AUTH");
            }
        }


        public static void CreateUser(UserRegisterModel user)
        {
            ValidateUsername(user.Username);
            ValidateNickname(user.Nickname);
            ValidateAuthKey(user.AuthKey);
            using (CoolBlogEntity context = new CoolBlogEntity())
            {
                var usernameToLower = user.Username.ToLower();
                var nicknameToLower = user.Nickname.ToLower();
                var dbUser = context.Users.FirstOrDefault(u => u.Username == usernameToLower || u.Nickname.ToLower() == nicknameToLower);

                if (dbUser != null)
                {
                    if (dbUser.Username.ToLower() == usernameToLower)
                    {
                        throw new ServerErrorException("Username already exists", "ERR_DUP_USR");
                    }
                    else
                    {
                        throw new ServerErrorException("Nickname already exists", "ERR_DUP_NICK");
                    }
                }

                dbUser = new User()
                {
                    Username = usernameToLower,
                    Nickname = user.Nickname,
                    AuthKey = user.AuthKey,
                    Gender = user.Gender,
                    Email = user.Email,
                    RankId = user.RankId
                };

                context.Users.Add(dbUser);
                context.SaveChanges();
            }
        }

        public static string LoginUser(UserLoginModel usr, out string nickname, out int id,out string rank)
        {
            ValidateUsername(usr.Username);
            ValidateAuthKey(usr.AuthKey);
            var context = new CoolBlogEntity();
            using (context)
            {
                var usernameToLower = usr.Username.ToLower();
                var user = context.Users.FirstOrDefault(u => u.Username == usernameToLower && u.AuthKey== usr.AuthKey);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid username or password", "ERR_INV_USR");
                }

                var sessionKey = GenerateSessionKey(user.Id);
                user.SessionKey = sessionKey;
                nickname = user.Nickname;
                id = user.Id;
                rank = user.Rank.Name;
                context.SaveChanges();

                return sessionKey;
            }
        }

        public static int LoginUser(string sessionKey)
        {
            ValidateSessionKey(sessionKey);
            var context = new CoolBlogEntity();
            using (context)
            {
                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid user authentication", "INV_USR_AUTH");
                }

                user.SessionKey = sessionKey;
                context.SaveChanges();
                return user.Id;
            }
        }

        public static void LogoutUser(string sessionKey)
        {
            ValidateSessionKey(sessionKey);
            var context = new CoolBlogEntity();
            using (context)
            {
                var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid user authentication", "INV_USR_AUTH");
                }

                user.SessionKey = null;
                context.SaveChanges();
            }
        }

        public static IEnumerable<UserMinimalModel> GetAllUsers()
        {
            var context = new CoolBlogEntity();
            using (context)
            {
                var users =
                    (from user in context.Users
                     select new UserMinimalModel()
                     {
                         Id = user.Id,
                         Nickname = user.Nickname,
                     });

                return users.ToList();
            }
        }

        public static UserExtendedModel GetUser(int id)
        {
            var context = new CoolBlogEntity();

            var user = context.Users.FirstOrDefault(u => u.Id == id);

            UserExtendedModel extUser = new UserExtendedModel()
            {
                Nickname = user.Nickname,
                Gender = user.Gender,
                Email = user.Email,
                IsBanned = user.IsBanned,
                Rank = user.Rank.Name
            };

            return extUser;
        }
    }
}