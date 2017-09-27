using MercadoPago;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test
{
    [TestFixture()]
    public class MPBaseTest : MPBase
    {    
        public static MPBaseTest Load(string id)
        {
            return (MPBaseTest)ProcessMethod("Load", id, false);
        }

        [GETEndpoint("/v1/getpath/slug")]
        public static MPBaseTest Load_all()
        {
            return (MPBaseTest)ProcessMethod("Load_all", false);
        }

        [Test()]
        public void MPBaseTest_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = Load("666");
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("No annotated method found", mpException.Message);
                return;
            }

            // should never get here
            Assert.Fail();
        }
     
        [Test()]
        public void MPBaseTest_WithAttributes_ShouldFindAttribute()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            try
            {
                var result = Load_all();
            }
            catch (MPException mpException)
            {                
                Assert.Fail();
                return;
            }

            Assert.Pass();
        }
    }

    [Idempotent]
    [TestFixture()]
    [UserToken("as987ge9ev6s5df4g32z1xv54654")]
    public class DummyClass : MPBase
    {
        public int id { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string maritalStatus { get; set; }
        public bool hasCreditCard { get; set; }

        public static DummyClass Load_all()
        {
            return (DummyClass)ProcessMethod("Load_all", false);
        }

        [GETEndpoint("/v1/getpath/load/:id")]
        public static DummyClass Load(string id)
        {
            return (DummyClass)ProcessMethod("Load", id, false);
        }

        [GETEndpoint("/v1/getpath/load/:id")]
        public static DummyClass LoadWithCache(string id, bool useCache)
        {
            return (DummyClass)ProcessMethod("Load", id, useCache);
        }

        [POSTEndpoint("/v1/postpath/slug")]
        public DummyClass Create()
        {
            return (DummyClass)ProcessMethod<DummyClass>("Create", false);
        }


        [PUTEndpoint("/v1/putpath/slug")]
        public DummyClass Update()
        {
            return (DummyClass)ProcessMethod("Update", false);
        }

        #region Cache Test
        [Test()]
        public void DummyClassMethod_RequestMustBeCachedButNotRetrievedFromCache()
        {
            var firstResult = LoadWithCache("1234", true);
            
            Assert.IsFalse(firstResult.LastApiResponse.isFromCache);
        }

        [Test()]
        public void DummyClassMethod_RequestMustBeRetrievedFromCache()
        {
            var firstResult = LoadWithCache("1234", true);
            var cachedResult = LoadWithCache("1234", true);

            Assert.IsTrue(cachedResult.LastApiResponse.isFromCache);
        }

        [Test()]
        public void DummyClassMethod_RequestMustBeRetrievedFromCacheButItsNotThere()
        {
            var firstResult = LoadWithCache("1234", true);
            var notRetrievedFromCacheResult = LoadWithCache("4567", true);

            Assert.IsFalse(notRetrievedFromCacheResult.LastApiResponse.isFromCache);
        }

        [Test()]
        public void DummyClassMethod_SeveralRequestsMustBeCached()
        {
            var firstResult = LoadWithCache("123", true);
            var secondResult = LoadWithCache("456", true);
            var thirdResult = LoadWithCache("789", true);

            var firstCachedResult = LoadWithCache("123", true);
            var secondCachedResult = LoadWithCache("456", true);
            var thirdCachedResult = LoadWithCache("789", true);            

            Assert.IsTrue(firstCachedResult.LastApiResponse.isFromCache);
            Assert.IsTrue(secondCachedResult.LastApiResponse.isFromCache);
            Assert.IsTrue(thirdCachedResult.LastApiResponse.isFromCache);
        }

        [Test()]
        public void DummyClassMethod_SeveralRequestAreNotRetrievedFromCacheInFirstAttempt()
        {
            var firstResult = LoadWithCache("123", true);
            var secondResult = LoadWithCache("456", true);
            var thirdResult = LoadWithCache("789", true);

            Assert.IsFalse(firstResult.LastApiResponse.isFromCache);
            Assert.IsFalse(secondResult.LastApiResponse.isFromCache);
            Assert.IsFalse(thirdResult.LastApiResponse.isFromCache);
        }

        [Test()]
        public void AddToCache_ShouldExecuteWithoutProblems()
        {
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://httpbin.org?mock=12345");
                MPCache.AddToCache("NewCache", new MPAPIResponse(HttpMethod.GET, request, new JObject() { }, (System.Net.HttpWebResponse)request.GetResponse()));
            }
            catch (MPException ex)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
        #endregion

        [Test()]
        public void GetAccessToken_ShouldThrowException()
        {
            try
            {
                MPCredentials.GetAccessToken();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", mpException.Message);
                return;
            }            
        }

        [Test()]
        public void DummyClassMethod_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = Load_all();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("No annotated method found", mpException.Message);
                return;
            }

            // should never get here
            Assert.Fail();
        }      

        [Test()]
        public void DummyClassMethod_WitAttributes_ShouldFindAttribute()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            try
            {
                var result = Load("1234");                
            }
            catch 
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.Pass();
        }        

        [Test()]
        public void DummyClassMethod_WitAttributes_CreateNonStaticMethodShouldFindAttribute()
        {
            DummyClass resource = new DummyClass();
            DummyClass result = new DummyClass();
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);
            try
            {
                result = resource.Create();
            }
            catch  
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.Pass();
        }

        [Test()]
        public void DummyClassMethod_Create_CheckUri()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");            

            DummyClass resource = new DummyClass();           
            resource.address = "Evergreen 123";
            resource.email = "fake@email.com";            
                        
            DummyClass result = new DummyClass();
            try
            {
                result = resource.Create();
            }
            catch
            {                
                Assert.Fail();
                return;
            }

            Assert.AreEqual("POST", result.LastApiResponse.HttpMethod);
            Assert.AreEqual("https://api.mercadopago.com/v1/postpath/slug?access_token=as987ge9ev6s5df4g32z1xv54654", result.LastApiResponse.Url);
        }

        [Test()]
        public void DummyClassMethod_Update_CheckUri()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");            

            DummyClass resource = new DummyClass();
            resource.address = "Evergreen 123";
            resource.email = "fake@email.com";

            DummyClass result = new DummyClass();
            try
            {
                result = resource.Update();
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("PUT", result.LastApiResponse.HttpMethod);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug?access_token=as987ge9ev6s5df4g32z1xv54654", result.LastApiResponse.Url);
        }

        [Test()]
        public void DummyClassMethod_WithoutClassReference()
        {
            try
            {
                var result = Load_all();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("No annotated method found", mpException.Message);
                return;
            }
            
            Assert.Fail();
        }
    }

    [TestFixture()]
    [UserToken("as987ge9ev6s5df4g32z1xv54654")]
    public class AnotherDummyClass : MPBase
    {
        [PUTEndpoint("")]
        public AnotherDummyClass Update()
        {
            return (AnotherDummyClass)ProcessMethod("Update", false);
        }

        [Test()]
        public void AnotherDummyClass_EmptyEndPoint_ShouldRaiseExcep()
        {
            AnotherDummyClass resource = new AnotherDummyClass();
            AnotherDummyClass result = new AnotherDummyClass();
            try
            {
                result = resource.Update();
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Path not found for PUT method", ex.Message);
                return;
            }

            Assert.Fail();
        }        

        [Test()]
        public void MPBase_ParsePath_ShouldReplaceParamInUrlWithValues()
        {
            DummyClass dummy = new DummyClass();
            dummy.id = 111;
            dummy.email = "person@something.com";
            dummy.address = "Evergreen 123";
            dummy.maritalStatus = "divorced";
            dummy.hasCreditCard = true;

            try
            {
                string processedPath = ParsePath("https://api.mercadopago.com/v1/getpath/slug/:id/pUnexist/:unexist", null, dummy);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No argument supplied/found for method path", ex.Message);
            }

            string processedPath0 = ParsePath("/v1/getpath/slug", null, dummy);
            Assert.AreEqual("https://api.mercadopago.com/v1/getpath/slug?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath0);

            string processedPath1 = ParsePath("/v1/putpath/slug/:id/pEmail/:email", null, dummy);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath1);

            string processedPath2 = ParsePath("/v1/putpath/slug/:id/pHasCreditCard/:hasCreditCard", null, dummy);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pHasCreditCard/True?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath2);

            string processedPath3 = ParsePath("/v1/putpath/slug/:id/pEmail/:email/pAddress/:address", null, dummy);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen 123?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath3);

            string processedPath4 = ParsePath("/v1/putpath/slug/:id/pEmail/:email/pAddress/:address/pMaritalstatus/:maritalStatus/pHasCreditCard/:hasCreditCard", null, dummy);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen 123/pMaritalstatus/divorced/pHasCreditCard/True?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath4);

        }
    }

    [Idempotent]
    [UserToken("as987ge9ev6s5df4g32z1xv54654")]
    [TestFixture()]
    public class CustomerTestClass : MPBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [POSTEndpoint("/post")]
        public CustomerTestClass Create()
        {
            return (CustomerTestClass)ProcessMethod<CustomerTestClass>("Create", false);
        }


        [Test()]
        public void CustomerTestClass_Create_ParsesCustomerTestClassObjectResponse()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.ClientId = "12346";
            SDK.ClientSecret = "456789";

            CustomerTestClass resource = new CustomerTestClass();
            resource.Name = "Bruce";
            resource.LastName = "Wayne";
            resource.Age = 45;

            CustomerTestClass result = new CustomerTestClass();
            try
            {
                result = resource.Create();
            }
            catch(Exception ex)
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("POST", result.LastApiResponse.HttpMethod);
            Assert.AreEqual("https://httpbin.org/post?access_token=as987ge9ev6s5df4g32z1xv54654", result.LastApiResponse.Url);
            Assert.AreEqual("Bruce", result.Name);
            Assert.AreEqual("Wayne", result.LastName);
            Assert.AreEqual(45, result.Age);
        }

        [Test()]
        public void CustomerTestClass_Create_CheckFullJsonResponse()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");

            CustomerTestClass resource = new CustomerTestClass();
            resource.Name = "Bruce";
            resource.LastName = "Wayne";
            resource.Age = 45;

            CustomerTestClass result = new CustomerTestClass();
            try
            {
                result = resource.Create();
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("POST", result.LastApiResponse.HttpMethod);
            Assert.AreEqual("https://httpbin.org/post?access_token=as987ge9ev6s5df4g32z1xv54654", result.LastApiResponse.Url);

            JObject jsonResponse = result.GetJsonSource();
            List<JToken> lastName = MPCoreUtils.FindTokens(jsonResponse, "LastName");
            Assert.AreEqual("Wayne", lastName.First().ToString());

            List<JToken> year = MPCoreUtils.FindTokens(jsonResponse, "Name");
            Assert.AreEqual("Bruce", year.First().ToString());
        }
    }

    [TestFixture()]
    [UserToken("as987ge9ev6s5df4g32z1xv54654")]
    public class ResourceTestClass : MPBase
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }

        [GETEndpoint("/getpath/load/:id", requestTimeout: 5, retries: 3)]
        public ResourceTestClass Load(string id)
        {
            return (ResourceTestClass)ProcessMethod("Load", id, false);
        }

        [POSTEndpoint("/post", requestTimeout: 2000, retries: 0)]
        public ResourceTestClass Create()
        {
            return (ResourceTestClass)ProcessMethod<ResourceTestClass>("Create", false);
        }

        [Test()]

        public void CustomerTestClass_Load_TimeoutFail()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            ResourceTestClass resource = new ResourceTestClass();
            ResourceTestClass result = new ResourceTestClass();

            try
            {
                result = resource.Load("567");
            }
            catch (Exception ex)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void ResourceTestClass_Create_ProperTimeoutSuccess()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");

            ResourceTestClass resource = new ResourceTestClass();
            resource.CardNumber = "123456789";
            resource.Holder = "Wayne";

            ResourceTestClass result = new ResourceTestClass();
            try
            {
                result = resource.Create();
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            JObject jsonResponse = result.GetJsonSource();
            List<JToken> lastName = MPCoreUtils.FindTokens(jsonResponse, "CardNumber");
            Assert.AreEqual("123456789", lastName.First().ToString());

            List<JToken> year = MPCoreUtils.FindTokens(jsonResponse, "Holder");
            Assert.AreEqual("Wayne", year.First().ToString());
        }
    }  
}
