using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// The engine of the game. Responsible for following the logic and the rules of the game. The entrance point of the game.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// The default sleep time for every step in the game
        /// </summary>
        public const int RotationSleepTime = 100;
        /// <summary>
        /// The speed of the figures when down button is pressed
        /// </summary>
        public const int FastSpeed = 1;

        /// <summary>
        /// The renderer of the engine
        /// </summary>
        private IRenderer renderer;
        /// <summary>
        /// The user interface object resposible for handling the user input.
        /// </summary>
        private IUserInterface userInterface;
        /// <summary>
        /// The figure generator which the engine works with. It can be passed in the constructor.
        /// </summary>
        private IFigureGenerator figureGenerator;
        /// <summary>
        /// A list, containing the collected figures in the game
        /// </summary>
        private List<Figure> staticObjects;
        /// <summary>
        /// The next figure to be positioned on the field
        /// </summary>
        private Figure nextFigure;
        /// <summary>
        /// The current falling figure
        /// </summary>
        private Figure currentFigure;
        /// <summary>
        /// The current speed of the figures
        /// </summary>
        private int speed;
        /// <summary>
        /// The normal speed of the figure (it can be changed in the future if we want to add levels for example)
        /// </summary>
        private int normalSpeed = 5;
        /// <summary>
        /// True if the game is over and false if not
        /// </summary>
        private bool gameOver = false;
        /// <summary>
        /// The current score of the player
        /// </summary>
        private int score = 0;

        /// <summary>
        /// The current speed of the figures
        /// </summary>
        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                if (value > 0)
                {
                    this.speed = value;
                }
                else
                {
                    throw new IncorrectParametersException("The speed should be larger than 0.");
                }
            }
        }
        /// <summary>
        /// The normal speed of the figure (it can be changed in the future if we want to add levels for example)
        /// </summary>
        public int NormalSpeed
        {
            get
            {
                return this.normalSpeed;
            }
            set
            {
                if (value > 0)
                {
                    this.normalSpeed = value;
                }
                else
                {
                    throw new IncorrectParametersException("The speed should be larger than 0.");
                }
            }
        }
        /// <summary>
        /// Constructs the engine with default figure generator
        /// </summary>
        /// <param name="renderer">An IRenderer object</param>
        /// <param name="userInterface">An IUserInterface object</param>
        public Engine(IRenderer renderer, IUserInterface userInterface)
            : this(renderer, userInterface, new DefaultFigureGenerator()) { }
        /// <summary>
        /// Constructs the engine with custom figure generator
        /// </summary>
        /// <param name="renderer">An IRenderer object</param>
        /// <param name="userInterface">An IUserInterface object</param>
        /// <param name="figureGenerator">An IFigureGenerator</param>
        public Engine(IRenderer renderer, IUserInterface userInterface, IFigureGenerator figureGenerator)
        {
            if (renderer == null)
            {
                throw new IncorrectParametersException("The renderer can not be null.");
            }

            if (userInterface == null)
            {
                throw new IncorrectParametersException("The user interface can not be null.");
            }

            if (figureGenerator == null)
            {
                throw new IncorrectParametersException("The figure generator can not be null.");
            }

            this.renderer = renderer;
            this.userInterface = userInterface;
            this.figureGenerator = figureGenerator;

            this.currentFigure = this.figureGenerator.GenerateFigure(new Position(this.renderer.Width / 2, 0));
            this.nextFigure = this.figureGenerator.GenerateFigure(new Position(this.renderer.Width / 2, 0));
            this.staticObjects = new List<Figure>();
            this.speed = this.normalSpeed;
        }
        /// <summary>
        /// A method for running the game and starting the game loop. When called, the game starts.
        /// </summary>
        public void Run()
        {
            this.AttachUserInterfaceEvents();

            // Starting the game loop
            int counter = 0;
            while (!this.gameOver)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(Engine.RotationSleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                renderer.PrintScore(this.score);
              
                this.renderer.EnqueueForRendering(this.currentFigure);
                foreach (Figure obj in this.staticObjects)
                {
                    this.renderer.EnqueueForRendering(obj);
                }

                if (counter % this.speed == 0)
                {
                    this.MakeStep();
                }
                counter = (counter + 1) % this.Speed;
            }
        }
        /// <summary>
        /// Attaches the events handlers for the input events
        /// </summary>
        private void AttachUserInterfaceEvents()
        {
            // Attaching user interface events
            this.userInterface.OnLeftPressed += (sender, eventInfo) =>
            {
                this.currentFigure.MoveLeft();

                if (!this.isOnValidPosition(this.currentFigure))
                {
                    this.currentFigure.MoveRight();
                }
            };

            this.userInterface.OnRightPressed += (sender, eventInfo) =>
            {
                if (this.currentFigure.X + this.currentFigure.Width < this.renderer.Width)
                {
                    this.currentFigure.MoveRight();

                    if (!this.isOnValidPosition(this.currentFigure))
                    {
                        this.currentFigure.MoveLeft();
                    }
                }
            };

            this.userInterface.OnActionPressed += (sender, eventInfo) =>
            {
                this.currentFigure.Rotate();
                if (!this.isOnValidPosition(this.currentFigure))
                {
                    this.currentFigure.RotateBack();
                }
            };

            this.userInterface.OnDownPressed += (sender, eventInfo) =>
            {
                this.speed = Engine.FastSpeed;
            };
        }
        /// <summary>
        /// Determines if a given object is on a valid position
        /// </summary>
        /// <param name="obj">The object whose position to be checked for validity</param>
        /// <returns>True - if the object is on valid position, false - otherwise</returns>
        private bool isOnValidPosition(GameObject obj)
        {
            // if is outside the game field
            if (obj.X < 0 || obj.X + obj.Width > this.renderer.Width ||
                obj.Y < 0 || obj.Y + obj.Height > this.renderer.Height)
            {
                return false;
            }
            
            // if is over other object
            for (int i = 0; i < this.staticObjects.Count; i++)
            {
                if (this.AreInCollision(this.currentFigure, this.staticObjects[i]))
                {
                    return false;
                }
            }
            
            return true;
        }
        /// <summary>
        /// Checkes if two game objects are in collision
        /// </summary>
        /// <param name="first">The first game object</param>
        /// <param name="second">The second game object</param>
        /// <returns>True if the objects are in collision, false - otherwise</returns>
        private bool AreInCollision(GameObject first, GameObject second)
        {
            char[,] firstImage = first.GetImage();
            char[,] secondImage = second.GetImage();
            for (int firstRow = 0; firstRow < firstImage.GetLength(0); firstRow++)
            {
                for (int firstCol = 0; firstCol < firstImage.GetLength(1); firstCol++)
                {
                    if (firstImage[firstRow, firstCol] != ' ')
                    {
                        for (int secondRow = 0; secondRow < secondImage.GetLength(0); secondRow++)
                        {
                            for (int secondCol = 0; secondCol < secondImage.GetLength(1); secondCol++)
                            {
                                if (secondImage[secondRow, secondCol] != ' ' && first.X + firstCol == second.X + secondCol && first.Y + firstRow == second.Y + secondRow)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
        /// <summary>
        /// Removes the full lines and changes the position and the image of the affected objects
        /// </summary>
        private void RemoveFullLines()
        {

            List<int> fullLines = renderer.GetFullLines();
            if (fullLines.Count > 0)
            {
                //Increasing the score.If you get more lines at once the bonus is bigger!
                for (int i = 0; i < fullLines.Count; i++)
                {
                    this.score += fullLines.Count;
                }

                for (int i = 0; i < this.staticObjects.Count; i++)
                {
                    for (int j = 0; j < fullLines.Count; j++)
                    {
                        if (this.staticObjects[i].Y <= fullLines[j])
                        {
                            if (this.staticObjects[i].Y + this.staticObjects[i].Height > fullLines[j])
                            {
                                
                                this.staticObjects[i].RemoveLine(fullLines[j] - this.staticObjects[i].Y);
                            }
                            this.staticObjects[i].MoveDown();
                        }
                    }

                    if (this.staticObjects[i].Height <= 0)
                    {
                        this.staticObjects.RemoveAt(i);
                        i--;
                        
                    }
                }
            }
        }
        /// <summary>
        /// Makes one step in the game and calls the Update() method of every non-static object in the game
        /// </summary>
        private void MakeStep()
        {
            this.currentFigure.MoveDown();
            this.currentFigure.Update();
            if (!this.isOnValidPosition(this.currentFigure))
            {
                this.currentFigure.MoveUp();
                this.staticObjects.Add(currentFigure);
                this.currentFigure = this.nextFigure;
                this.nextFigure = this.figureGenerator.GenerateFigure(new Position(this.renderer.Width / 2, 0));
                renderer.PrintNextFigure(this.nextFigure);
                this.RemoveFullLines();
                this.Speed = this.NormalSpeed;
                if (this.staticObjects[this.staticObjects.Count - 1].Y <= 0)
                {
                    this.gameOver = true;
                    renderer.PrintGameOver();
                }
            }
        }
    }
}
