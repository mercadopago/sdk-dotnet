using MercadoPago.Resource.User;
using Xunit;

namespace MercadoPago.Tests.Client
{
    public abstract class BaseClientTest : IClassFixture<ClientFixture>
    {
        public BaseClientTest(ClientFixture clientFixture)
        {
            User = clientFixture.User;
        }

        protected User User { get; }
    }
}
