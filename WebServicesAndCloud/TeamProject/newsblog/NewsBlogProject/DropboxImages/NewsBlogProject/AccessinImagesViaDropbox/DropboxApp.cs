using System;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.IO;

namespace AccessinImagesViaDropbox
{
    public class DropboxApp
    {
        private const string DropboxAppKey = "gonnlp6yz3op59r";
        private const string DropboxAppSecret = "hxyxzx97ad7s0ay";

        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";
                
        public static void ReturnUrlWhenDownloadingImageFromIN(string image, int id)
        {
            IDropbox dropbox = CreatingFile();

            HttpClient client = new HttpClient();

            byte[] imageAsByteArr = client.GetByteArrayAsync(image).Result;

            // Create new folder
            string newFolderName = "ArticleImages" + id;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            var imageDir = image.Substring(image.LastIndexOf("/") + 1);

            // Upload a file
            Entry uploadFileEntry = dropbox.UploadFileAsync(
                new ByteArrayResource(imageAsByteArr), "/" + imageDir).Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            // Get file Url
            DropboxLink imageUrl = dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;
            Process.Start(imageUrl.Url);
           
        }

        public static void ReturnUrlWhenBrowsingImageFromPC(string image, int id)
        {
            IDropbox dropbox = CreatingFile();

            // Create new folder
            string newFolderName = "ArticleImages" + id;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            var imageDir = image.Substring(image.LastIndexOf("\\") + 1);

            // Upload a file
            Entry uploadFileEntry = dropbox.UploadFileAsync(
            new FileResource(image),
            "/" + newFolderName + "/" + imageDir).Result;
            Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            // Get file Url
            DropboxLink imageUrl = dropbox.GetMediaLinkAsync(uploadFileEntry.Path).Result;
            Process.Start(imageUrl.Url);
            Console.WriteLine(imageUrl.Url);
        }
  
        private static IDropbox CreatingFile()
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);
           
            return dropbox;
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }

    }
}
