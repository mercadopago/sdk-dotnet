using MercadoPago;
using MercadoPago.DataStructures.MerchantOrder;
using MercadoPago.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture]
    public class MerchantOrderTest : BaseResourceTest
    {
        [Test]
        public void MerchantOrderCreateTest()
        {
            var merchantOrder = NewMerchantOrder();
            merchantOrder.Save();
            Assert.IsNull(merchantOrder.Errors);
            Assert.IsNotNull(merchantOrder.ID);
        }

        [Test]
        public void MerchantOrderUpdateTest()
        {
            var merchantOrder = NewMerchantOrder();
            merchantOrder.Save();
            Assert.IsNotNull(merchantOrder.ID);

            merchantOrder.AdditionalInfo = "New info";
            merchantOrder.Update();
            Assert.IsNull(merchantOrder.Errors);
        }

        [Test]
        public void MerchantOrderLoadTest()
        {
            var merchantOrder = NewMerchantOrder();
            merchantOrder.Save();
            Assert.IsNotNull(merchantOrder.ID);

            var loadMerchantOrder = new MerchantOrder
            {
                ID = merchantOrder.ID,
            };
            loadMerchantOrder.Load(merchantOrder.ID);
            Assert.IsNull(loadMerchantOrder.Errors);
            Assert.AreEqual(merchantOrder.ID, loadMerchantOrder.ID);
        }

        private static MerchantOrder NewMerchantOrder()
        {
            var preference = PreferenceTest.NewPreference();
            preference.Save();

            var merchantOrder = new MerchantOrder
            {
                PreferenceId = preference.Id,
                Items = new List<Item>(),
                ApplicationId = "59441713004005",
                AdditionalInfo = "Aditional info",
                ExternalReference = Guid.NewGuid().ToString(),
                Marketplace = "NONE",
                NotificationUrl = "https://seller/notification",
                SiteId = "MLB",
            };

            preference.Items.ForEach(item =>
            {
                merchantOrder.Items.Add(new Item
                {
                    ID = item.Id,
                    CategoryId = item.CategoryId,
                    CurrencyId = item.CurrencyId.ToString(),
                    Description = item.Description,
                    PictureUrl = item.PictureUrl,
                    Quantity = item.Quantity.GetValueOrDefault(),
                    Title = item.Title,
                    UnitPrice = (float)item.UnitPrice,
                });
            });

            return merchantOrder;
        }
    }
}
