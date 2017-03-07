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
        //MPBaseTest va a ser Customer, cualquier otro recurso, o cquier clase que se la adorne con una annotation

        
        public static MPBaseTest loadNoAtt(string id)
        {
            return (MPBaseTest)MPBaseTest.processMethod(typeof(MPBaseTest), "loadNoAtt", id, false);
        }

        [Test()]
        public void MPBaseTest_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = MPBaseTest.loadNoAtt("666");
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("No annotated method found", mpException.Message);
                return;
            }

            // should never get here
            Assert.Fail();
        }

        [GETEndpoint("/v1/customers/:id")]
        public static MPBaseTest load(string id)
        {
            return (MPBaseTest)MPBaseTest.processMethod(typeof(MPBaseTest), "load", id, false);
        }

        [Test()]
        public void MPBaseTest_WitAttributes_ShouldFindAttribute()
        {
            try
            {
                var result = MPBaseTest.load("666");
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
        //DummyClass va a ser Customer, cualquier otro recurso, o cquier clase que se la adorne con una annotation

        public static DummyClass loadDummy()
        {
            return (DummyClass)DummyClass.processMethod(typeof(DummyClass), "loadDummy", false);
        }

        [Test()]
        public void DummyClassMethod_WithNoAttributes_ShouldraiseException()
        {
            try
            {
                var result = DummyClass.loadDummy();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("No annotated method found", mpException.Message);
                return;
            }

            // should never get here
            Assert.Fail();
        }


        [GETEndpoint("/v1/loadSomething")]
        public static DummyClass loadWithAnnotation()
        {
            return (DummyClass)DummyClass.processMethod(typeof(DummyClass), "loadWithAnnotation", false);
        }

        [Test()]
        public void DummyClassMethod_WitAttributes_ShouldFindAttribute()
        {
            try
            {
                var result = DummyClass.loadWithAnnotation();
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
}
