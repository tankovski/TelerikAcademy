using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Implemented by every movable object in the game
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Moves the object on left direction
        /// </summary>
        void MoveLeft();
        /// <summary>
        /// Moves the object on right direction
        /// </summary>
        void MoveRight();
        /// <summary>
        /// Moves the object on down direction
        /// </summary>
        void MoveDown();
        /// <summary>
        /// Moves the object on up direction
        /// </summary>
        void MoveUp();
        /// <summary>
        /// Rotates the figure clockwise
        /// </summary>
        void Rotate();
        /// <summary>
        /// Rotates the figure anticlockwise
        /// </summary>
        void RotateBack();
    }
}
