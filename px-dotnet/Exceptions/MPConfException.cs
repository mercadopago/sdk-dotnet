using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Mercadopago.Exceptions
{
    [Serializable]
    public class MPConfException : MPException
    {
        public MPConfException(string message) : base(message)
        {
        }
    }
}
