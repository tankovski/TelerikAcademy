using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace CountingStrings
{
    
    public class StringCounter : IStringCounter
    {
        public int CountHowMuchTimesStringApersInOtherString(string text, string word)
        {
            MatchCollection mathes = Regex.Matches(text.ToLower(), word.ToLower());

            int numberOfApears = mathes.Count;

            return numberOfApears;
        }
    }
}
