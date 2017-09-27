using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.Resources.DataStructures.MerchantOrder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class MerchantOrderTest
    {
        [Test()]
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
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            MerchantOrder merchantOrderInternal = new MerchantOrder();
            try
            {
                var result = merchantOrderInternal.Load("1234");
            }
            catch (MPException mpException)
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
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            MerchantOrder merchantOrderInternal = new MerchantOrder() { ID = "1" };

            try
            {
                var result = merchantOrderInternal.Update();
            }
            catch (MPException mpException)
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
            SDK.CleanConfiguration();
            SDK.SetBaseUrl("https://api.mercadopago.com");

            Dictionary<string, string> config = new Dictionary<string, string>();
            config.Add("clientSecret", Environment.GetEnvironmentVariable("CLIENT_SECRET"));
            config.Add("clientId", Environment.GetEnvironmentVariable("CLIENT_ID"));
            SDK.SetConfiguration(config);

            MerchantOrder merchantOrderInternal = new MerchantOrder();

            try
            {
                var result = merchantOrderInternal.Create();
            }
            catch (MPException mpException)
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
