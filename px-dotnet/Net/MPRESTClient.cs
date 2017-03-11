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


        public MPAPIResponse ExecuteRequest(HttpMethod httpMethod, string uri, PayloadType payloadType, JObject payload, WebHeaderCollection colHeaders, int retries, int connectionTimeout, int socketTimeout)
        {
            try
            {

                if (httpMethod == HttpMethod.GET)
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                    request.Method = "GET";

                    String result = string.Empty;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        result = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();

                        return new MPAPIResponse(result);
                    }
                }


                if (httpMethod == HttpMethod.POST)
                {
                    string postData = "param1=value1sended&param2=value2sended";

                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                    request.Method = "POST";

                    byte[] data = Encoding.ASCII.GetBytes(postData);

                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    Stream responseStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(responseStream, Encoding.Default);

                    string result = reader.ReadToEnd();

                    reader.Close();
                    responseStream.Close();

                    response.Close();

                    return new MPAPIResponse(result);
                }

                throw new MPRESTException("Method not foud");
            }
            catch (Exception ex)
            {
                throw new MPRESTException(ex.Message);
            }
        }

        #endregion
    }
}

