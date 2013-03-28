using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Default random generator for figures (includes all the predefined figures in the game)
    /// </summary>
    public class DefaultFigureGenerator : IFigureGenerator
    {
        /// <summary>
        /// The Random instance responsible for generating random number, which later to be matched with concrete figure
        /// </summary>
        private Random randomGenerator;

        /// <summary>
        /// A parameterless constructor
        /// </summary>
        public DefaultFigureGenerator()
        {
            this.randomGenerator = new Random();
        }
        /// <summary>
        /// The method responsible for generating a new figure (used by the engine of the game)
        /// </summary>
        /// <param name="position">The position on which to be put the new generated figure</param>
        /// <returns>The generated figure</returns>
        public Figure GenerateFigure(Position position)
        {
            switch (this.randomGenerator.Next(1, 9))
            {
                case 1: return new LeftG(position);
                case 2: return new LeftS(position);
                case 3: return new Line(position);
                case 4: return new RightS(position);
                case 5: return new Square(position);
                case 6: return new TFigure(position);
                case 7: return new UFigure(position);
                case 8: return new XFigure(position);
                default: return new Line(position);
                    
            }
        }
    }
}
