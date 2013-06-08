using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindHowMenyTimesEachWordAppearsAndOrderThem
{
    class FindHowMenyTimesEachWordAppearsAndOrderThem
    {
        static void Main()
        {
            StreamReader reader = new StreamReader(@"../../../words.txt");
            using (reader)
            {
                string text = reader.ReadToEnd();
                char[] separators = { ' ', '.', ',', '!', '–','?','-'};
                string[] values = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                foreach (var value in values)
                {
                    int count = 0;
                    if (dictionary.ContainsKey(value))
                    {
                        count = dictionary[value];
                    }
                    dictionary[value] = count + 1;
                }

                foreach (KeyValuePair<string, int> item in dictionary.OrderBy(key => key.Value))
                {
                    Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
                }
            }

           
           
        }
    }
}
