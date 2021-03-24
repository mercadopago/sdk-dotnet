namespace MercadoPago.Tests.Client.PaymentMethod
{
    using System.Threading.Tasks;
    using MercadoPago.Client.PaymentMethod;
    using MercadoPago.Resource;
    using MercadoPago.Resource.PaymentMethod;
    using Xunit;

    public class PaymentMethodClientTest : BaseClientTest
    {
        private readonly PaymentMethodClient paymentMethodClient;

        public PaymentMethodClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            paymentMethodClient = new PaymentMethodClient();
        }

        [Fact]
        public async Task ListPaymentMethodsAsync_Success()
        {
            ResourcesList<PaymentMethod> paymentMethods =
                await paymentMethodClient.ListAsync();

            Assert.NotNull(paymentMethods);
            Assert.True(paymentMethods.Count > 0);
        }

        [Fact]
        public void ListPaymentMethods_Success()
        {
            ResourcesList<PaymentMethod> paymentMethods =
                paymentMethodClient.List();

            Assert.NotNull(paymentMethods);
            Assert.True(paymentMethods.Count > 0);
        }
    }
}
