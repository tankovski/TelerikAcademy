using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Tetris
    {
        static void Main()
        {
            ConsoleRenderer renderer = new ConsoleRenderer(15, 20);
            KeyboardInterface keyboard = new KeyboardInterface();
            Engine engine = new Engine(renderer, keyboard);
            engine.Run();
        }
    }
}
