using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace CompanyArticles
{
    class Program
    {
        static void Main()
        {
            Article[] articles = {new Article(0999311,"GeorgiIvanovOOD","Gloves",10.56M),
                                     new Article(09945311,"GeorgiIvanovOOD","Hats",8.00M),
                                     new Article(45945311,"ETIliev","Bags",18.00M),
                                     new Article(45947311,"ETIliev","Shoes",18.00M),
                                     new Article(13447311,"ETIliev","Socks",3.99M),
                                     new Article(13412570,"ETDimitrov","BaseballBats",23.99M)};

            OrderedMultiDictionary<decimal, Article> catalog = new OrderedMultiDictionary<decimal, Article>(true);

            foreach (var article in articles)
            {
                catalog.Add(article.Price, article);
            }

            var pricesRange = catalog.FindAll(x => x.Key >= 10 && x.Key <= 20);
            foreach (var item in pricesRange)
            {
                string items = "";
                int count = 0;
                foreach (var article in item.Value)
                {
                    count += 1;
                    items += "article"+count+": "+ article.Title + " " + article.Vedndor + " " + article.Barcode+";\n";
                }

                Console.WriteLine("Price: {0} - articles: {1}",
                    item.Key,items);
            }
        }
    }
}
