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

namespace MercadoPagoSDK.Test
{
    [TestFixture()]
    public class MPRESTClientTest : MPRESTClient
    {

        [Test()]
        public void ExecuteRequest_GetAndDeleteNustNotHavePayload()
        {
            MPRESTClient client = new MPRESTClient();
            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.GET, "https://httpbin.org/get", PayloadType.X_WWW_FORM_URLENCODED, new JObject(), null);
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Payload not supported for this method.", ex.Message);
            }

            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.DELETE, "https://httpbin.org/delete", PayloadType.X_WWW_FORM_URLENCODED, new JObject(), null);
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
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.X_WWW_FORM_URLENCODED, null, null);
            }
            catch (MPRESTException ex)
            {
                Assert.AreEqual("Must include payload for this method.", ex.Message);
            }

            try
            {
                MPAPIResponse response = client.ExecuteRequest(HttpMethod.PUT, "https://httpbin.org/put", PayloadType.X_WWW_FORM_URLENCODED, null, null);
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
            MPAPIResponse response = client.ExecuteRequest(HttpMethod.GET, "https://httpbin.org/get", PayloadType.X_WWW_FORM_URLENCODED, null, null);
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

            MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.X_WWW_FORM_URLENCODED, jsonObject, null);
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

            MPAPIResponse response = client.ExecuteRequest(HttpMethod.POST, "https://httpbin.org/post", PayloadType.JSON, jsonObject, null);
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
                DummyClass objectToValidate = new DummyClass("Payment description", DateTime.Now, -1000);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("There are errors in the object you're trying to create. Review them to continue: -CODE 31-Transaction amount must be greather than 0.", ex.Message);
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

        [TestFixture()]
        public class DummyClass : MPBase
        {
            [Required(ErrorMessage = "-CODE 10-Payment description is not present.")]
            [RegularExpression(@"^(?:.*[a-z]){7,}$", ErrorMessage = "-CODE 11- Payment description length must have at least 7 characters.")]
            public string Description { get; set; }
            [Required(ErrorMessage = "-CODE 20-Payment date is not present.")]
            [DataType(DataType.Date, ErrorMessage = "-CODE 21-Payment date format has an incorrect format or value.")]
            public DateTime PaymentDate { get; set; }
            [Required(ErrorMessage = "-CODE 30-TransactionAmount is not present.")]
            [System.ComponentModel.DataAnnotations.Range(0.0, Double.MaxValue, ErrorMessage = "-CODE 31-Transaction amount must be greather than 0.")]
            public double TransactionAmount { get; set; }

            public DummyClass(string description, DateTime date, double transationAmount)
            {
                Description = description;
                PaymentDate = date;
                TransactionAmount = transationAmount;

                Validate(this);
            }
        }
    }
}
