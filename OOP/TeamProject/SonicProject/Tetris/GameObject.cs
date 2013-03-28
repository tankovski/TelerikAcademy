using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// The main object in the game, every visible object on the field inherits from it
    /// </summary>
    public abstract class GameObject : IRenderable
    {
        /// <summary>
        /// The visible part of the object, in the form of a char matrix
        /// </summary>
        protected char[,] image;

        /// <summary>
        /// The position of the object on the field
        /// </summary>
        protected Position position;
        /// <summary>
        /// The X coordinate of the object
        /// </summary>
        public int X
        {
            get
            {
                return this.position.X;
            }
        }
        /// <summary>
        /// The Y coordinate of the object
        /// </summary>
        public int Y
        {
            get
            {
                return this.position.Y;
            }
        }
        /// <summary>
        /// The width of the game object (in chars)
        /// </summary>
        public int Width
        {
            get
            {
                return this.image.GetLength(1);
            }
        }
        /// <summary>
        /// The height of the game object (in chars)
        /// </summary>
        public int Height
        {
            get
            {
                return this.image.GetLength(0);
            }
        }
        /// <summary>
        /// The main constructor of a game objects.
        /// </summary>
        /// <param name="position">The position of the game object on the field</param>
        /// <param name="image">The visible part of the object, in the form of a char matrix </param>
        public GameObject(Position position, char[,] image)
        {
            this.image = (char[,])image.Clone();
            this.position = position;
        }
        /// <summary>
        /// Removes a given line of the visible part of the object
        /// </summary>
        /// <param name="lineNumber">A zero-based number, representing the line to be removed.</param>
        public void RemoveLine(int lineNumber)
        {
            if (lineNumber < 0 || lineNumber >= this.image.GetLength(0))
            {
                throw new ArgumentOutOfRangeException(String.Format("There is no row {0} in the figure.", lineNumber));
            }
            char[,] newImage = new char[this.image.GetLength(0) - 1, this.image.GetLength(1)];
            int offset = 0;
            for (int i = 0; i < newImage.GetLength(0); i++)
            {
                if (i == lineNumber)
                {
                    offset++;
                }
                for (int j = 0; j < newImage.GetLength(1); j++)
                {
                    newImage[i, j] = image[i + offset, j];
                }
            }

            this.image = newImage;
        }
        /// <summary>
        /// Something special to be done with the object on every step of the game.
        /// </summary>
        abstract public void Update();
        /// <summary>
        /// Gets a copy of the visible part of the object.
        /// </summary>
        /// <returns>A copy of the visible part of the object</returns>
        public char[,] GetImage()
        {
            return (char[,])this.image.Clone();
        }
    }
}
