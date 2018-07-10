using MercadoPago;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using ValidationRange = System.ComponentModel.DataAnnotations.RangeAttribute;

namespace MercadoPagoSDK.Test
{
    [TestFixture()]
    internal class MPRESTClientTest : MPRESTClient
    {

        [Test()]
        public void ExecuteRequest_GetAndDeleteNustNotHavePayload()
        {
            MPRESTClient client = new MPRESTClient();
            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.GET, "https://httpbin.org/get", PayloadType.X_WWW_FORM_URLENCODED, new JObject(), null, 0 , 0);
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Payload not supported for this method.", ex.Message);
            }

            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.DELETE, "https://httpbin.org/delete", PayloadType.X_WWW_FORM_URLENCODED, new JObject(), null, 0, 0);
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Payload not supported for this method.", ex.Message);
            }
        }

        [Test()]
        public void ExecuteRequest_PostAndPutMustHavePayload()
        {
            MPRESTClient client = new MPRESTClient();
            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.X_WWW_FORM_URLENCODED, null, null, 0, 0);
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Must include payload for this method.", ex.Message);
            }

            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.PUT, "https://httpbin.org/put", PayloadType.X_WWW_FORM_URLENCODED, null, null, 0, 0);
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Must include payload for this method.", ex.Message);
            }
        }

        [Test()]
        public void ExecuteRequest_Get()
        {
            MPRESTClient client = new MPRESTClient();
            MPAPIResponse response = client.ExecuteRequest(HttpMethod.GET, "https://httpbin.org/get", PayloadType.X_WWW_FORM_URLENCODED, null, null, 0, 0);
            JObject jsonResponse = JObject.Parse(response.StringResponse.ToString());
            JProperty prop = jsonResponse.Properties().FirstOrDefault(p => p.Name.Contains("url"));
            string url = prop != null ? prop.Value.ToString() : string.Empty;

            Assert.AreEqual("https://httpbin.org/get", url);
        }

        [Test()]
        public void ExecuteRequest_Post()
        {
            MPRESTClient client = new MPRESTClient();

            var jsonObject = new JObject();
            jsonObject.Add("firstName", "Clark");
            jsonObject.Add("lastName", "Kent");
            jsonObject.Add("year", 2018);

            MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.X_WWW_FORM_URLENCODED, jsonObject, null, 0, 0);
            JObject jsonResponse = JObject.Parse(response.StringResponse.ToString());

            List<JToken> contentType = MPCoreUtils.FindTokens(jsonResponse, "Content-Type");
            Assert.AreEqual("application/x-www-form-urlencoded", contentType.First().ToString());
        }

        [Test()]
        public void ExecuteRequest_Post_Json()
        {
            MPRESTClient client = new MPRESTClient();

            var jsonObject = new JObject();
            jsonObject.Add("firstName", "Clark");
            jsonObject.Add("lastName", "Kent");
            jsonObject.Add("year", 2018);

            DummyClass dummy = new DummyClass("Dummy description", DateTime.Now, 1000);

            WebHeaderCollection headers = new WebHeaderCollection();

            headers.Add("x-idempotency-key", dummy.GetType().GUID.ToString());


            MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.JSON, jsonObject, headers, 0, 0);
            JObject jsonResponse = JObject.Parse(response.StringResponse.ToString());

            List<JToken> lastName = MPCoreUtils.FindTokens(jsonResponse, "lastName");
            Assert.AreEqual("Kent", lastName.First().ToString());

            List<JToken> year = MPCoreUtils.FindTokens(jsonResponse, "year");
            Assert.AreEqual("2018", year.First().ToString());
        }

        [Test()]
        public void ClassIntance_ShouldThrowValidationException()
        {
            try
            {
                DummyClass objectToValidate = new DummyClass("Pay", DateTime.Now, -1000);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(@"There are errors in the object you're trying to create. Review them to continue: Error on property Description. " +
                                "The specified value is not valid. RegExp: ^(?:.*[a-z]){7,}$ . " +
                                "Error on property TransactionAmount. The value you are trying to assign is not in the specified range. ", ex.Message);
            }

            Assert.Pass();
        }

        [Test()]
        public void ClassIntance_ShouldPass()
        {
            try
            {
                DummyClass objectToValidate = new DummyClass("Payment description", DateTime.Now, 1000);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("There are errors in the object you're trying to create. Review them to continue: -CODE 31-Transaction amount must be greather than 0.", ex.Message);
            }

            Assert.Pass();
        }

        [Test()]
        public void IdempotentKey_MustBePresent()
        {
            DummyClass dummy = new DummyClass("Dummy description", DateTime.Now, 1000);

            Assert.IsNotEmpty(dummy.GetType().GUID.ToString());
        }

        [Test()]
        public void ExecuteRequest_Post_MPAPIRequestResponseParser()
        {
            MPRESTClient client = new MPRESTClient();

            var jsonObject = new JObject();
            jsonObject.Add("firstName", "Comander");
            jsonObject.Add("lastName", "Shepard");
            jsonObject.Add("year", 2126);

            MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.JSON, jsonObject, null, 0, 0);

            Assert.AreEqual(200, response.StatusCode);

            JObject jsonResponse = response.JsonObjectResponse;
            List<JToken> lastName = MPCoreUtils.FindTokens(jsonResponse, "lastName");
            Assert.AreEqual("Shepard", lastName.First().ToString());

            List<JToken> year = MPCoreUtils.FindTokens(jsonResponse, "year");
            Assert.AreEqual("2126", year.First().ToString());
        }

        [Test()]
        public void ExecuteRequest_Get_ShortTimeoutWillFail()
        {
            MPRESTClient client = new MPRESTClient();

            var jsonObject = new JObject();
            jsonObject.Add("firstName", "Comander");
            jsonObject.Add("lastName", "Shepard");
            jsonObject.Add("year", 2126);

            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.JSON, jsonObject, null, 5, 0);
            }
            catch
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test()]
        public void ExecuteRequest_Get_ProperTimeoutWillWork()
        {
            MPRESTClient client = new MPRESTClient();

            var jsonObject = new JObject();
            jsonObject.Add("firstName", "Comander");
            jsonObject.Add("lastName", "Shepard");
            jsonObject.Add("year", 2126);

            MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.JSON, jsonObject, null, 20000, 0);

            Assert.AreEqual(200, response.StatusCode);

            JObject jsonResponse = response.JsonObjectResponse;
            List<JToken> lastName = MPCoreUtils.FindTokens(jsonResponse, "lastName");
            Assert.AreEqual("Shepard", lastName.First().ToString());

            List<JToken> year = MPCoreUtils.FindTokens(jsonResponse, "year");
            Assert.AreEqual("2126", year.First().ToString());
        }

        [Idempotent]
        [TestFixture()]
        public class DummyClass : ResourceBase
        {
            [Required]
            [RegularExpression(@"^(?:.*[a-z]){7,}$")]
            public string Description { get; set; }
            [Required]
            [DataType(DataType.Date)]
            public DateTime PaymentDate { get; set; }
            [Required]
            [ValidationRange(0.0, Double.MaxValue)]
            public double TransactionAmount { get; set; }

            public DummyClass(string description, DateTime date, double transationAmount)
            {
                Description = description;
                PaymentDate = date;
                TransactionAmount = transationAmount;

                //Validate(this);
            }                       
        }
    }
}
