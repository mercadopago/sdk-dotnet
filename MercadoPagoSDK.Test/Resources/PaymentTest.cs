using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using MercadoPago.Resources;
using MercadoPago.DataStructures.Payment;
using MercadoPago;
using Newtonsoft.Json.Linq;

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
 
            
            AccessToken = "TEST-6295877106812064-042916-6cead5bc1e48af95ea61cc9254595865__LC_LA__-202809963";
            PublicKey = "TEST-90189146-5027-424e-a3fd-f55d376c98c9";

            // Make a Clean Test
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");
            SDK.AccessToken = AccessToken;

        } 

        [Test]
        public void Payment_Create_ShouldBeOk()
        { 
            Payment payment = new Payment
            {
                TransactionAmount = (float)100.0,
                Token = Helpers.Authentication.SingleUseCardToken(PublicKey), // 1 use card token
                Description = "Pago de seguro",
                PaymentMethodId = "visa",
                Installments = 1,
                Payer = new Payer {
                    Email = "mlovera@kinexo.com" 
                }
            }; 

            payment.Save();

            Assert.IsTrue(payment.Id.HasValue, "Failed: Payment could not be successfully created");
            Assert.IsTrue(payment.Id.Value > 0, "Failed: Payment has not a valid id");

            LastPayment = payment; 
        }

        [Test]
        public void Payment_FindById_ShouldBeOk(){
            string LastPaymentId = LastPayment.Id.ToString();

            Payment payment = Payment.FindById(LastPaymentId);

            Assert.AreEqual("Pago de seguro", payment.Description);
            Assert.AreEqual("mlovera@kinexo.com", payment.Payer.Email);
        }

        [Test]
        public void Payment_Update_ShouldBeOk() 
        {  
            LastPayment.ExternalReference = "New External Reference"; 
            LastPayment.Update(); 
            Assert.AreEqual("New External Reference", LastPayment.ExternalReference); 
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
            filters.Add("external_reference", "New External Reference");
            List<Payment> list = Payment.Search(filters);

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Any());
            Assert.IsTrue(list.First().Id.HasValue);
        }

    }
}
