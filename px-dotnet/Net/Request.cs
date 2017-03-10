using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MercadoPago.Net
{
    /// <summary>
    /// class to simulate HttpClient class, available from .NET 4.0 onward.
    /// </summary>
    public class Request
    {
        public WebClient Client { get; set; }
        public string JsonData { get; set; }
    }
}
