namespace MercadoPago.Tests.Client.Preference
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Client.Common;
    using MercadoPago.Client.Preference;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.Preference;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client.Helper;
    using Moq;
    using Xunit;

    [Collection("Uses User Email")]
    public class PreferenceClientTest : BaseClientTest
    {
        private readonly PreferenceClient preferenceClient;

        public PreferenceClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            preferenceClient = new PreferenceClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new PreferenceClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new PreferenceClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new PreferenceClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new PreferenceClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task CreateAsync_Success()
        {
            PreferenceRequest request = BuildRequest();

            Preference preference = await preferenceClient.CreateAsync(request);

            Assert.NotNull(preference);
            Assert.NotNull(preference.Id);
            Assert.Equal(request.ExternalReference, preference.ExternalReference);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Create_Success()
        {
            PreferenceRequest request = BuildRequest();

            Preference preference = preferenceClient.Create(request);

            Assert.NotNull(preference);
            Assert.NotNull(preference.Id);
            Assert.Equal(request.ExternalReference, preference.ExternalReference);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task UpdateAsync_Success()
        {
            // Creates a preference
            PreferenceRequest createRequest = BuildRequest();
            Preference createdPreference = await preferenceClient.CreateAsync(createRequest);

            var updateRequest = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Description = "Item 1",
                        Id = "123",
                        PictureUrl = "http://product1.image.png",
                        Quantity = 1,
                        Title = "Item 1",
                        UnitPrice = 100,
                    },
                    new PreferenceItemRequest
                    {
                        Description = "Item 2",
                        Id = "456",
                        PictureUrl = "http://product2.image.png",
                        Quantity = 2,
                        Title = "Item 2",
                        UnitPrice = 200,
                    },
                },
            };
            Preference preference = await preferenceClient.UpdateAsync(
                createdPreference.Id, updateRequest);

            Assert.NotNull(preference);
            Assert.NotNull(preference.Items);
            Assert.True(preference.Items.Count == 2);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Update_Success()
        {
            // Creates a preference
            PreferenceRequest createRequest = BuildRequest();
            Preference createdPreference = preferenceClient.Create(createRequest);

            var updateRequest = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Description = "Item 1",
                        Id = "123",
                        PictureUrl = "http://product1.image.png",
                        Quantity = 1,
                        Title = "Item 1",
                        UnitPrice = 100,
                    },
                    new PreferenceItemRequest
                    {
                        Description = "Item 2",
                        Id = "456",
                        PictureUrl = "http://product2.image.png",
                        Quantity = 2,
                        Title = "Item 2",
                        UnitPrice = 200,
                    },
                },
            };
            Preference preference = preferenceClient.Update(
                createdPreference.Id, updateRequest);

            Assert.NotNull(preference);
            Assert.NotNull(preference.Items);
            Assert.True(preference.Items.Count == 2);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task GetAsync_Success()
        {
            // Creates a preference
            PreferenceRequest createRequest = BuildRequest();
            Preference createdPreference = await preferenceClient.CreateAsync(createRequest);

            Preference preference = await preferenceClient.GetAsync(
                createdPreference.Id);

            Assert.NotNull(preference);
            Assert.Equal(createdPreference.Id, preference.Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Get_Success()
        {
            // Creates a preference
            PreferenceRequest createRequest = BuildRequest();
            Preference createdPreference = preferenceClient.Create(createRequest);

            Preference preference = preferenceClient.Get(
                createdPreference.Id);

            Assert.NotNull(preference);
            Assert.Equal(createdPreference.Id, preference.Id);
        }

        [Fact]
        public async Task SearchAsync_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreferenceSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var client = new PreferenceClient(mock.Object);
            var request = new SearchRequest { Limit = 10, Offset = 0 };
            ResultsResourcesPage<Preference> result = await client.SearchAsync(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
            Assert.NotNull(result.Results);
            Assert.Equal("123456789-abc-def", result.Results[0].Id);
        }

        [Fact]
        public void Search_Success()
        {
            var json = File.ReadAllText("Client/Mock/PreferenceSearchResponse.json");
            var response = new MercadoPagoResponse(200, null, json);
            var mock = new Mock<IHttpClient>();
            mock.Setup(h => h.SendAsync(
                    It.IsAny<MercadoPagoRequest>(),
                    It.IsAny<IRetryStrategy>(),
                    It.IsAny<CancellationToken>()).Result)
                .Returns(response);

            var client = new PreferenceClient(mock.Object);
            var request = new SearchRequest { Limit = 10, Offset = 0 };
            ResultsResourcesPage<Preference> result = client.Search(request);

            Assert.NotNull(result);
            Assert.NotNull(result.Paging);
            Assert.Equal(1, result.Paging.Total);
            Assert.NotNull(result.Results);
            Assert.Equal("REF001", result.Results[0].ExternalReference);
        }

        private PreferenceRequest BuildRequest()
        {
            return new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Description = "Description",
                        Id = "123",
                        PictureUrl = "http://product.image.png",
                        Quantity = 1,
                        Title = "Title",
                        UnitPrice = 100,
                    },
                },
                Payer = new PreferencePayerRequest
                {
                    Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                    Name = "Test",
                    Surname = "User",
                    Phone = new PhoneRequest
                    {
                        AreaCode = "11",
                        Number = "999999999",
                    },
                    Identification = IdentificationHelper.GetIdentification(User),
                    Address = new AddressRequest
                    {
                        StreetName = "Street",
                        StreetNumber = 123,
                    },
                },
                PaymentMethods = new PreferencePaymentMethodsRequest
                {
                    ExcludedPaymentMethods = new List<PreferencePaymentMethodRequest>
                    {
                        new PreferencePaymentMethodRequest
                        {
                            Id = "visa",
                        },
                    },
                    ExcludedPaymentTypes = new List<PreferencePaymentTypeRequest>
                    {
                        new PreferencePaymentTypeRequest
                        {
                            Id = "debit_card",
                        },
                    },
                    DefaultPaymentMethodId = "master",
                    Installments = 6,
                    DefaultInstallments = 1,
                },
                Shipments = new PreferenceShipmentsRequest
                {
                    Mode = "custom",
                    LocalPickup = false,
                    Dimensions = "10x10x20,500",
                    ReceiverAddress = new PreferenceReceiverAddressRequest
                    {
                        ZipCode = "00000-000",
                        StreetNumber = 123,
                        StreetName = "Street",
                        Floor = "12",
                        Apartment = "120A",
                        CountryName = "Argentina",
                        StateName = "Buenos Aires",
                        CityName = "Buenos Aires",
                    },
                    Cost = 10,
                },
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = "https://seller/success",
                    Pending = "https://seller/pending",
                    Failure = "https://seller/failure",
                },
                NotificationUrl = "https://seller/notification",
                AdditionalInfo = "Additional info",
                AutoReturn = "all",
                ExternalReference = Guid.NewGuid().ToString(),
                Expires = true,
                ExpirationDateFrom = DateTime.Now,
                ExpirationDateTo = DateTime.Now.AddMonths(1),
                Tracks = new List<PreferenceTrackRequest>
                {
                    new PreferenceTrackRequest
                    {
                        Type = "google_ad",
                        Values = new PreferenceTrackValuesRequest
                        {
                            ConversionId = "1123",
                            ConversionLabel = "label",
                        },
                    },
                    new PreferenceTrackRequest
                    {
                        Type = "facebook_ad",
                        Values = new PreferenceTrackValuesRequest
                        {
                            PixelId = "111111",
                        },
                    },
                },
                BinaryMode = true,
                Taxes = new List<PreferenceTaxRequest>
                {
                    new PreferenceTaxRequest
                    {
                        Type = "Custom",
                        Value = 2,
                    },
                },
                ProcessingModes = new List<string>{
                    "aggregator",
                },
            };
        }
    }
}
