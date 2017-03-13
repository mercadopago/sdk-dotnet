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
        #region Variables
        public string Path { get; protected set; }
        public HttpMethod HttpMethod { get; set; }
        #endregion

        #region Constructors
        public BaseEndpoint(string path, HttpMethod methodType)
        {
            this.Path = path;
            HttpMethod = methodType;
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
        public GETEndpoint(string path) : base(path, HttpMethod.GET)
        {            
        }
    }

    /// <summary>
    /// Attribute to perform POST request.
    /// </summary>
    public class POSTEndpoint : BaseEndpoint  
    {
        public POSTEndpoint(string path) : base(path, HttpMethod.POST)
        {            
        }
    }

    /// <summary>
    /// Attribute to perform PUT request.
    /// </summary>
    public class PUTEndpoint : BaseEndpoint
    {
        public PUTEndpoint(string path) : base(path, HttpMethod.PUT)
        {            
        }
    }

    /// <summary>
    /// Attibute to perform DELETE request.
    /// </summary>
    public class DELETEEndpoint : BaseEndpoint
    {
        public DELETEEndpoint(string path) : base(path, HttpMethod.DELETE)
        {            
        }
    }
    #endregion
}
