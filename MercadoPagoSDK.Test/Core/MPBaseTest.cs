using MercadoPago;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Core
{
    [TestFixture()]
    public class MPBaseTest : MPBase
    {    
        public static MPBaseTest load(string id)
        {
            return (MPBaseTest)MPBaseTest.processMethod("load", id, false);
        }

        [GETEndpoint("/v1/getpath/slug")]
        public static MPBaseTest load_all()
        {
            return (MPBaseTest)MPBaseTest.processMethod("load_all", false);
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
        public static DummyClass load_all()
        {
            return (DummyClass)DummyClass.processMethod("load_all", false);
        }

        [GETEndpoint("/v1/getpath/load/:id")]
        public static DummyClass load(string id)
        {
            return (DummyClass)DummyClass.processMethod("load", id, false);
        }

        [POSTEndpoint("/v1/postpath/slug")]
        public DummyClass create()
        {
            return (DummyClass)base.processMethod<DummyClass>("create", false);
        }


        [PUTEndpoint("/v1/putpath/slug/:id")]
        public DummyClass update(string id)
        {
            return (DummyClass)DummyClass.processMethod("update", id, false);
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
                result = resource.update("1234");
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("PUT", result.Method);
            Assert.AreEqual("/v1/putpath/slug/1234", result.Url);
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
        public AnotherDummyClass update(string id)
        {
            return (AnotherDummyClass)AnotherDummyClass.processMethod("update", id, false);
        }

        [Test()]
        public void AnotherDummyClass_EmptyEndPoint_ShouldRaiseExcep()
        {
            AnotherDummyClass resource = new AnotherDummyClass();
            AnotherDummyClass result = new AnotherDummyClass();
            try
            {
                result = resource.update("1234");
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Path not found for PUT method", ex.Message);
                return;
            }

            Assert.Fail();
        }
    }
    
}
