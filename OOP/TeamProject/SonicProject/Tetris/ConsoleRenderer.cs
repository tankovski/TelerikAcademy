using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// A console renderer class responsible for rendering the visual content on the console
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// The visible representation of the current scene of the game
        /// </summary>
        private char[,] image;
        /// <summary>
        /// The width of the game field(in chars)
        /// </summary>
        public int Width 
        {
            get
            {
                return this.image.GetLength(1);
            }
        }
        /// <summary>
        /// The height of the game field(in chars)
        /// </summary>
        public int Height
        {
            get
            {
                return this.image.GetLength(0);
            }
        }
        /// <summary>
        /// The constructor of the renderer which is responsible for initializing the fields dimensions
        /// </summary>
        /// <param name="width">The width of the field(in chars)</param>
        /// <param name="height">The height of the field(in chars)</param>
        public ConsoleRenderer(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new IncorrectParametersException("The width and height of the game field must be positive numbers.");
            }
            image = new char[height, width];
            this.ClearQueue();
        }
        /// <summary>
        /// Enqueues an object to be rendered on the next scene of the game
        /// </summary>
        /// <param name="obj">The object to be rendered on the next scene</param>
        public void EnqueueForRendering(IRenderable obj)
        {
            char[,] image = obj.GetImage();

            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    if (image[i, j] != ' ' &&
                        obj.X + j >= 0 && obj.X + j < this.image.GetLength(1) &&
                        obj.Y + i >= 0 && obj.Y + i < this.image.GetLength(0))
                    {
                        this.image[obj.Y + i, obj.X + j] = image[i, j];
                    }
                }
            }
        }
        /// <summary>
        /// Renderes the next scene on the console
        /// </summary>
        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);
            int rows = this.image.GetLength(0);
            int cols = this.image.GetLength(1);
            StringBuilder scene = new StringBuilder(rows * cols + 2*(rows + cols) + rows);

            for (int row = 0; row < rows; row++)
            {
                scene.Append('|');
                for (int col = 0; col < cols; col++)
                {
                    scene.Append(this.image[row, col]);
                }

                scene.Append('|');
                scene.Append(Environment.NewLine);
            }

            scene.Append(new String('-', cols + 2));
            scene.Append(Environment.NewLine);
            Console.WriteLine(scene.ToString());
        }
        /// <summary>
        /// Clears the queue of the objects to be rendered
        /// </summary>
        public void ClearQueue()
        {
            for (int row = 0; row < this.image.GetLength(0); row++)
            {
                for (int col = 0; col < this.image.GetLength(1); col++)
                {
                    this.image[row, col] = ' ';
                }
            }
        }
        /// <summary>
        /// Itereates all the lines of the game fields and returns the full lines
        /// </summary>
        /// <returns>A list of zero-based numbers of lines(from top to bottom)</returns>
        public List<int> GetFullLines()
        {
            List<int> fullLines = new List<int>();
            for (int i = 0; i < this.image.GetLength(0); i++)
            {
                for (int j = 0; j < this.image.GetLength(1); j++)
                {
                    if (this.image[i, j] == ' ')
                    {
                        break;
                    }
                    else if (j == this.image.GetLength(1) - 1)
                    {
                        fullLines.Add(i);
                    }
                }
            }

            return fullLines;
        }
        /// <summary>
        /// Prints the "Game Over" message on the console
        /// </summary>
        public void PrintGameOver()
        {
            string message = "Game Over";
            int left = (this.Width - message.Length) / 2 + 1;
            int top = (this.Height - 3) / 2;
            Console.SetCursorPosition(left, top);
            Console.Write(new String(' ', message.Length + 2));
            Console.SetCursorPosition(left, top + 1);
            Console.Write(String.Format(" {0} ", message));
            Console.SetCursorPosition(left, top + 2);
            Console.Write(new String(' ', message.Length + 2));
            Console.SetCursorPosition(0, this.Height + 2);
            System.Threading.Thread.Sleep(2000);
        }
        /// <summary>
        /// Prints the next figure on the console
        /// </summary>
        /// <param name="nextFigure">The next figure object</param>
        public void PrintNextFigure(Figure nextFigure)
        {
            int left = this.Width + 5;
            int top = 3;

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(left, top);
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(new String(' ', 6));
                }

                top++;
            }

            top = 3;
            char[,] image = nextFigure.GetImage();
            for (int i = 0; i < image.GetLength(0); i++)
            {
                Console.SetCursorPosition(left, top);
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    Console.Write(image[i, j]);
                }

                top++;
            }
        }
        /// <summary>
        /// Prints the score on the console
        /// </summary>
        /// <param name="score">The score to be printeed</param>
        public void PrintScore(int score)
        {
            int left = this.Width + 3;
            int top = 0;
            Console.SetCursorPosition(left, top);
            Console.Write("Score:" + score);
        }
    }
}
