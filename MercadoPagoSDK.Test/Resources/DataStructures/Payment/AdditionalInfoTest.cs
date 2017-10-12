using MercadoPago.DataStructures.Payment;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPagoSDK.Test.Resources.DataStructures.Payment
{
    [TestFixture()]
    public class AdditionalInfoTest
    {
        [Test()]
        public void AdditionalInfo_AppendItemShoouldBeOk()
        {
            AdditionalInfo additionalInfoInternal = new AdditionalInfo();

            additionalInfoInternal.Items = new List<Item>();
            additionalInfoInternal.AppendItem(new Item() { });

            Assert.Pass();
        }

        [Test()]
        public void AdditionalInfo_ItemsShouldHaveAtLeastOneItem()
        {
            AdditionalInfo additionalInfoInternal = new AdditionalInfo();

            additionalInfoInternal.AppendItem(new Item() { Description = "Item de compra" });

            Assert.AreEqual("Item de compra", additionalInfoInternal.Items.FirstOrDefault().Description);
        }

    }
}
