using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MercadoPago.Common;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using MercadoPagoSDK.Test.Helpers;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture] 
    public class PaymentTest : BaseResourceTest
    {
        [Test]
        public void PaymentSaveTest()
        {
            var payment = NewPayment(false);
            payment.Save();
            Assert.IsNull(payment.Errors);
            Assert.IsNotNull(payment.Id);
        }

        [Test]
        public void PaymentSaveRequestOptionsTest()
        {
            var requestOptions = NewRequestOptions();
            var payment = NewPayment(false);
            payment.Save(requestOptions);
            Assert.IsNull(payment.Errors);
            Assert.IsNotNull(payment.Id);
        }

        [Test]
        public void CapturePaymentTest()
        {
            var payment = NewPayment(false);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            payment.Capture = true;
            payment.Update();
            Assert.IsNull(payment.Errors);
        }

        [Test]
        public void CapturePaymentRequestOptionsTest()
        {
            var payment = NewPayment(false);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            var requestOptions = NewRequestOptions();
            payment.Capture = true;
            payment.Update(requestOptions);
            Assert.IsNull(payment.Errors);
        }

        [Test]
        public void CancelPaymentTest()
        {
            var payment = NewPayment(false);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            payment.Status = PaymentStatus.cancelled;
            payment.Update();
            Assert.IsNull(payment.Errors);
        }

        [Test]
        public void FindPaymentTest()
        {
            Payment payment = NewPayment(false);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            var findPayment = Payment.FindById(payment.Id);
            Assert.IsNotNull(findPayment);
            Assert.AreEqual(payment.Id, findPayment.Id);
        }

        [Test]
        public void FindPaymentRequestOptionsTest()
        {
            var payment = NewPayment(false);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            var requestOptions = NewRequestOptions();
            var findPayment = Payment.FindById(payment.Id, false, requestOptions);
            Assert.IsNotNull(findPayment);
            Assert.AreEqual(payment.Id, findPayment.Id);
        }

        [Test]
        public void SearchAllTest()
        {
            var payments = Payment.All();
            Assert.IsNotNull(payments);
            Assert.IsTrue(payments.Any());
        }

        [Test]
        public void SearchAllRequestOptionsTest()
        {
            var requestOptions = NewRequestOptions();
            var payments = Payment.All(false, requestOptions);
            Assert.IsNotNull(payments);
            Assert.IsTrue(payments.Any());
        }

        [Test]
        public void SearchByReferenceTest()
        {
            var payment = NewPayment(false);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            var filter = new Dictionary<String, String>
            {
                { "external_reference", payment.ExternalReference },
            };
            var payments = Payment.Search(filter);
            Assert.IsNotNull(payments);
            Assert.IsTrue(payments.Any());
        }

        [Test]
        public void SearchByReferenceRequestOptionsTest()
        {
            var payment = NewPayment(false);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            var requestOptions = NewRequestOptions();
            var filter = new Dictionary<String, String>
            {
                { "external_reference", payment.ExternalReference },
            };
            var payments = Payment.Search(filter, false, requestOptions);
            Assert.IsNotNull(payments);
            Assert.IsTrue(payments.Any());
        }

        [Test]
        public void PaymentRefundTotalTest()
        {
            var payment = NewPayment(true);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            payment.Refund();
            Assert.IsNull(payment.Errors);
            Assert.AreEqual(PaymentStatus.refunded, payment.Status);
        }

        [Test]
        public void PaymentRefundTotalRequestOptionsTest()
        {
            var payment = NewPayment(true);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            var requestOptions = NewRequestOptions();
            payment.Refund(requestOptions);
            Assert.IsNull(payment.Errors);
            Assert.AreEqual(PaymentStatus.refunded, payment.Status);
        }

        [Test]
        public void PaymentRefundPartialTest()
        {
            var payment = NewPayment(true);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            payment.Refund(1);
            Assert.IsNull(payment.Errors);
            Assert.AreEqual(PaymentStatus.approved, payment.Status);
        }

        [Test]
        public void PaymentRefundPartialRequestOptionsTest()
        {
            var payment = NewPayment(true);
            payment.Save();
            Assert.IsNotNull(payment.Id);

            Thread.Sleep(3000);

            var requestOptions = NewRequestOptions();
            payment.Refund(1, requestOptions);
            Assert.IsNull(payment.Errors);
            Assert.AreEqual(PaymentStatus.approved, payment.Status);
        }

        [Test]
        public void PaymentCreateErrorTest()
        {
            Payment payment = new Payment();
            payment.Save();

            Assert.IsNotNull(payment.Errors);
        }

        private static Payment NewPayment(bool capture)
        {
            string token = CardHelper.SingleUseCardToken("approved");

            return new Payment
            {
                Payer = new Payer
                {
                    Email = "test_payer_9999988@testuser.com",
                    Entity_type = EntityType.individual,
                    Type = PayerType.customer,
                    Id = "649457098-FybpOkG6zH8QRm",
                    Identification = new Identification
                    {
                        Type = "CPF",
                        Number = "19119119100",
                    },
                    FirstName = "Test",
                    LastName = "User",
                },
                BinaryMode = false,
                Capture = capture,
                ExternalReference = Guid.NewGuid().ToString(),
                Description = "Payment description",
                Metadata = new JObject
                {
                    { "key1", JToken.FromObject("value1") },
                    { "key2", JToken.FromObject("value2") },
                },
                TransactionAmount = 10,
                //PaymentMethodId = "master",
                Token = token,
                Installments = 1,
                StatementDescriptor = "STAT-DESC",
                NotificationUrl = "https://seu-site.com.br/webhooks",
                CallbackUrl = "https://seu-site.com.br/callbackurl",
                AdditionalInfo = new AdditionalInfo
                {
                    IpAddress = "127.0.0.1",
                    Items = new List<Item>
                    {
                        new Item
                        {
                            Id = "SKU-1",
                            Title = "Product",
                            PictureUrl = "https://www.mercadopago.com/org-img/MLB/design/2015/m_pago/logos/mp_processado_02.png",
                            Description = "Product description",
                            CategoryId = "cat",
                            Quantity = 1,
                            UnitPrice = 10,
                        },
                    },
                    Payer = new AdditionalInfoPayer
                    {
                        FirstName = "Test",
                        LastName = "User",
                        RegistrationDate = DateTime.Now.AddDays(-30),
                        Phone = new Phone
                        {
                            AreaCode = "11",
                            Number = "999999999",
                        },
                        Address = new Address
                        {
                            ZipCode = "0600000",
                            StreetName = "Street",
                            StreetNumber = 123,
                        },
                    },
                    Shipments = new Shipment
                    {
                        ReceiverAddress = new ReceiverAddress
                        {
                            Zip_code = "0600000",
                            StreetName = "Street",
                            StreetNumber = 123,
                            Apartment = "23",
                            Floor = "First",
                        },
                    },
                },
            };
        }
    }
}
