using MercadoPago;
using MercadoPago.Core;
using MercadoPago.Core.Annotations;
using MercadoPago.Exceptions;
using MercadoPago.Net;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MercadoPagoSDK.Test.Net
{
    [TestFixture()]
    public class MPRESTClientTest : MPRESTClient
    {
        #region Variables
        public MPRESTClient client { get; set; }
        public WebRequest request { get; set; }
        public  WebRequest requestDelete { get; set; }
        public WebRequest requestPost { get; set; }
        public WebRequest requestPut { get; set; }
        public WebRequest requestGet { get; set; }
        #endregion

        #region GetRequestMethod
        public MPRESTClientTest()
        {
            client = new MPRESTClient();    
        }

        [Test()]
        public void GetRequestMethod_ShouldBePOST()
        {
            WebRequest request = client.GetRequestMethod(HttpMethod.POST, "http://www.google.com", new Request());

            Assert.AreEqual(request.Method, "POST");
        }

        [Test()]
        public void GetRequestMethod_ShouldBePUT()
        {
            WebRequest request = client.GetRequestMethod(HttpMethod.PUT, "http://www.google.com", new Request());

            Assert.AreEqual(request.Method, "PUT");
        }

        [Test()]
        public void GetRequestMethod_ShouldBeGET()
        {
            WebRequest request = client.GetRequestMethod(HttpMethod.GET, "http://www.google.com");

            Assert.AreEqual(request.Method, "GET");
        }

        [Test()]
        public void GetRequestMethod_ShouldBeDELETE()
        {
            WebRequest request = client.GetRequestMethod(HttpMethod.DELETE, "http://www.google.com");

            Assert.AreEqual(request.Method, "DELETE");
        }

        [Test()]
        public void GetRequestMethod_DELETEAndGETShouldThrowException()
        {
            try
            {
                requestDelete = client.GetRequestMethod(HttpMethod.DELETE, "http://www.google.com", new Request());
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Payload not supported for this method.", ex.Message);    
            }

            try
            {
                requestGet = client.GetRequestMethod(HttpMethod.GET, "http://www.google.com", new Request());
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Payload not supported for this method.", ex.Message);    
            }                       
        }

        [Test()]
        public void GetRequestMethod_POSTAndPUTShouldThrowException()
        {
            try
            {
                requestPost = client.GetRequestMethod(HttpMethod.POST, "http://www.google.com", new Request());
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Must include payload for this method.", ex.Message);
            }

            try
            {
                WebRequest requestPut = client.GetRequestMethod(HttpMethod.PUT, "http://www.google.com", new Request());
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Must include payload for this method.", ex.Message);
            }                                           
        }

        [Test()]
        public void GetRequestMethod_ShouldThrowEmptyOrNullUriException()
        {
            try
            {
                WebRequest request = client.GetRequestMethod(HttpMethod.GET, "", new Request());
            }
            catch(MPRESTException ex)
            {
                Assert.AreEqual("Uri can not be an empty String.", ex.Message);
            }
        }
        #endregion

        [Test()]
        public void ExecuteRequest_MockData()
        {
            var response = client.ExecuteRequest(HttpMethod.GET, "http://mockbin.com/request?foo=bar&foo=baz", PayloadType.JSON, new JObject(), new WebHeaderCollection());            
        }
    }
}
