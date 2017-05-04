using MercadoPago;
using MercadoPago.Core;
using MercadoPago.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Core
{
    [TestFixture()]
    public class MPIPNTest
    {
        [Test()]
        public void MPIPN_MustThrowNullException_BothParametersEmpty()
        {
            try
            {
                MPIPN.Manage(null, null);
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_MustThrowException_IdParameterEmpty()
        {
            try
            {
                MPIPN.Manage(MPIPN.Topic.payment, null);
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_MustThrowException_TopicParameterEmpty()
        {
            try
            {
                MPIPN.Manage(null, "id");
            }
            catch (MPException ex)
            {
                Assert.AreEqual("Topic and Id can not be null in the IPN request.", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_MustThrowException_ClassNotExtendsFromMPBase()
        {
            try
            {
                MPIPN.Manage("MercadoPago.Resources.DataStructures.Customer.City", "1234567");
            }
            catch (MPException ex)
            {
                Assert.AreEqual("City does not extend from MPBase", ex.Message);
                return;
            }

            Assert.Fail();
        }

        [Test()]
        public void MPIPN_ShouldBeOk()
        { 
            MPConf.CleanConfiguration();            

            MPConf.CleanConfiguration();
            MPConf.SetBaseUrl("https://api.mercadopago.com");
            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));            
            MPConf.SetConfiguration(config);
            
            var resource = MPIPN.Manage(MPIPN.Topic.payment, "2278812");
            Assert.IsTrue(resource.GetType().IsSubclassOf(typeof(MPBase)));           
        }

        [Test()]
        public void MPIPN_GetTypeShouldFindTheRightClassType()
        {
            Type type = MPIPN.GetType(MPIPN.Topic.payment);

            Assert.IsTrue(typeof(Payment) == type);
        }

        [Test()]
        public void MPIPN_GetTypeShouldReturnNull()
        {
            Type type = MPIPN.GetType("MercadoPago.Resources.PaymentMeans");

            Assert.IsNull(type);
        }

        [Test()]
        public void MPIPN_GetTypeShouldReturnNotNullValue()
        {
            Type type = MPIPN.GetType(MPIPN.Topic.payment);

            Assert.IsNotNull(type);
        }

        [Test()]
        public void MPIPN_GetTypeShouldReturnATypeObject()
        {
            Type type = MPIPN.GetType(MPIPN.Topic.payment);

            Type castType = type as Type;

            if (castType != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
