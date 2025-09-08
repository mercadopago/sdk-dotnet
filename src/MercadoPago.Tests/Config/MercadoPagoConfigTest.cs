namespace MercadoPago.Tests.Config
{
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Serialization;
    using Xunit;

    public class MercadoPagoConfigTest
    {
        [Fact(Skip = "Not running in CI.")]
        public void Config_SetterAndGetter_MustBeEqualSetValues()
        {
            string accessToken = MercadoPagoConfig.AccessToken;
            string corporationId = MercadoPagoConfig.CorporationId;
            string integratorId = MercadoPagoConfig.IntegratorId;
            string platformId = MercadoPagoConfig.PlatformId;

            try
            {
                MercadoPagoConfig.AccessToken = "x";
                MercadoPagoConfig.CorporationId = "y";
                MercadoPagoConfig.IntegratorId = "w";
                MercadoPagoConfig.PlatformId = "z";

                Assert.Equal("x", MercadoPagoConfig.AccessToken);
                Assert.Equal("y", MercadoPagoConfig.CorporationId);
                Assert.Equal("w", MercadoPagoConfig.IntegratorId);
                Assert.Equal("z", MercadoPagoConfig.PlatformId);
            }
            finally
            {
                MercadoPagoConfig.AccessToken = accessToken;
                MercadoPagoConfig.CorporationId = corporationId;
                MercadoPagoConfig.IntegratorId = integratorId;
                MercadoPagoConfig.PlatformId = platformId;
            }
        }

        [Fact(Skip = "Not running in CI.")]
        public void ConfigHttpClient_SetterAndGetter_DefaultHttpClient()
        {
            MercadoPagoConfig.HttpClient = null;

            Assert.NotNull(MercadoPagoConfig.HttpClient);
            Assert.True(MercadoPagoConfig.HttpClient is DefaultHttpClient);
        }

        [Fact(Skip = "Not running in CI.")]
        public void ConfigSerializer_SetterAndGetter_DefaultSerializer()
        {
            MercadoPagoConfig.Serializer = null;

            Assert.NotNull(MercadoPagoConfig.Serializer);
            Assert.True(MercadoPagoConfig.Serializer is DefaultSerializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public void ConfigRetryStrategy_SetterAndGetter_DefaultRetryStrategy()
        {
            MercadoPagoConfig.RetryStrategy = null;

            Assert.NotNull(MercadoPagoConfig.RetryStrategy);
            Assert.True(MercadoPagoConfig.RetryStrategy is DefaultRetryStrategy);
        }
    }
}
