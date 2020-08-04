using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using MercadoPago;
using MercadoPago.Common;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture] 
    public class PaymentTest
    {
        string AccessToken;
        string PublicKey;
        Payment LastPayment; 

        [SetUp]
        public void Init(){ 
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            // HardCoding Credentials
            AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            PublicKey = Environment.GetEnvironmentVariable("PUBLIC_KEY");
            // Make a Clean Test
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = AccessToken; 
        }

        [Test]
        public void Payment_Create_EmptyShouldFail()
        {
            Payment payment = new Payment();
            payment.Save();

            Assert.IsNotNull(payment.Errors);
            Assert.IsTrue(payment.Errors?.Cause.Length > 0);

        }

        [Test]
        public void Payment_Create_ShouldBeOk()
        {



            Payment payment = Helpers.PaymentHelper.getPaymenData(PublicKey, "pending");

            payment.Save(); 
             
            LastPayment = payment;
 
 
            Assert.IsTrue(payment.Id.HasValue, "Failed: Payment could not be successfully created");
            Assert.IsTrue(payment.Id.Value > 0, "Failed: Payment has not a valid id"); 
        }

        [Test]
        public void Payment_FindById_ShouldBeOk()
        { 
            Payment payment = Payment.FindById(LastPayment.Id); 
            Assert.AreEqual("Pago de Prueba", payment.Description); 
        }

        [Test]
        public void Payment_Update_ShouldBeOk() 
        {
            LastPayment.Status = PaymentStatus.cancelled;

            Assert.True(LastPayment.Update());
        }

        [Test]
        public void Payment_SearchGetListOfPayments()
        { 
            List<Payment> payments = Payment.All();

            Assert.IsNotNull(payments);
            Assert.IsTrue(payments.Any());
            Assert.IsTrue(payments.First().Id.HasValue);
        }
        
        [Test] 
        public void Payment_SearchWithFilterGetListOfPayments()
        { 
            Dictionary<string, string> filters = new Dictionary<string, string>();
            filters.Add("external_reference", "INTEGRATION-TEST-PAYMENT");
            List<Payment> list = Payment.Search(filters);

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Any());
            Assert.IsTrue(list.Last().Id.HasValue);
        }

        [Test] 
        public void Payment_Refund()
        {

            Payment OtherPayment = Helpers.PaymentHelper.getPaymenData(PublicKey, "approved");

            OtherPayment.Save();
            OtherPayment.Refund(); 

            Assert.AreEqual(PaymentStatus.refunded, OtherPayment.Status, "Failed: Payment could not be successfully refunded");
        }

    }
}
