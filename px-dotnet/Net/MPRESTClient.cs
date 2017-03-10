using MercadoPago.Core;
using MercadoPago.Core.Annotations;
using MercadoPago.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

        public MPAPIResponse ExecuteRequest(HttpMethod httpMethod, String uri, PayloadType payloadType, JObject payload, WebHeaderCollection colHeaders)
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


        public MPAPIResponse ExecuteRequest(HttpMethod httpMethod, String uri, PayloadType payloadType, JObject payload, WebHeaderCollection colHeaders, int retries, int connectionTimeout, int socketTimeout)
        {
            Request httpClient = null;
            WebRequest request = null;
            WebResponse response = null;

            try
            {
                httpClient = GetClient(retries, connectionTimeout, socketTimeout);
                if (colHeaders == null)
                {
                    colHeaders = new WebHeaderCollection();
                }

                httpClient = NormalizePayload(payloadType, payload, colHeaders);
                request = GetRequestMethod(httpMethod, uri, httpClient);

                foreach(KeyValuePair<string, string> item in colHeaders) {
                    httpClient.Client.Headers.Add(item.Value);
                }

                try
                {                    
                    Stream stream = httpClient.Client.OpenRead(uri);
                    StreamReader sr = new StreamReader(stream);

                    string responseData = sr.ReadToEnd();
                }
                catch (Exception e)
                {
                    throw new Exception("");
                }

                return new MPAPIResponse();
            }
            catch (Exception ex)
            {
                throw new MPRESTException(ex.Message);
            }            
        }

        /// <summary>
        /// Prepares the payload to send the request.
        /// </summary>
        /// <param name="payloadType">Type of payload (NONE, JSON, X_WWW_FORM_URLENCODED).</param>
        /// <param name="payload">The payload we will send.</param>
        /// <param name="colHeaders">Headers of the request.</param>
        /// <returns>WebClient with data to make the request.</returns>
        private Request NormalizePayload(PayloadType payloadType, JObject payload, WebHeaderCollection colHeaders)
        {            
            WebClient client = new WebClient();             
            string stringEntity = null;
            string header = "";
            if (payload.HasValues) {
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
                    foreach(KeyValuePair<string, object> item in map)
                    {
                        client.QueryString.Add(item.Key, item.Value.ToString());
                    }                    
                }
            }
                        
            if (client.Headers != null) {
                for (int i = 0; i < client.Headers.Count; ++i)
                {
                    header = client.Headers.GetKey(i);
                    colHeaders.Add(header);                    
                }
            }

            Request newRequest = new Request();

            newRequest.Client = client;
            newRequest.JsonData = stringEntity;

            return newRequest;
        }
        #endregion


        /// <summary>
        /// Get the request method we will use later.
        /// </summary>
        /// <param name="httpMethod">Http method we are trying to use in the call process.</param>
        /// <param name="uri">Uri to point.</param>
        /// <param name="entity">Data to be sent in the call.</param>
        /// <returns></returns>
        public WebRequest GetRequestMethod(HttpMethod httpMethod, string uri, Request entity = null)
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
                        if(!string.IsNullOrEmpty(entity.JsonData))
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
                    byte[] byteArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };;
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
                    byte[] byteArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };;
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


        private Request GetClient(int retries, int connectionTimeout, int socketTimeout)
        {
            Request httpClient = new Request();
            Dictionary<string, string> httpParams = new Dictionary<string, string>();                      
            
            if (connectionTimeout > 0)
            {
                httpParams.Add("CONNECTION_TIMEOUT", connectionTimeout.ToString());
            }
            if (socketTimeout > 0)
            {
                httpParams.Add("SO_TIMEOUT", socketTimeout.ToString());
            }            

            return httpClient;
        }
    }
}

