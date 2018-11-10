using MercadoPago;
using MercadoPago.DataStructures.MerchantOrder;
using MercadoPago.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class MerchantOrderTest
    {
        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Make a Clean Test
            SDK.CleanConfiguration();
            SDK.ClientId = ConfigurationManager.AppSettings.Get("CLIENT_ID");
            SDK.ClientSecret = ConfigurationManager.AppSettings.Get("CLIENT_SECRET");
        }

        [Test]
        public void MerchantOrder_AppendItemShouldBeOk()
        {
            MerchantOrder merchantOrderInternal = new MerchantOrder();

            merchantOrderInternal.Items = new List<Item>();
            merchantOrderInternal.AppendItem(new Item() { });

            Assert.Pass();
        }

        [Test()]
        public void MerchantOrder_ItemsShouldHaveAtLeastOneItem()
        {
            MerchantOrder merchantOrderInternal = new MerchantOrder();

            merchantOrderInternal.AppendItem(new Item() { Description = "Item de compra" });

            Assert.AreEqual("Item de compra", merchantOrderInternal.Items.FirstOrDefault().Description);
        }

        [Test()]
        public void MerchantOrder_AppendShipmentShouldBeOk()
        {
            MerchantOrder merchantOrderInternal = new MerchantOrder();

            merchantOrderInternal.AppendShipment(new Shipment() { });

            Assert.Pass();
        }

        [Test()]
        public void MerchantOrder_ShipmentsShouldHaveAtLeastOneItem()
        {
            MerchantOrder merchantOrderInternal = new MerchantOrder();

            merchantOrderInternal.AppendShipment(new Shipment() { ShipmentType = "Aereo" });

            Assert.AreEqual("Aereo", merchantOrderInternal.Shipments.FirstOrDefault().ShipmentType);
        }

        [Test()]
        public void MerchantOrder_LoadShouldbeOk()
        {
            try
            {
                var result = MerchantOrder.Load("894139561");
            }
            catch (MPException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        //[Test()]
        //public void MerchantOrder_NoConfigurationShouldRaiseException()
        //{
        //    MerchantOrder merchantOrderInternal = new MerchantOrder();

        //    try
        //    {
        //        var result = merchantOrderInternal.Load("1234");
        //    }
        //    catch (MPException mpException)
        //    {
        //        Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", mpException.Message);
        //        return;
        //    }

        //    Assert.Fail();
        //}

        [Test()]
        public void MerchantOrder_UpdateShouldBeOk()
        {
            const string EXT_REF = "EXTREF123";

            MerchantOrder merchantOrderInternal = new MerchantOrder() { ID = "894139561" };
            merchantOrderInternal.ExternalReference = EXT_REF;

            try
            {
                var result = merchantOrderInternal.Update();
            }
            catch (MPException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test()]
        public void MerchantOrder_UpdateShouldRaiseException()
        {
            MerchantOrder merchantOrderInternal = new MerchantOrder() { ID = "1" };

            merchantOrderInternal.ID = "2";

            try
            {
                var result = merchantOrderInternal.Update();
            }
            catch (MPException mpException)
            {
                Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", mpException.Message);
            }

            Assert.Pass();
        }

        [Test()]
        public void MerchantOrder_CreateShouldBeOk()
        {
            MerchantOrder merchantOrderInternal = new MerchantOrder()
            {
                PreferenceId = "202809963-281ec50b-4e69-4952-963b-ee1931ba4df0"
            };

            merchantOrderInternal.AppendItem(new Item() { Title = "Un producto sensacional", CurrencyId = "USD", Quantity = 1, UnitPrice = 0.99F });

            try
            {
                var result = merchantOrderInternal.Save();
            }
            catch (MPException)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        //[Test()]
        //public void MerchantOrder_CreateShouldRaiseException()
        //{
        //    MerchantOrder merchantOrderInternal = new MerchantOrder();

        //    try
        //    {
        //        var result = merchantOrderInternal.Create();
        //    }
        //    catch (MPException mpException)
        //    {
        //        Assert.AreEqual("\"client_id\" and \"client_secret\" can not be \"null\" when getting the \"access_token\"", mpException.Message);
        //        return;
        //    }

        //    Assert.Fail();
        //}
    }
}
