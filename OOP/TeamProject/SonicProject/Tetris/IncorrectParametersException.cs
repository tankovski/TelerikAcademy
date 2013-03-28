using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// A custom exception thrown when an incorrect parameteres are passed
    /// </summary>
    public class IncorrectParametersException : ApplicationException
    {
        /// <summary>
        /// The message of the exception
        /// </summary>
        private string message;

        /// <summary>
        /// The message of the exception
        /// </summary>
        public override string Message
        {
            get
            {
                string result = string.Format("Invalid parameters!" + this.message);
                return result;
            }
        }

        /// <summary>
        /// Initializing the exception
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public IncorrectParametersException(string message)
        {
            this.message = message;
        }

    }
}
