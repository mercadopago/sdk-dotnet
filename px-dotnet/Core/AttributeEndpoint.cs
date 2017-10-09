using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    #region Base Endpoint Attribute

    /// <summary>
    /// Represents the top level attribute type.
    /// </summary>
    public class BaseEndpoint : Attribute
    {
        #region Properties

        public string Path { get; protected set; }
        public HttpMethod HttpMethod { get; set; }
        public PayloadType PayloadType { get; set; }
        public int Retries { get; protected set; }
        public int RequestTimeout { get; protected set; }

        #endregion

        #region Constructors

        public BaseEndpoint(string path, HttpMethod methodType, int requestTimeout, int retries)
        {
            this.Path = path;
            HttpMethod = methodType;
            RequestTimeout = requestTimeout;
            Retries = retries == 0 ? 1 : retries;
            PayloadType = PayloadType.JSON;
        }

        #endregion
    }

    #endregion

    #region Request Types attributes

    /// <summary>
    /// Attribute to perform GET request.
    /// </summary>
    public class GETEndpoint : BaseEndpoint
    {
        public GETEndpoint(string path)
            : base(path, HttpMethod.GET, 0, 0)
        {            
        }

        public GETEndpoint(string path, int requestTimeout)
            : base(path, HttpMethod.GET, requestTimeout, 0)
        {
        }

        public GETEndpoint(string path, int requestTimeout, int retries)
            : base(path, HttpMethod.GET, requestTimeout, retries)
        {
        }
    }

    /// <summary>
    /// Attribute to perform POST request.
    /// </summary>
    public class POSTEndpoint : BaseEndpoint  
    {
        public POSTEndpoint(string path)
            : base(path, HttpMethod.POST, 0, 0)
        {            
        }

        public POSTEndpoint(string path, int requestTimeout)
            : base(path, HttpMethod.POST, requestTimeout, 0)
        {
        }

        public POSTEndpoint(string path, int requestTimeout, int retries)
            : base(path, HttpMethod.POST, requestTimeout, retries)
        {
        }
    }

    /// <summary>
    /// Attribute to perform PUT request.
    /// </summary>
    public class PUTEndpoint : BaseEndpoint
    {
        public PUTEndpoint(string path)
            : base(path, HttpMethod.PUT, 0, 0)
        {            
        }

        public PUTEndpoint(string path, int requestTimeout)
            : base(path, HttpMethod.PUT, requestTimeout, 0)
        {
        }

        public PUTEndpoint(string path, int requestTimeout, int retries)
            : base(path, HttpMethod.PUT, requestTimeout, retries)
        {
        }
    }

    /// <summary>
    /// Attibute to perform DELETE request.
    /// </summary>
    public class DELETEEndpoint : BaseEndpoint
    {
        public DELETEEndpoint(string path)
            : base(path, HttpMethod.DELETE, 0, 0)
        {            
        }

        public DELETEEndpoint(string path, int requestTimeout)
            : base(path, HttpMethod.DELETE, requestTimeout, 0)
        {
        }

        public DELETEEndpoint(string path, int requestTimeout, int retries)
            : base(path, HttpMethod.DELETE, requestTimeout, retries)
        {
        }
    }

    #endregion
}
