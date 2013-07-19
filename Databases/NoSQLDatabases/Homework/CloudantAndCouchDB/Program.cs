using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Divan;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace CloudantAndCouchDB
{
    class Program
    {
        static void CreateWord(string word, string translation, ICouchDatabase database)
        {
            if (database.GetDocument(word) == null)
            {
                database.CreateDocument("{\"_id\": \"" + word + "\", \"word\": \"" + word + "\", \"translation\": \"" + translation + "\"}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Word added");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The word already exist");
                Console.ResetColor();
            }

        }

        static void GetWordTranslation(string word, ICouchDatabase database)
        {
            try
            {
                JObject ourWord = JObject.Parse(database.GetDocument(word).ToString());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} - {1}", word, (string)ourWord["translation"]);
                Console.ResetColor();

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This word don't exist in the dictionary");
                Console.ResetColor();
            }
        }

        static void ListAllLords(ICouchDatabase database)
        {
            try
            {
                var allWords = database.GetAllDocuments();
                foreach (var item in allWords)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(item.Obj["word"] + " - " + item.Obj["translation"]);
                    Console.ResetColor();
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The dictionary is empty");
                Console.ResetColor();
            }
        }

        static void Main()
        {
            //This is real username and password and must work with them
            CouchServer server = new CouchServer("testuser.cloudant.com", 5984, "testuser", "testpassword");
            ICouchDatabase database = server.GetDatabase("dictionary");
            bool isWorking = true;

            ICouchDocument doc = database.GetDocument("game");


            while (isWorking)
            {

                Console.WriteLine("For add new word press : 1");
                Console.WriteLine("For finding a translation for given word press 2");
                Console.WriteLine("For list all words and their translations press 3");
                Console.WriteLine("For exit press 4");

                string command = Console.ReadLine();
                switch (command)
                {

                    case "1":
                        {
                            Console.WriteLine("Enter word");
                            string word = Console.ReadLine();
                            Console.WriteLine("Enter translation");
                            string translation = Console.ReadLine();

                            CreateWord(word, translation, database);
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine("Enter word");
                            string word = Console.ReadLine();

                            GetWordTranslation(word, database);
                        }
                        break;
                    case "3":
                        {
                            ListAllLords(database);
                        }
                        break;
                    case "4":
                        {
                            isWorking = false;
                        }
                        break;
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unknown Command");
                            Console.ResetColor();
                        }
                        break;
                }
            }
        }
    }
}
