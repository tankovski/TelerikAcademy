using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// The interface used from the engine to work with user input
    /// </summary>
    public interface IUserInterface
    {
        /// <summary>
        /// Triggerd when left button is pressed
        /// </summary>
        event EventHandler OnLeftPressed;
        /// <summary>
        /// Triggerd when right button is pressed
        /// </summary>
        event EventHandler OnRightPressed;
        /// <summary>
        /// Triggerd when action button is pressed
        /// </summary>
        event EventHandler OnActionPressed;
        /// <summary>
        /// Triggerd when down button is pressed
        /// </summary>
        event EventHandler OnDownPressed;
        /// <summary>
        /// A method for proccessing the input (the pressed keys)
        /// </summary>
        void ProcessInput();
    }
}
