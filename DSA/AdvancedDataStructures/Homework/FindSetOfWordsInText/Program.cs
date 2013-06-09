using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class Program
{
    static void Main()
    {
        Trie<string> trie = new Trie<string>();
        StreamReader reader = new StreamReader(@"../../../text.txt");
        using (reader)
        {
            string text = reader.ReadToEnd();

            char[] separators = { ' ', '.', '!', '-', '?', '_' };
            string[] array = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < array.Length; i++)
            {
                trie.Put(array[i], i.ToString());
            }

            string word = "Conan";
            for (int i = 0; i < word.Length; i++)
            {
               

            }
            foreach (var item in trie.Matcher.GetPrefixMatches())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(trie.Matcher.GetExactMatch());
        }
    }
}

