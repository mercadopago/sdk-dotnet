using MercadoPago.Core;
using MercadoPago.Core.Annotations;
using MercadoPago.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MercadoPago.Net
{
    public class MPRESTClient
    {
        #region Variables
        public string ProxyHostName = null;
        public int ProxyPort = -1;
        #endregion

        #region Core
        public MPRESTClient()
        {
            new MPRESTClient(null, -1);
        }

        public MPRESTClient(String proxyHostName, int proxyPort)
        {
            this.ProxyHostName = proxyHostName;
            this.ProxyPort = proxyPort;
        }

        public MPAPIResponse ExecuteRequest(HttpMethod httpMethod, String uri, PayloadType payloadType, JObject payload, List<WebHeaderCollection> colHeaders)
        {
            try
            {
                return ExecuteRequest(httpMethod, uri, payloadType, payload, colHeaders, 0, 0, 0);
            }
            catch (Exception ex)
            {
                throw new MPRESTException(ex.Message);
            }
        }

        public MPAPIResponse ExecuteRequest(HttpMethod httpMethod, String uri, PayloadType payloadType, JObject payload, List<WebHeaderCollection> colHeaders, int retries, int connectionTimeout, int socketTimeout)
        {
            try
            {
                WebClient client = new WebClient();
                
                return new MPAPIResponse();
            }
            catch (Exception ex)
            {
                throw new MPRESTException(ex.Message);
            }            
        }

        private WebClient NormalizePayload(PayloadType payloadType, JObject payload, WebHeaderCollection colHeaders)
        {
            WebClient client = new WebClient();             
            string stringEntity = null;
            if (payload != null) {
                if (payloadType == PayloadType.JSON) 
                {                    
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";                                                 
                    try 
                    {
                        stringEntity = payload.ToString();
                    } 
                    catch(Exception ex) {
                        throw new MPRESTException(ex.Message);
                    }                    
                } 
                else 
                {                    
                    Dictionary<string, object> map = JsonConvert.DeserializeObject<Dictionary<string, object>>(payload.ToString());                                                                                
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";                                        
                }
            }
                        
            if (client.Headers != null) {
                for (int i = 0; i < client.Headers.Count; ++i)
                {
                    string header = client.Headers.GetKey(i);

                    colHeaders.Add(header);                    
                }
            }

            return client;
        }
        #endregion


        /// <summary>
        /// Get the request method we will use later.
        /// </summary>
        /// <param name="httpMethod">Http method we are trying to use in the call process.</param>
        /// <param name="uri">Uri to point.</param>
        /// <param name="entity">Data to be sent in the call.</param>
        /// <returns></returns>
        public WebRequest GetRequestMethod(HttpMethod httpMethod, string uri, string entity = null)
        {
            if (httpMethod == null) 
            {
            throw new MPRESTException("HttpMethod must be \"GET\", \"POST\", \"PUT\" or \"DELETE\".");
            }

            if (string.IsNullOrEmpty(uri))
            {
                throw new MPRESTException("Uri can not be an empty String.");
            }
            

            WebRequest request = null;

            switch (httpMethod)
            {
                case HttpMethod.GET:
                {
                    if (entity != null)
                    {
                        throw new MPRESTException("Payload not supported for this method.");
                    }
                    request = WebRequest.Create(uri);
                    request.Method = "GET";
                }
                break;
                case HttpMethod.POST:
                {
                    if (entity == null) 
                    {
                        throw new MPRESTException("Must include payload for this method.");
                    }
                    WebRequest post = WebRequest.Create(uri);
                    byte[] byteArray = Encoding.UTF8.GetBytes(entity); 
                    post.Method = "POST";
                    post.ContentLength = byteArray.Length;
                    request = post;    
                }
                break;
                case HttpMethod.PUT:
                {
                    if (entity == null) 
                    {
                        throw new MPRESTException("Must include payload for this method.");
                    }
                    byte[] byteArray = Encoding.UTF8.GetBytes(entity); 
                    WebRequest put = WebRequest.Create(uri);
                    put.Method = "PUT";
                    put.ContentLength = byteArray.Length;
                    request = put;
                }
                break;
                case HttpMethod.DELETE:
                {
                    if (entity != null) 
                    {
                        throw new MPRESTException("Payload not supported for this method.");
                    }
                                        
                    request = WebRequest.Create(uri);
                    request.Method = "DELETE";
                }
                break;
            }
                        
            return request;
        }
    }
}

