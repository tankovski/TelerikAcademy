using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// The class responsible for the positioning the objects on the game field
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The X coordinate
        /// </summary>
        private int x;
        /// <summary>
        /// The Y coordinate
        /// </summary>
        private int y;
        /// <summary>
        /// The X coordinate
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        /// <summary>
        /// The Y coordinate
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        /// <summary>
        /// The constructor of the position
        /// </summary>
        /// <param name="x">The X coordinate of the position</param>
        /// <param name="y">THe Y coordinate of the position</param>
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
