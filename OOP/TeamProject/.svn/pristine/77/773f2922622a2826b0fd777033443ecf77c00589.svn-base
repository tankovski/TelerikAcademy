using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// The generic figure class which implements the main functionality of a figure. All figures inherits from it.
    /// </summary>
    public abstract class Figure : GameObject, IMovable
    {
        /// <summary>
        /// The constructor which initializes the figures properties
        /// </summary>
        /// <param name="position">The position of the figure in the game</param>
        /// <param name="image">The visual part(the image) if the figure, represented by char matrix</param>
        public Figure(Position position, char[,] image)
            : base(position, image) { }

        /// <summary>
        /// Moves the position of the figure one step on left direction
        /// </summary>
        public virtual void MoveLeft()
        {
            this.position.X--;
        }
        /// <summary>
        /// Moves the position of the figure one step on right direction
        /// </summary>
        public virtual void MoveRight()
        {
            this.position.X++;
        }
        /// <summary>
        /// Moves the position of the figure one step on down direction
        /// </summary>
        public virtual void MoveDown()
        {
            this.position.Y++;
        }
        /// <summary>
        /// Moves the position of the figure one step on up direction
        /// </summary>
        public virtual void MoveUp()
        {
            this.position.Y--;
        }
        /// <summary>
        /// Rotates the figure clockwise
        /// </summary>
        public virtual void Rotate()
        {
            // Rotating the image
            char[,] rotatedImage = new char[this.image.GetLength(1), this.image.GetLength(0)];
            for (int i = 0; i < this.image.GetLength(0); i++)
            {
                for (int j = 0; j < this.image.GetLength(1); j++)
                {
                    rotatedImage[j, this.image.GetLength(0) - i - 1] = this.image[i, j];
                }
            }
            this.image = rotatedImage;

            // Fixing the position
            this.position.X += (rotatedImage.GetLength(0) - rotatedImage.GetLength(1)) / 2;
            this.position.Y += (rotatedImage.GetLength(1) - rotatedImage.GetLength(0)) / 2;
        }
        /// <summary>
        /// Rotates the figure anticlockwise
        /// </summary>
        public virtual void RotateBack()
        {
            // Rotating the image
            char[,] rotatedImage = new char[this.image.GetLength(1), this.image.GetLength(0)];
            for (int i = 0; i < this.image.GetLength(0); i++)
            {
                for (int j = 0; j < this.image.GetLength(1); j++)
                {
                    rotatedImage[this.image.GetLength(1) - j - 1, i] = this.image[i, j];
                }
            }
            this.image = rotatedImage;

            // Fixing the position
            this.position.X += (rotatedImage.GetLength(0) - rotatedImage.GetLength(1)) / 2;
            this.position.Y += (rotatedImage.GetLength(1) - rotatedImage.GetLength(0)) / 2;
        }
        /// <summary>
        /// Something special to be done eith the figure on every step of the game.
        /// </summary>
        public override void Update()
        {
            // Nothing special is happening
        }
    }
}
