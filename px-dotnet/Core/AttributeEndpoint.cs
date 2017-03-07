using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public class BaseEndpoint : Attribute
    {
        public string Path { get; protected set; }
    }

    public class GETEndpoint : BaseEndpoint
    {
        public GETEndpoint(string path)
        {
            this.Path = path;
        }
    }

    public class POSTEndpoint : BaseEndpoint  
    {
        public POSTEndpoint(string path)
        {
            this.Path = path;
        }
    }

    public class PUTEndpoint : BaseEndpoint
    {
        public PUTEndpoint(string path)
        {
            this.Path = path;
        }
    }

    public class DELETEEndpoint : BaseEndpoint
    {
        public DELETEEndpoint(string path)
        {
            this.Path = path;
        }
    }
}
