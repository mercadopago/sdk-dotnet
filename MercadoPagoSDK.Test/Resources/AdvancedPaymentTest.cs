using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MercadoPago.Resources;
using MercadoPagoSDK.Test.Helpers;
using NUnit.Framework;
using AdvPayDS = MercadoPago.DataStructures.AdvancedPayment;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture(Ignore = "Skipping")]
    public class AdvancedPaymentTest : BaseResourceTest
    {
        [Test]
        public void AdvancedPaymentCreateTest()
        {
            var advPayment = NewAdvancedPayment(false);
            advPayment.Save();
            Assert.IsNull(advPayment.Errors);
            Assert.IsNotNull(advPayment.Id);
        }

        [Test]
        public void AdvancedPaymentCancelTest()
        {
            var advPayment = NewAdvancedPayment(false);
            advPayment.Save();
            Assert.IsNotNull(advPayment.Id);

            Thread.Sleep(1000);

            var result = AdvancedPayment.Cancel(advPayment.Id.GetValueOrDefault());
            Assert.IsTrue(result);
        }

        [Test]
        public void AdvancedPaymentDoCaptureTest()
        {
            var advPayment = NewAdvancedPayment(false);
            advPayment.Save();
            Assert.IsNotNull(advPayment.Id);

            Thread.Sleep(5000);

            var result = AdvancedPayment.DoCapture(advPayment.Id.GetValueOrDefault());
            Assert.IsTrue(result);
        }

        [Test]
        public void AdvancedPaymentUpdateReleaseDateTest()
        {
            var advPayment = NewAdvancedPayment(false);
            advPayment.Save();
            Assert.IsNotNull(advPayment.Id);

            Thread.Sleep(1000);

            var result = AdvancedPayment.UpdateReleaseDate(advPayment.Id.GetValueOrDefault(), DateTime.Now.AddDays(1));
            Assert.IsTrue(result);
        }

        [Test]
        public void AdvancedPaymentRefundAllTest()
        {
            var advPayment = NewAdvancedPayment(true);
            advPayment.Save();
            Assert.IsNotNull(advPayment.Id);

            Thread.Sleep(1000);

            var disbursementsRefunded = AdvancedPayment.RefundAll(advPayment.Id.GetValueOrDefault());
            Assert.IsNotNull(disbursementsRefunded);
            Assert.IsTrue(disbursementsRefunded.Any());
        }

        [Test]
        public void AdvancedPaymentFindTest()
        {
            var advPayment = NewAdvancedPayment(false);
            advPayment.Save();
            Assert.IsNotNull(advPayment.Id);

            Thread.Sleep(1000);

            var advPaymentFind = AdvancedPayment.FindById(advPayment.Id.GetValueOrDefault());
            Assert.IsNotNull(advPaymentFind);
            Assert.IsNull(advPaymentFind.Errors);
            Assert.IsNotNull(advPaymentFind.Id);
        }

        [Test]
        public void AdvancedPaymentAllTest()
        {
            var advPayments = AdvancedPayment.All();
            Assert.IsNotNull(advPayments);
            Assert.IsTrue(advPayments.Any());
        }

        [Test]
        public void AdvancedPaymentSearchTest()
        {
            var advPayment = NewAdvancedPayment(false);
            advPayment.Save();
            Assert.IsNotNull(advPayment.Id);

            Thread.Sleep(1000);

            var filters = new Dictionary<String, String>()
            {
                { "external_reference", advPayment.ExternalReference },
            };
            var advPayments = AdvancedPayment.Search(filters);
            Assert.IsNotNull(advPayments);
            Assert.IsTrue(advPayments.Any());
        }

        private static AdvancedPayment NewAdvancedPayment(bool capture)
        {
            string token = CardHelper.SingleUseCardToken("approved");

            return new AdvancedPayment
            {
                ApplicationId = "59441713004005",
                Payments = new List<AdvPayDS.Payment>
                {
                    new AdvPayDS.Payment
                    {
                        PaymentMethodId = "master",
                        PaymentTypeId = "credit_card",
                        Token = token,
                        DateOfExpiration = DateTime.UtcNow.Add(TimeSpan.FromDays(120)),
                        TransactionAmount = 1000,
                        Installments = 1,
                        ProcessingMode = "aggregator",
                        Description = "Payment",
                        ExternalReference = "Test" + Guid.NewGuid().ToString(),
                        StatementDescriptor = "ADVPAYTEST"
                    },
                },
                Disbursements = new List<Disbursement>
                {
                    new Disbursement
                    {
                        Amount = 400,
                        ExternalReference = "Seller1" + Guid.NewGuid().ToString(),
                        CollectorId = 539673000,
                        ApplicationFee = 1,
                    },
                    new Disbursement
                    {
                        Amount = 600,
                        ExternalReference = "Seller2" + Guid.NewGuid().ToString(),
                        CollectorId = 488656838,
                        ApplicationFee = 0.5m,
                    },
                },
                Payer = new AdvPayDS.Payer
                {
                    Id = "649457098-FybpOkG6zH8QRm",
                    Type = "customer",
                    Email = "test_payer_9999988@testuser.com",
                    FirstName = "Test",
                    LastName = "User",
                    Address = new AdvPayDS.Address
                    {
                        ZipCode = "06233200",
                        StreetName = "Street",
                        StreetNumber = "120",
                    },
                    Identification = new AdvPayDS.Identification
                    {
                        Type = "CPF",
                        Number = "19119119100",
                    },
                },
                ExternalReference = "ADV" + Guid.NewGuid().ToString(),
                Description = "Test",
                BinaryMode = false,
                Capture = capture,
                AdditionalInfo = new AdvPayDS.AdditionalInfo
                {
                    IpAddress = "127.0.0.1",
                    Payer = new AdvPayDS.AdditionalInfoPayer
                    {
                        FirstName = "Test",
                        LastName = "User",
                        RegistrationDate = DateTime.UtcNow.AddDays(-10),

                    },
                    Items = new List<AdvPayDS.Item>
                    {
                        new AdvPayDS.Item
                        {
                            Id = "123",
                            Title = "Title",
                            PictureUrl = "https://www.mercadopago.com/logomp3.gif",
                            Description = "Description",
                            CategoryId = "Category",
                            Quantity = 1,
                            UnitPrice = 1000
                        },
                    },
                    Shipments = new AdvPayDS.Shipments
                    {
                        ReceiverAddress = new AdvPayDS.ReceiverAddress
                        {
                            ZipCode = "06233200",
                            StreetName = "Street",
                            StreetNumber = "120",
                            Floor = "1",
                            Apartment = "A",
                        },
                    },
                },
            };
        }
    }
}
