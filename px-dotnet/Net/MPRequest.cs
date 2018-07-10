using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MercadoPago
{
    /// <summary>
    /// class to simulate HttpClient class, available from .NET 4.0 onward.
    /// </summary>
    internal class MPRequest
    {
        #region Variables
        public HttpWebRequest Request { get; set; }
        public byte[] RequestPayload { get; set; }
        #endregion
    }
}
