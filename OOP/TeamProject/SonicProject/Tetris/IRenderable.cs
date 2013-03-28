using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Interface which is imlemented from every rendarable object
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// The X coordinate of the objects
        /// </summary>
        int X { get; }
        /// <summary>
        /// The Y coordinate of the object
        /// </summary>
        int Y { get; }
        /// <summary>
        /// Removes a line from the figure's image (from the visible part)
        /// </summary>
        /// <param name="lineNumber">A zero based line number of the line to be removed</param>
        void RemoveLine(int lineNumber);
        /// <summary>
        /// Returns a copy of the visible part of the object (represented by char matrix)
        /// </summary>
        /// <returns>A copy of the visible part of the object</returns>
        char[,] GetImage();
    }
}
