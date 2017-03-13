using MercadoPago;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections.Specialized;

namespace MercadoPago
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

        public MPRESTClient(string proxyHostName, int proxyPort)
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

        public MPAPIResponse ExecuteRequest(
            HttpMethod httpMethod, 
            string uri,
            PayloadType payloadType, 
            JObject payload, 
            WebHeaderCollection colHeaders, 
            int retries, 
            int connectionTimeout, 
            int socketTimeout)
        {
            try
            {
                MPRequest mpRequest = CreateRequest(httpMethod, uri, payloadType, payload, colHeaders);
                string result = string.Empty;

                if (new HttpMethod[] { HttpMethod.GET, HttpMethod.DELETE }.Contains(httpMethod))
                {
                    using (HttpWebResponse response = (HttpWebResponse)mpRequest.Request.GetResponse())
                    {
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        result = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                        return new MPAPIResponse(result);
                    }
                }

                if (new  HttpMethod[] { HttpMethod.POST, HttpMethod.PUT }.Contains(httpMethod))
                {
                    Stream requestStream = mpRequest.Request.GetRequestStream();
                    requestStream.Write(mpRequest.RequestPayload, 0, mpRequest.RequestPayload.Length);
                    requestStream.Close();

                    using (HttpWebResponse response = (HttpWebResponse)mpRequest.Request.GetResponse())
                    {                              
                        Stream responseStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(responseStream, Encoding.Default);
                        result = reader.ReadToEnd();

                        reader.Close();
                        responseStream.Close();
                    }

                    return new MPAPIResponse(result);
                }

                throw new MPRESTException("Method not foud");
            }
            catch (Exception ex)
            {
                throw new MPRESTException(ex.Message);
            }
        }

        public MPRequest CreateRequest(HttpMethod httpMethod,
            string uri,
            PayloadType payloadType,
            JObject payload,
            WebHeaderCollection colHeaders)
        {

            if (string.IsNullOrEmpty(uri))
                throw new MPRESTException("Uri can not be an empty string.");

            if (httpMethod.Equals(HttpMethod.GET))
            {
                if (payload != null)
                {
                    throw new MPRESTException("Payload not supported for this method.");
                }
            }
            else if (httpMethod.Equals(HttpMethod.POST))
            {
                if (payload == null)
                {
                    throw new MPRESTException("Must include payload for this method.");
                }
            }
            else if (httpMethod.Equals(HttpMethod.PUT))
            {
                if (payload == null)
                {
                    throw new MPRESTException("Must include payload for this method.");
                }
            }
            else if (httpMethod.Equals(HttpMethod.DELETE))
            {
                if (payload != null)
                {
                    throw new MPRESTException("Payload not supported for this method.");
                }
            }

            MPRequest mpRequest = new MPRequest();
            mpRequest.Request = (HttpWebRequest)HttpWebRequest.Create(uri);
            mpRequest.Request.Method = httpMethod.ToString();

            if (payload != null) // POST & PUT
            {
                byte[] data = null;
                if(payloadType != PayloadType.JSON)
                {
                    var parametersDict = payload.ToObject<Dictionary<string, string>>();
                    StringBuilder parametersString = new StringBuilder();
                    parametersString.Append(string.Format("{0}={1}", parametersDict.First().Key, parametersDict.First().Value));
                    parametersDict.Remove(parametersDict.First().Key);
                    foreach (var value in parametersDict)
                    {
                        parametersString.Append(string.Format("&{0}={1}", value.Key, value.Value));
                    }

                    data = Encoding.ASCII.GetBytes(parametersString.ToString());
                }
                else
                {
                    data = Encoding.ASCII.GetBytes(payload.ToString());
                }
                                
                mpRequest.Request.ContentLength = data.Length;
                mpRequest.Request.ContentType = payloadType == PayloadType.JSON ? "application/json" : "application/x-www-form-urlencoded";
                mpRequest.RequestPayload = data;
            }

            return mpRequest;
        }
               
        #endregion
    }
}

