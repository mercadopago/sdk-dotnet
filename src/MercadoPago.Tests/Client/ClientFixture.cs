namespace MercadoPago.Tests.Client
{
    using System;
    using MercadoPago.Client.User;
    using MercadoPago.Config;
    using MercadoPago.Resource.User;

    public class ClientFixture : IDisposable
    {
        public ClientFixture()
        {
            MercadoPagoConfig.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
            User = GetUser();
        }

        public User User { get; }

        public void Dispose()
        {
        }

        private static User GetUser()
        {
            var userClient = new UserClient();
            return userClient.Get();
        }
    }
}
