using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace NewsSearch
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri(" http://api.feedzilla.com/v1/") };

        static void Main(string[] args)
        {

            Console.WriteLine("For sport news press 1");
            Console.WriteLine("For programming news press 2");
            Console.WriteLine("For politic news pres 3");

            int category = int.Parse(Console.ReadLine());

            int categoryId = 0;
            int subcategoryId = 0;
            switch (category)
            {
                case 1:
                    {
                        categoryId = 27;
                        Console.WriteLine();
                        Console.WriteLine("For Fitness press 1");
                        Console.WriteLine("For Extreme sports press 2");
                        Console.WriteLine("For Football press 3");
                        int subcategory = int.Parse(Console.ReadLine());

                        switch (subcategory)
                        {
                            case 1: subcategoryId = 1419; break;
                            case 2: subcategoryId = 1414; break;
                            case 3: subcategoryId = 1829; break;
                            default: Console.WriteLine("Invalid Subcategory"); break;
                        }
                       
                    }
                    break;
                case 2:
                    {
                        categoryId = 16;
                        Console.WriteLine();
                        Console.WriteLine("For .net news press 1");
                        Console.WriteLine("For Asp news press 2");
                        Console.WriteLine("For Javascript news press 3");
                        int subcategory = int.Parse(Console.ReadLine());

                        switch (subcategory)
                        {
                            case 1: subcategoryId = 1741; break;
                            case 2: subcategoryId = 727; break;
                            case 3: subcategoryId = 731; break;
                            default: Console.WriteLine("Invalid Subcategory"); break;
                        }

                    }
                    break;
                case 3:
                    {
                        categoryId = 3;
                        Console.WriteLine();
                        Console.WriteLine("For America politic news press 1");
                        Console.WriteLine("For Europa politic news press 2");
                        Console.WriteLine("For Middle east politic news press 3");
                        int subcategory = int.Parse(Console.ReadLine());

                        switch (subcategory)
                        {
                            case 1: subcategoryId = 65; break;
                            case 2: subcategoryId = 73; break;
                            case 3: subcategoryId = 78; break;
                            default: Console.WriteLine("Invalid Subcategory"); break;
                        }

                    }
                    break;
                default:
                    {
                        Console.WriteLine("Invalid Category");
                    }
                    break;
            }


            Console.WriteLine();
            Console.WriteLine("Enter how much articles to display: ");
            int articlesCount = int.Parse(Console.ReadLine());
            Catalog newsCatalog = GetAllSongs(categoryId, subcategoryId, articlesCount);

            
            foreach (var article in newsCatalog.Articles)
            {
                Console.WriteLine();
                Console.WriteLine("Title: "+article.Title);
                Console.WriteLine("Url: " + article.Url);
            }
            
        }

       

        public static Catalog GetAllSongs(int categoryId,int subcategoryId,int count)
        {
            var request = WebRequest.Create("http://api.feedzilla.com/v1/categories/"+
                categoryId+"/subcategories/"+
                subcategoryId+"/articles.json?count="+
                count) as HttpWebRequest;

            request.ContentType = "application/json";
            request.Method = "GET";

            var response = request.GetResponse();

            var responseReader = new StreamReader(response.GetResponseStream());

            string articles = responseReader.ReadToEnd();

            Catalog catalog = JsonConvert.DeserializeObject<Catalog>(articles);

            responseReader.Close();

            return catalog;
        }
    }
}
