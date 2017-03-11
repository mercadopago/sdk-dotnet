using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    [Serializable]
    public class MPRESTException : MPException
    {
        public MPRESTException(string message) : base(message)
        {
        }        
    }
}
