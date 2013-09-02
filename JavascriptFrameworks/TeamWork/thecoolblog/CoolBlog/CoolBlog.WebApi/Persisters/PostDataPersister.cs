namespace CoolBlog.WebApi.Persisters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CoolBlog.Model;

    public class PostDataPersister : BaseDataPersister
    {
        public static IEnumerable<Tag> GetPostTitleWords(string title)
        {
            var separators = new char[] {' ', '.', ',', ')', '(' ,'-', '_', ';', ':', '<', '>' };
            var words = title.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var result =
                from word in words
                select new Tag()
                {
                    Name = word
                };

            return result;
        }
    }
}