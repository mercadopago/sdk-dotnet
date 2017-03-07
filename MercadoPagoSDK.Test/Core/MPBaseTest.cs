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
            return (MPBaseTest)MPBaseTest.processMethod(typeof(MPBaseTest), "load", id, false);
        }

        [GETEndpoint("/v1/getpath/slug")]
        public static MPBaseTest load_all()
        {
            return (MPBaseTest)MPBaseTest.processMethod(typeof(MPBaseTest), "load_all", false);
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
            return (DummyClass)DummyClass.processMethod(typeof(DummyClass), "load_all", false);
        }

        [GETEndpoint("/v1/getpath/load/:id")]
        public static DummyClass load(string id)
        {
            return (DummyClass)DummyClass.processMethod(typeof(DummyClass), "load", id, false);
        }

        [POSTEndpoint("/v1/postpath/slug")]
        public DummyClass create()
        {
            return (DummyClass)base.processMethod<DummyClass>("create", false);
        }


        [PUTEndpoint("/v1/putpath/slug/:id")]
        public DummyClass update(string id)
        {
            return (DummyClass)DummyClass.processMethod(typeof(DummyClass), "update", id, false);
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
            try
            {
                var result = create();
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
            DummyClass resource = null;
            try
            {
                resource = create();
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("POST", resource.Method);
            Assert.AreEqual("/v1/postpath/slug", resource.Url);
            Assert.AreEqual("DummyClass", resource.Instance);
        }

        [Test()]
        public void DummyClassMethod_Update_CheckUri()
        {
            DummyClass resource = null;
            try
            {
                resource = update("1234");
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("PUT", resource.Method);
            Assert.AreEqual("/v1/putpath/slug/1234", resource.Url);
            Assert.AreEqual("DummyClass", resource.Instance);
        }

        [Test()]
        public void DummyClassMethod_EmptyEndPoint_ShouldRaiseExcep()
        {
            DummyClass resource = null;
            try
            {
                resource = update("1234");
            }
            catch
            {
                // should never get here
                Assert.Fail();
                return;
            }

            Assert.AreEqual("PUT", resource.Method);
            Assert.AreEqual("/v1/putpath/slug/1234", resource.Url);
            Assert.AreEqual("DummyClass", resource.Instance);
        }
    }

    [TestFixture()]
    public class AnotherDummyClass : MPBase
    {
        [PUTEndpoint("")]
        public AnotherDummyClass update(string id)
        {
            return (AnotherDummyClass)AnotherDummyClass.processMethod(typeof(AnotherDummyClass), "update", id, false);
        }

        [Test()]
        public void DummyClassMethod_EmptyEndPoint_ShouldRaiseExcep()
        {
            AnotherDummyClass resource = null;
            try
            {
                resource = update("1234");
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
