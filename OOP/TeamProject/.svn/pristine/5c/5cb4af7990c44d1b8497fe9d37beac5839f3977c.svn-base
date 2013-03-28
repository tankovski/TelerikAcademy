using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// A user interface class, responsible for receiving the user interface events for manipulating the game logic
    /// </summary>
    public class KeyboardInterface : IUserInterface
    {
        /// <summary>
        /// A method for proccessing the input (the pressed keys)
        /// </summary>
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key.Equals(ConsoleKey.A))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.D))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnActionPressed != null)
                    {
                        this.OnActionPressed(this, new EventArgs());
                    }
                }
                if (keyInfo.Key.Equals(ConsoleKey.S))
                {
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
                    }
                }
            }
        }
        /// <summary>
        /// Triggerd when down button is pressed
        /// </summary>
        public event EventHandler OnDownPressed;
        /// <summary>
        /// Triggerd when left button is pressed
        /// </summary>
        public event EventHandler OnLeftPressed;
        /// <summary>
        /// Triggerd when right button is pressed
        /// </summary>
        public event EventHandler OnRightPressed;
        /// <summary>
        /// Triggerd when action(rotate) button is pressed
        /// </summary>
        public event EventHandler OnActionPressed;
    }
}

