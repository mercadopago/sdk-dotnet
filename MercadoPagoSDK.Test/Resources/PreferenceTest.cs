using System;
using System.Collections.Generic;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;
using NUnit.Framework;
using PaymentMethod = MercadoPago.DataStructures.Preference.PaymentMethod;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture]
    public class PreferenceTest : BaseResourceTest
    {
        [Test]
        public void CreatePreferenceTest()
        {
            var preference = NewPreference();
            preference.Save();
            Assert.IsNotNull(preference.Id);
        }

        [Test]
        public void CreatePreferenceRequestOptionsTest()
        {
            var requestOptions = NewRequestOptions();
            var preference = NewPreference();
            preference.Save(requestOptions);
            Assert.IsNotNull(preference.Id);
        }

        [Test]
        public void UpdatePreferenceTest()
        {
            var preference = NewPreference();
            preference.Save();
            Assert.IsNotNull(preference.Id);

            preference.AdditionalInfo = "New info";
            preference.Update();
            Assert.IsNull(preference.Errors);
        }

        [Test]
        public void UpdatePreferenceRequestOptionsTest()
        {
            var preference = NewPreference();
            preference.Save();
            Assert.IsNotNull(preference.Id);

            var requestOptions = NewRequestOptions();
            preference.AdditionalInfo = "New info";
            preference.Update(requestOptions);
            Assert.IsNull(preference.Errors);
        }

        [Test]
        public void FindPreferenceTest()
        {
            var preference = NewPreference();
            preference.Save();
            Assert.IsNotNull(preference.Id);

            var findPreference = Preference.FindById(preference.Id);
            Assert.IsNotNull(findPreference);
            Assert.AreEqual(preference.Id, findPreference.Id);
        }

        [Test]
        public void FindPreferenceRequestOptionsTest()
        {
            var preference = NewPreference();
            preference.Save();
            Assert.IsNotNull(preference.Id);

            var requestOptions = NewRequestOptions();
            var findPreference = Preference.FindById(preference.Id, false, requestOptions);
            Assert.IsNotNull(findPreference);
            Assert.AreEqual(preference.Id, findPreference.Id);
        }

        private static Preference NewPreference()
        {
            return new Preference
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        CurrencyId = MercadoPago.Common.CurrencyId.BRL,
                        Description = "Description",
                        Id = "123",
                        PictureUrl = "http://product.image.png",
                        Quantity = 1,
                        Title = "Title",
                        UnitPrice = 100,
                    },
                },
                Payer = new Payer
                {
                    Email = "test_user_15230029@testuser.com",
                    Name = "Test",
                    Surname = "User",
                    Phone = new Phone
                    {
                        AreaCode = "11",
                        Number = "999999999",
                    },
                    Identification = new Identification
                    {
                        Type = "CPF",
                        Number = "19119119100",
                    },
                    Address = new Address
                    {
                        ZipCode = "06000000",
                        StreetName = "Street",
                        StreetNumber = 123,
                    },
                },
                PaymentMethods = new PaymentMethods
                {
                    ExcludedPaymentMethods = new List<PaymentMethod>
                    {
                        new PaymentMethod
                        {
                            Id = "visa",
                        },
                    },
                    ExcludedPaymentTypes = new List<PaymentType>
                    {
                        new PaymentType
                        {
                            Id = "debit_card",
                        },
                    },
                    DefaultPaymentMethodId = "master",
                    Installments = 6,
                    DefaultInstallments = 1,
                },
                Shipments = new Shipment
                {
                    Mode = MercadoPago.Common.ShipmentMode.NotSpecified,
                    LocalPickUp = false,
                    Dimensions = "10x10x20,500",
                    ReceiverAddress = new ReceiverAddress
                    {
                        ZipCode = "06000000",
                        StreetNumber = 123,
                        StreetName = "Street",
                        Floor = "12",
                        Apartment = "120A",
                    },
                    Cost = 10,
                },
                BackUrls = new BackUrls
                {
                    Success = "https://seller/success",
                    Pending = "https://seller/pending",
                    Failure = "https://seller/failure",
                },
                NotificationUrl = "https://seller/notification",
                AdditionalInfo = "Additional info",
                AutoReturn = MercadoPago.Common.AutoReturnType.all,
                ExternalReference = Guid.NewGuid().ToString(),
                Expires = true,
                ExpirationDateFrom = DateTime.Now,
                ExpirationDateTo = DateTime.Now.AddMonths(1),
                Tracks = new List<Track>
                {
                    new Track
                    {
                        Type = "google_ad",
                        Values = new Newtonsoft.Json.Linq.JObject
                        {
                            { "conversion_id", "1123" },
                            { "conversion_label", "label" },
                        },
                    },
                    new Track
                    {
                        Type = "facebook_ad",
                        Values = new Newtonsoft.Json.Linq.JObject
                        {
                            { "pixel_id", "111111" },
                        },
                    },
                },
                BinaryMode = true,
                Taxes = new List<Tax>
                {
                    new Tax
                    {
                        Type = MercadoPago.Common.TaxType.IVA,
                        Value = 2,
                    },
                },
                ProcessingModes = new List<MercadoPago.Common.ProcessingMode>{
                    MercadoPago.Common.ProcessingMode.aggregator,
                    MercadoPago.Common.ProcessingMode.gateway,
                },
            };
        }
    }
}
