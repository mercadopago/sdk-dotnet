using MercadoPago;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading;
using System.Net;

namespace MercadoPagoSDK.Test
{
    [TestFixture(Ignore = "Skipping")]
    public class MPBaseTest : MPBase
    {

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // HardCoding Credentials

            SDK.ClientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            SDK.ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET"); 
 
        }
         
        public static MPBaseTest FindById(string id, bool useCache)
        {
            return (MPBaseTest)ProcessMethod<MPBaseTest>("FindById", id, false);
        }

        [GETEndpoint("/v1/getpath/slug")]
        public static List<MPBaseTest> All()
        {
            return ProcessMethodBulk<MPBaseTest>(typeof(MPBase), "All", false);
        }

        [Test()]
        public void MPBaseTest_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = MPBaseTest.FindById("666", false);
                Assert.Fail();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("No annotated method found", mpException.Message); 
            }
 
        }

        [Test()]
        public void MPBaseTest_WithAttributes_ShouldFindAttribute()
        {
            try
            {
                var result = All();
                Assert.Pass();
            }
            catch 
            {
                Assert.Fail(); 
            }
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

        public static DummyClass All()
        {
            return (DummyClass)ProcessMethod("All", false);
        }

        [GETEndpoint("/get/:id")]
        public static DummyClass FindById(string id, bool useCache)
        {
            return (DummyClass)ProcessMethod<DummyClass>("FindById", id, useCache);
        }

        [POSTEndpoint("/post")]
        public DummyClass Save()
        {
            return (DummyClass)ProcessMethod<DummyClass>("Save", false);
        }


        [PUTEndpoint("/put")]
        public DummyClass Update()
        {
            return (DummyClass)ProcessMethod<DummyClass>("Update", false);
        }

        #region Cache Test

        [Test()]
        public void DummyClassMethod_RequestMustBeCachedButNotRetrievedFromCache()
        {
            SDK.CleanConfiguration();
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id = new Random().Next(0, int.MaxValue).ToString();

            SDK.SetBaseUrl("https://httpbin.org");

            var firstResult = DummyClass.FindById(id, true);
            Assert.IsFalse(firstResult.GetLastApiResponse().IsFromCache);
        }

        [Test()]
        public void DummyClassMethod_RequestMustBeRetrievedFromCache()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id = new Random().Next(0, int.MaxValue).ToString();

            var firstResult = DummyClass.FindById(id, true);

            Thread.Sleep(1000);

            var cachedResult = DummyClass.FindById(id, true);

            Assert.IsTrue(cachedResult.GetLastApiResponse().IsFromCache);
        }

        [Test()]
        public void DummyClassMethod_RequestMustBeRetrievedFromCacheButItsNotThere()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id1 = (new Random().Next(0, int.MaxValue) - 78).ToString();
            string id2 = (new Random().Next(0, int.MaxValue) - 3).ToString();

            var firstResult = DummyClass.FindById(id1, true);

            Thread.Sleep(1000);

            var notRetrievedFromCacheResult = DummyClass.FindById(id2, true);

            Assert.IsFalse(notRetrievedFromCacheResult.GetLastApiResponse().IsFromCache);
        }

        [Test()]
        public void DummyClassMethod_SeveralRequestsMustBeCached()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id1 = (new Random().Next(0, int.MaxValue) - 5).ToString();
            string id2 = (new Random().Next(0, int.MaxValue) - 88).ToString();
            string id3 = (new Random().Next(0, int.MaxValue) - 9).ToString();

            var firstResult = DummyClass.FindById(id1, true);
            var secondResult = DummyClass.FindById(id2, true);
            var thirdResult = DummyClass.FindById(id3, true);

            Thread.Sleep(1000);

            var firstCachedResult = DummyClass.FindById(id1, true);
            var secondCachedResult = DummyClass.FindById(id2, true);
            var thirdCachedResult = DummyClass.FindById(id3, true);

            Assert.IsTrue(firstCachedResult.GetLastApiResponse().IsFromCache);
            Assert.IsTrue(secondCachedResult.GetLastApiResponse().IsFromCache);
            Assert.IsTrue(thirdCachedResult.GetLastApiResponse().IsFromCache);
        }

        [Test()]
        public void DummyClassMethod_SeveralRequestAreNotRetrievedFromCacheInFirstAttempt()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id1 = (new Random().Next(0, int.MaxValue) - 15).ToString();
            string id2 = (new Random().Next(0, int.MaxValue) - 666).ToString();
            string id3 = (new Random().Next(0, int.MaxValue) - 71).ToString();


            var firstResult = DummyClass.FindById(id1, true);
            var secondResult = DummyClass.FindById(id2, true);
            var thirdResult = DummyClass.FindById(id3, true);

            Assert.IsFalse(firstResult.GetLastApiResponse().IsFromCache);
            Assert.IsFalse(secondResult.GetLastApiResponse().IsFromCache);
            Assert.IsFalse(thirdResult.GetLastApiResponse().IsFromCache);
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
                SDK.CleanConfiguration();
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
                var result = All();
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
        public void DummyClassMethod_WitAttributes_CreateNonStaticMethodShouldFindAttribute()
        {
            DummyClass resource = new DummyClass();
            DummyClass result = new DummyClass();
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            config.Add("accessToken", Environment.GetEnvironmentVariable("ACCESS_TOKEN"));
            SDK.SetConfiguration(config);

            try
            {
                result = resource.Save();
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
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            DummyClass resource = new DummyClass();
            resource.address = "Evergreen 123";
            resource.email = "fake@email.com";

            DummyClass result = new DummyClass();
            try
            {
                result = resource.Save();
            }
            catch
            {
                Assert.Fail();
                return;
            }

            Assert.AreEqual("POST", result.GetLastApiResponse().HttpMethod);

            Assert.AreEqual(string.Format("https://httpbin.org/post?access_token={0}", Environment.GetEnvironmentVariable("ACCESS_TOKEN")), result.GetLastApiResponse().Url);
        }

        [Test()]
        public void DummyClassMethod_Update_CheckUri()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

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

            Assert.AreEqual("PUT", result.GetLastApiResponse().HttpMethod);
            Assert.AreEqual("https://httpbin.org/put?access_token=" + Environment.GetEnvironmentVariable("ACCESS_TOKEN"), result.GetLastApiResponse().Url);
        }

        [Test()]
        public void DummyClassMethod_WithoutClassReference()
        {
            try
            {
                var result = All();
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
            SDK.CleanConfiguration();
            SDK.AccessToken = "as987ge9ev6s5df4g32z1xv54654";
            DummyClass dummy = new DummyClass();
            dummy.id = 111;
            dummy.email = "person@something.com";
            dummy.address = "Evergreen123";
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
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen123?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath3);

            string processedPath4 = ParsePath("/v1/putpath/slug/:id/pEmail/:email/pAddress/:address/pMaritalstatus/:maritalStatus/pHasCreditCard/:hasCreditCard", null, dummy);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen123/pMaritalstatus/divorced/pHasCreditCard/True?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath4);

        }
    }
   
    [TestFixture()]
    [UserToken("as987ge9ev6s5df4g32z1xv54654")]
    public class ResourceTestClass : MPBase
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }

        [GETEndpoint("/getpath/load/:id", requestTimeout: 5000, retries: 3)]
        public ResourceTestClass Load(string id)
        {
            return (ResourceTestClass)ProcessMethod<ResourceTestClass>("FindById", id, false);
        }

        [POSTEndpoint("/post", requestTimeout: 6000, retries: 0)]
        public ResourceTestClass Save()
        {
            return (ResourceTestClass)ProcessMethod<ResourceTestClass>("Save", false);
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
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            ResourceTestClass resource = new ResourceTestClass();
            resource.CardNumber = "123456789";
            resource.Holder = "Wayne";

            ResourceTestClass result = new ResourceTestClass();
            try
            {
                result = resource.Save();
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
