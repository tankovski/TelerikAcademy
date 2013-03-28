using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// An intereface should be implemented by every renderer. It is used by the engine.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// The width of the game field
        /// </summary>
        int Width { get; }
        /// <summary>
        /// The height of the game field
        /// </summary>
        int Height { get; }
        /// <summary>
        /// Enqueues an object to be rendered on the next scene of the game
        /// </summary>
        /// <param name="obj">The object to be rendered on the next scene</param>
        void EnqueueForRendering(IRenderable obj);
        /// <summary>
        /// Renderes the next scene on the console
        /// </summary>
        void RenderAll();
        /// <summary>
        /// Clears the queue of the objects to be rendered
        /// </summary>
        void ClearQueue();
        /// <summary>
        /// Itereates all the lines of the game fields and returns the full lines
        /// </summary>
        /// <returns>A list of zero-based numbers of lines(from top to bottom)</returns>
        List<int> GetFullLines();
        /// <summary>
        /// Prints the "Game Over" message on the console
        /// </summary>
        void PrintGameOver();
        /// <summary>
        /// Prints the next figure on the console
        /// </summary>
        /// <param name="nextFigure">The next figure object</param>
        void PrintNextFigure(Figure nextFigure);
        /// <summary>
        /// Prints the score on the console
        /// </summary>
        /// <param name="score">The score to be printeed</param>
        void PrintScore(int score);
    }
}
