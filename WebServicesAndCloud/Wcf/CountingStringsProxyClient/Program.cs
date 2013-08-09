using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingStringsClient
{
    class Program
    {
        static void Main()
        {
            StringCounterClient client = new StringCounterClient();
            int numberOfAppears = client.CountHowMuchTimesStringApersInOtherString("I like to move it, move it", "move");
            Console.WriteLine(numberOfAppears);
        }
    }
}
