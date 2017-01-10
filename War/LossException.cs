using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace War
{
    /// <summary>
    /// Loss Exception - Custom exception to handle in this game
    /// </summary>
    class LossException : Exception
    {
        #region Constructors
        public LossException()
        {

        }
        public LossException(string message)
            : base(message)
        {
        }
        public LossException(string message, Exception inner)
            :base(message, inner)
        {
        }
        #endregion
    }
}
