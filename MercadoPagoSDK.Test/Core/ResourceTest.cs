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
    [TestFixture]
    public class ResourceTest : Resource<ResourceTest>
    {

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // HardCoding Credentials
            SDK.CleanConfiguration();
            SDK.ClientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            SDK.ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
        }

        public static ResourceTest FindById(string id, bool useCache) => Get(null, useCache);

        public static List<ResourceTest> All() => GetList("/v1/identification_types");
        
        [Test]
        public void ResourceTest_WithNoPath_ShouldraiseException()
        {
            try
            {
                var result = FindById("666", false);
                Assert.Fail();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("Must specify a valid path.", mpException.Message);
            }
        }

        [Test]
        public void ResourceTest_WithValidPath_ShouldBeOk()
        {
            try
            {
                var result = All();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }

    [Idempotent]
    [TestFixture]
    //[UserToken("as987ge9ev6s5df4g32z1xv54654")]
    public class DummyClass : Resource<DummyClass>
    {
        //public DummyClass()
        //{
        //    UserAccessToken = "as987ge9ev6s5df4g32z1xv54654";
        //}

        public int id { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string maritalStatus { get; set; }
        public bool hasCreditCard { get; set; }

        public static DummyClass All() => Get(null);

        public static DummyClass FindById(string id, bool useCache) => Get($"/anything/{id}", useCache);

        public DummyClass Save() => Post("/post");

        public DummyClass Update() => Put("/put");

        #region Cache Test

        [Test]
        public void DummyClassMethod_RequestMustBeCachedButNotRetrievedFromCache()
        {
            SDK.CleanConfiguration();
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id = new Random().Next(0, int.MaxValue).ToString();

            SDK.SetBaseUrl("https://httpbin.org");

            var firstResult = FindById(id, true);
            Assert.IsFalse(firstResult.LastApiResponse.IsFromCache);
        }

        [Test]
        public void DummyClassMethod_RequestMustBeRetrievedFromCache()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id = new Random().Next(0, int.MaxValue).ToString();

            var firstResult = FindById(id, true);

            Thread.Sleep(1000);

            var cachedResult = FindById(id, true);

            Assert.IsTrue(cachedResult.LastApiResponse.IsFromCache);
        }

        [Test]
        public void DummyClassMethod_RequestMustBeRetrievedFromCacheButItsNotThere()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id1 = (new Random().Next(0, int.MaxValue) - 78).ToString();
            string id2 = (new Random().Next(0, int.MaxValue) - 3).ToString();

            var firstResult = FindById(id1, true);

            Thread.Sleep(1000);

            var notRetrievedFromCacheResult = FindById(id2, true);

            Assert.IsFalse(notRetrievedFromCacheResult.LastApiResponse.IsFromCache);
        }

        [Test]
        public void DummyClassMethod_SeveralRequestsMustBeCached()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id1 = (new Random().Next(0, int.MaxValue) - 5).ToString();
            string id2 = (new Random().Next(0, int.MaxValue) - 88).ToString();
            string id3 = (new Random().Next(0, int.MaxValue) - 9).ToString();

            var firstResult = FindById(id1, true);
            var secondResult = FindById(id2, true);
            var thirdResult = FindById(id3, true);

            Thread.Sleep(1000);

            var firstCachedResult = FindById(id1, true);
            var secondCachedResult = FindById(id2, true);
            var thirdCachedResult = FindById(id3, true);

            Assert.IsTrue(firstCachedResult.LastApiResponse.IsFromCache);
            Assert.IsTrue(secondCachedResult.LastApiResponse.IsFromCache);
            Assert.IsTrue(thirdCachedResult.LastApiResponse.IsFromCache);
        }

        [Test]
        public void DummyClassMethod_SeveralRequestAreNotRetrievedFromCacheInFirstAttempt()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            string id1 = (new Random().Next(0, int.MaxValue) - 15).ToString();
            string id2 = (new Random().Next(0, int.MaxValue) - 666).ToString();
            string id3 = (new Random().Next(0, int.MaxValue) - 71).ToString();


            var firstResult = FindById(id1, true);
            var secondResult = FindById(id2, true);
            var thirdResult = FindById(id3, true);

            Assert.IsFalse(firstResult.LastApiResponse.IsFromCache);
            Assert.IsFalse(secondResult.LastApiResponse.IsFromCache);
            Assert.IsFalse(thirdResult.LastApiResponse.IsFromCache);
        }

        [Test]
        public void AddToCache_ShouldExecuteWithoutProblems()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://httpbin.org?mock=12345");
                MPCache.AddToCache("NewCache", new MPAPIResponse(HttpMethod.GET, request, new JObject() { }, (HttpWebResponse)request.GetResponse()));
            }
            catch (MPException ex)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
        #endregion

        [Test]
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

        [Test]
        public void DummyClassMethod_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = All();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("Must specify a valid path.", mpException.Message);
                return;
            }

            // should never get here
            Assert.Fail();
        }

        [Test]
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

        [Test]
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

            Assert.AreEqual("POST", result.LastApiResponse.HttpMethod);

            Assert.AreEqual(string.Format("https://httpbin.org/post?access_token={0}", Environment.GetEnvironmentVariable("ACCESS_TOKEN")), result.LastApiResponse.Url);
        }

        [Test]
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

            Assert.AreEqual("PUT", result.LastApiResponse.HttpMethod);
            Assert.AreEqual("https://httpbin.org/put?access_token=" + Environment.GetEnvironmentVariable("ACCESS_TOKEN"), result.LastApiResponse.Url);
        }

        [Test]
        public void DummyClassMethod_WithoutClassReference()
        {
            try
            {
                var result = All();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("Must specify a valid path.", mpException.Message);
                return;
            }

            Assert.Fail();
        }
    }

    [TestFixture]
    //[UserToken("as987ge9ev6s5df4g32z1xv54654")]
    public class AnotherDummyClass : Resource<AnotherDummyClass>
    {
        public AnotherDummyClass Update() => Put("");

        [Test]
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
                Assert.AreEqual("Must specify a valid path.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void MPBase_ParsePath_ShouldReplaceParamInUrlWithValues()
        {
            SDK.CleanConfiguration();
            SDK.AccessToken = "as987ge9ev6s5df4g32z1xv54654";

            var dummy = new DummyClass
            {
                id = 111,
                email = "person@something.com",
                address = "Evergreen 123",
                maritalStatus = "divorced",
                hasCreditCard = true
            };

            try
            {
                string processedPath = CreatePath("https://api.mercadopago.com/v1/getpath/slug/:id/pUnexist/:unexist", null, null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No argument supplied/found for method path", ex.Message);
            }

            string processedPath0 = CreatePath("/v1/getpath/slug", null, null);
            Assert.AreEqual("https://api.mercadopago.com/v1/getpath/slug?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath0);

            string processedPath1 = CreatePath($"/v1/putpath/slug/{dummy.id}/pEmail/{dummy.email}", null, null);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath1);

            string processedPath2 = CreatePath($"/v1/putpath/slug/{dummy.id}/pHasCreditCard/{dummy.hasCreditCard}", null, null);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pHasCreditCard/True?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath2);

            string processedPath3 = CreatePath($"/v1/putpath/slug/{dummy.id}/pEmail/{dummy.email}/pAddress/{dummy.address}", null, null);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen 123?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath3);

            string processedPath4 = CreatePath($"/v1/putpath/slug/{dummy.id}/pEmail/{dummy.email}/pAddress/{dummy.address}/pMaritalstatus/{dummy.maritalStatus}/pHasCreditCard/{dummy.hasCreditCard}", null, null);
            Assert.AreEqual("https://api.mercadopago.com/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen 123/pMaritalstatus/divorced/pHasCreditCard/True?access_token=as987ge9ev6s5df4g32z1xv54654", processedPath4);

        }
    }

    [TestFixture]
    //[UserToken("as987ge9ev6s5df4g32z1xv54654")]
    public class ResourceTestClass : Resource<ResourceTestClass>
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }

        public ResourceTestClass Load(string id) => Get($"/delay/{id}", requestTimeout: 5000, retries: 3);

        public ResourceTestClass Save() => Post("/post", requestTimeout: 6000, retries: 0);

        [Test]
        public void CustomerTestClass_Load_TimeoutFail()
        {
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://httpbin.org");
            SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

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

        [Test]
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
            List<JToken> lastName = MPCoreUtils.FindTokens(jsonResponse, "card_number");
            Assert.AreEqual("123456789", lastName.First().ToString());

            List<JToken> year = MPCoreUtils.FindTokens(jsonResponse, "holder");
            Assert.AreEqual("Wayne", year.First().ToString());
        }
    }
}
