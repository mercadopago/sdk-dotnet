using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    /// <summary>
    /// Enum that indicates the type of payload we will use in the future request.
    /// </summary>
    internal enum PayloadType
    {        
        NONE,
        JSON,
        X_WWW_FORM_URLENCODED
    }
}
