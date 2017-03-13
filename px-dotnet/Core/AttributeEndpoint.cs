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
        public string Path { get; protected set; }
        public HttpMethod HttpMethod { get; set; }
    }
    #endregion

    #region Request Types attributes
    /// <summary>
    /// Attribute to perform GET request.
    /// </summary>
    public class GETEndpoint : BaseEndpoint
    {
        public GETEndpoint(string path)
        {
            this.Path = path;
            HttpMethod = HttpMethod.GET;
        }
    }

    /// <summary>
    /// Attribute to perform POST request.
    /// </summary>
    public class POSTEndpoint : BaseEndpoint  
    {
        public POSTEndpoint(string path)
        {
            this.Path = path;
            HttpMethod = HttpMethod.POST;
        }
    }

    /// <summary>
    /// Attribute to perform PUT request.
    /// </summary>
    public class PUTEndpoint : BaseEndpoint
    {
        public PUTEndpoint(string path)
        {
            this.Path = path;
            HttpMethod = HttpMethod.PUT;
        }
    }

    /// <summary>
    /// Attibute to perform DELETE request.
    /// </summary>
    public class DELETEEndpoint : BaseEndpoint
    {
        public DELETEEndpoint(string path)
        {
            this.Path = path;
            HttpMethod = HttpMethod.DELETE;
        }
    }
    #endregion
}
