using System.Linq;
using MercadoPago.Resources;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture]
    public class PaymentMethodTest : BaseResourceTest
    {
        [Test]
        public void PaymentMethodAll()
        {
            var paymentMethods = PaymentMethod.All();
            Assert.IsNotNull(paymentMethods);
            Assert.IsTrue(paymentMethods.Any());
        }

        [Test]
        public void PaymentMethodRequestOptionsAll()
        {
            var requestOptions = NewRequestOptions();
            var paymentMethods = PaymentMethod.All(false, requestOptions);
            Assert.IsNotNull(paymentMethods);
            Assert.IsTrue(paymentMethods.Any());
        }
    }
}
