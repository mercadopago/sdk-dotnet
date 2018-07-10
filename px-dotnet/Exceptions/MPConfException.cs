using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MercadoPago
{
    [Serializable]
    internal class MPConfException : MPException
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Expection message.</param>
        public MPConfException(string message) : base(message)
        {
        }
        #endregion
    }
}
