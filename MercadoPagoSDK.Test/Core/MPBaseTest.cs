using MercadoPago;
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
        public static MPBaseTest load(string id)
        {
            return (MPBaseTest)MPBaseTest.ProcessMethod("load", id, false);
        }

        [GETEndpoint("/v1/getpath/slug")]
        public static MPBaseTest load_all()
        {
            return (MPBaseTest)MPBaseTest.ProcessMethod("load_all", false);
        }

        [Test()]
        public void MPBaseTest_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = MPBaseTest.load("666");
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
        public void MPBaseTest_WitAttributes_ShouldFindAttribute()
        {
            try
            {
                var result = MPBaseTest.load_all();
            }
            catch (MPException mpException)
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.Pass();
        }
    }

    [TestFixture()]
    public class DummyClass : MPBase
    {
        public int id { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string maritalStatus { get; set; }
        public bool hasCreditCard { get; set; }

        public static DummyClass load_all()
        {
            return (DummyClass)DummyClass.ProcessMethod("load_all", false);
        }

        [GETEndpoint("/v1/getpath/load/:id")]
        public static DummyClass load(string id)
        {
            return (DummyClass)DummyClass.ProcessMethod("load", id, false);
        }

        [POSTEndpoint("/v1/postpath/slug")]
        public DummyClass create()
        {
            return (DummyClass)base.ProcessMethod<DummyClass>("create", false);
        }


        [PUTEndpoint("/v1/putpath/slug")]
        public DummyClass update()
        {
            return (DummyClass)DummyClass.ProcessMethod("update", false);
        }

        [Test()]
        public void DummyClassMethod_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = DummyClass.load_all();
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
            try
            {
                var result = DummyClass.load("1234");
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
            try
            {
                result = resource.create();
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
            DummyClass resource = new DummyClass();
            DummyClass result = new DummyClass();
            try
            {
                result = resource.create();
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("POST", result.Method);
            Assert.AreEqual("/v1/postpath/slug", result.Url);
            Assert.AreEqual("DummyClass", result.Instance);
        }

        [Test()]
        public void DummyClassMethod_Update_CheckUri()
        {
            DummyClass resource = new DummyClass();
            DummyClass result = new DummyClass();
            try
            {
                result = resource.update();
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("PUT", result.Method);
            Assert.AreEqual("/v1/putpath/slug", result.Url);
            Assert.AreEqual("DummyClass", result.Instance);
        }

        [Test()]
        public void DummyClassMethod_WithoutClassReference()
        {
            try
            {
                var result = DummyClass.load_all();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("No annotated method found", mpException.Message);
                return;
            }

            // should never get here
            Assert.Fail();
        }
    }

    [TestFixture()]
    public class AnotherDummyClass : MPBase
    {
        [PUTEndpoint("")]
        public AnotherDummyClass update()
        {
            return (AnotherDummyClass)AnotherDummyClass.ProcessMethod("update", false);
        }

        [Test()]
        public void AnotherDummyClass_EmptyEndPoint_ShouldRaiseExcep()
        {
            AnotherDummyClass resource = new AnotherDummyClass();
            AnotherDummyClass result = new AnotherDummyClass();
            try
            {
                result = resource.update();
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
                string processedPath = MPBase.ParsePath("/v1/getpath/slug/:id/pUnexist/:unexist", null, dummy);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No argument supplied/found for method path", ex.Message);
            }


            string processedPath0 = MPBase.ParsePath("/v1/getpath/slug", null, dummy);
            Assert.AreEqual("/v1/getpath/slug", processedPath0);

            string processedPath1 = MPBase.ParsePath("/v1/putpath/slug/:id/pEmail/:email", null, dummy);
            Assert.AreEqual("/v1/putpath/slug/111/pEmail/person@something.com", processedPath1);

            string processedPath2 = MPBase.ParsePath("/v1/putpath/slug/:id/pHasCreditCard/:hasCreditCard", null, dummy);
            Assert.AreEqual("/v1/putpath/slug/111/pHasCreditCard/True", processedPath2);

            string processedPath3 = MPBase.ParsePath("/v1/putpath/slug/:id/pEmail/:email/pAddress/:address", null, dummy);
            Assert.AreEqual("/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen 123", processedPath3);

            string processedPath4 = MPBase.ParsePath("/v1/putpath/slug/:id/pEmail/:email/pAddress/:address/pMaritalstatus/:maritalStatus/pHasCreditCard/:hasCreditCard", null, dummy);
            Assert.AreEqual("/v1/putpath/slug/111/pEmail/person@something.com/pAddress/Evergreen 123/pMaritalstatus/divorced/pHasCreditCard/True", processedPath4);

        }
    }
    
}
