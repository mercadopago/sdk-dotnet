using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    [Serializable]
    public class MPRESTException : MPException
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message.</param>
        public MPRESTException(string message) : base(message)
        {
        }
        #endregion
    }
}
