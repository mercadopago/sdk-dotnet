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
            var accessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            if (string.IsNullOrEmpty(accessToken) || IsRunningInCI())
            {
                MercadoPagoConfig.AccessToken = "TEST-MOCK-TOKEN";
                User = CreateMockUser();
            }
            else
            {
                MercadoPagoConfig.AccessToken = accessToken;
                try
                {
                    User = GetUser();
                }
                catch (Exception)
                {
                    User = CreateMockUser();
                }
            }
        }

        public User User { get; }

        public void Dispose()
        {
        }

        private static bool IsRunningInCI()
        {
            return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GITHUB_ACTIONS")) ||
                   !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
        }

        private static User GetUser()
        {
            var userClient = new UserClient();
            return userClient.Get();
        }

        private static User CreateMockUser()
        {
            return new User
            {
                Id = 123456789,
                Email = "test@mercadopago.com",
                FirstName = "Test",
                LastName = "User",
                Nickname = "testuser",
                CountryId = "BR",
                SiteId = "MLB"
            };
        }
    }
}
