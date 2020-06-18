using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MercadoPago
{
    public class MPAPIResponse
    {
        #region Properties

        public string HttpMethod { get; protected set; }
        public string Url { get; protected set; }
        public HttpWebRequest Request { get; protected set; }
        public string Payload { get; protected set; }
        public HttpWebResponse Response { get; protected set; }

        public int StatusCode { get; protected set; }
        public string StatusDescription { get; protected set; }

        public string StringResponse { get; protected set; }
        public JObject JsonObjectResponse { get; protected set; }

        public bool IsFromCache = false;

        #endregion

        #region Contructors

        /// <summary>
        /// Constructor with pararmeter.
        /// </summary>
        public MPAPIResponse(HttpMethod httpMethod, HttpWebRequest request, JObject payload, HttpWebResponse response)
        {
            this.Request = request;
            this.Response = response;

            ParseRequest(httpMethod, request, payload);
            ParseResponse(response);

            System.Diagnostics.Trace.WriteLine("Server response: " + this.StringResponse); 
        }

        /// <summary>
        /// Parses the http request in a custom MPApiResponse object.
        /// </summary>
        /// <param name="httpMethod">Http method enum</param>
        /// <param name="request">Http request to be parsed</param>
        /// <param name="payload">Payload oth the request</param>
        private void ParseRequest(HttpMethod httpMethod, HttpWebRequest request, JObject payload)
        {
            this.HttpMethod = httpMethod.ToString();
            this.Url = request.RequestUri.ToString();
            if (payload != null)
            {
                this.Payload = payload.ToString();
            }
        }
    
        /// <summary>
        /// Parses the http response in a custom MPApiResponse object.
        /// </summary>
        /// <param name="response">Http response to be parsed</param>
        private void ParseResponse(HttpWebResponse response)
        {
            this.StatusCode = (int)response.StatusCode;
            this.StatusDescription = response.StatusDescription;

            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    try
                    {
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            this.StringResponse = reader.ReadToEnd();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MPException(ex.Message);
                    }
    
                    // Try to parse the response to a json, and a extract the entity of the response.
                    // When the response is not a json parseable string then the string response must be used.
                    try
                    {
                        this.JsonObjectResponse = JObject.Parse(this.StringResponse);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error parsing jsonObect");
                    //    If not an object
                    }
                }
            }
        }

        #endregion
    }
}
