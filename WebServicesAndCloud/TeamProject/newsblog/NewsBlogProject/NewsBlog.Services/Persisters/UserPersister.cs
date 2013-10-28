using NewsBlog.Model;
using NewsBlog.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace NewsBlog.Services.Persisters
{
    public class UserPersister
    {
        private static readonly string sessionKeyChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int SessionKeyLength = 40;

        private static NewsBlogEntities context = new NewsBlogEntities();
        private static UserRepository repository = new UserRepository(context);
        private static Random rand = new Random();

        public static bool ValidateSessionKey(string sessionKey)
        {
            bool isSessionKeyValid = repository.IsValidSessionKey(sessionKey);
            return isSessionKeyValid;
        }

        public static string CreateSessionKeyByUserId(int userId)
        {
            string sessionKey = GenerateSessionKey(userId);
            repository.SaveSessionKey(sessionKey,userId);
            return sessionKey;
        }

        private static string GenerateSessionKey(int userId)
        {
            StringBuilder keyChars = new StringBuilder(SessionKeyLength);
            keyChars.Append(userId.ToString());
            while (keyChars.Length < SessionKeyLength)
            {
                int randomCharNum;
                lock (rand)
                {
                    randomCharNum = rand.Next(sessionKeyChars.Length);
                }

                char randomKeyChar = sessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }

            string sessionKey = keyChars.ToString();
            return sessionKey;
        }

        public static User GetUser(string username)
        {
            return context.Users.Where(x => x.Username == username).FirstOrDefault();
        }
    }
}