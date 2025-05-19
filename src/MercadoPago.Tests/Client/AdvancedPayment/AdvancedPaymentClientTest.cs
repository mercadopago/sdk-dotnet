namespace MercadoPago.Tests.Client.AdvancedPayment
{
    using System;
    using System.Threading.Tasks;
    using MercadoPago.Client.AdvancedPayment;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Resource.AdvancedPayment;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client.CardToken;
    using Xunit;
    using System.Collections.Generic;
    using MercadoPago.Client.Common;
    using MercadoPago.Tests.Client.Helper;
    using MercadoPago.Client;
    using MercadoPago.Resource;
    using System.Linq;
    using System.Threading;
    using MercadoPago.Error;

    [Collection("Uses User Email")]
    public class AdvancedPaymentClientTest : BaseClientTest
    {
        private readonly CardTokenTestClient cardTokenClient;
        private readonly AdvancedPaymentClient client;

        public AdvancedPaymentClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            cardTokenClient = new CardTokenTestClient();
            client = new AdvancedPaymentClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new AdvancedPaymentClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new AdvancedPaymentClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new AdvancedPaymentClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new AdvancedPaymentClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task CreateAsync_Approved_Success()
        {
            AdvancedPaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            AdvancedPayment advancedPayment = await CreateAsync(request);

            Assert.NotNull(advancedPayment);
            Assert.NotNull(advancedPayment.Id);
            Assert.True(advancedPayment.Capture);
            Assert.Equal(request.ExternalReference, advancedPayment.ExternalReference);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Create_Approved_Success()
        {
            AdvancedPaymentCreateRequest request = BuildCreateRequest(true, "approved");
            AdvancedPayment advancedPayment = Create(request);

            Assert.NotNull(advancedPayment);
            Assert.NotNull(advancedPayment.Id);
            Assert.True(advancedPayment.Capture);
            Assert.Equal(request.ExternalReference, advancedPayment.ExternalReference);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task CancelAsync_Pending_Success()
        {
            // Creates a pending advanced payment
            AdvancedPaymentCreateRequest request = await BuildCreateRequestAsync(true, "pending");
            AdvancedPayment advancedPayment = await CreateAsync(request);

            await Task.Delay(5000);

            // Cancels the payment
            advancedPayment = await client.CancelAsync(advancedPayment.Id.GetValueOrDefault());

            Assert.NotNull(advancedPayment);
            Assert.Equal(AdvancedPaymentStatus.Cancelled, advancedPayment.Status);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Cancel_Pending_Success()
        {
            // Creates a pending advanced payment
            AdvancedPaymentCreateRequest request = BuildCreateRequest(true, "pending");
            AdvancedPayment advancedPayment = Create(request);

            Thread.Sleep(5000);

            // Cancels the payment
            advancedPayment = client.Cancel(advancedPayment.Id.GetValueOrDefault());

            Assert.NotNull(advancedPayment);
            Assert.Equal(AdvancedPaymentStatus.Cancelled, advancedPayment.Status);
        }

        [Fact(Skip = "Not running in CI because the time between create and capture can be too long.")]
        public async Task CaptureAsync_Pending_Success()
        {
            AdvancedPaymentCreateRequest request = await BuildCreateRequestAsync(false, "approved");
            AdvancedPayment advancedPayment = await CreateAsync(request);

            Assert.NotNull(advancedPayment);
            Assert.Equal(AdvancedPaymentStatus.Authorized, advancedPayment.Status);

            await Task.Delay(7000);

            // Captures the payment
            advancedPayment = await CaptureAsync(advancedPayment.Id.GetValueOrDefault());

            Assert.NotNull(advancedPayment);
            Assert.Equal(AdvancedPaymentStatus.Approved, advancedPayment.Status);
        }

        [Fact(Skip = "Not running in CI because the time between create and capture can be too long.")]
        public void Capture_Pending_Success()
        {
            AdvancedPaymentCreateRequest request = BuildCreateRequest(false, "approved");
            AdvancedPayment advancedPayment = Create(request);

            Assert.NotNull(advancedPayment);
            Assert.Equal(AdvancedPaymentStatus.Authorized, advancedPayment.Status);

            Thread.Sleep(7000);

            // Captures the payment
            advancedPayment = Capture(advancedPayment.Id.GetValueOrDefault());

            Assert.NotNull(advancedPayment);
            Assert.Equal(AdvancedPaymentStatus.Approved, advancedPayment.Status);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task UpdateRealeaseDateAsync_AllDisbursements_Success()
        {
            AdvancedPaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            AdvancedPayment advancedPayment = await CreateAsync(request);

            await Task.Delay(5000);

            advancedPayment = await client.UpdateReleaseDateAsync(
                advancedPayment.Id.GetValueOrDefault(), DateTime.Now.AddDays(1));

            Assert.NotNull(advancedPayment);
        }

        [Fact(Skip = "Not running in CI.")]
        public void UpdateRealeaseDate_AllDisbursements_Success()
        {
            AdvancedPaymentCreateRequest request = BuildCreateRequest(true, "approved");
            AdvancedPayment advancedPayment = Create(request);

            Thread.Sleep(5000);

            advancedPayment = client.UpdateReleaseDate(
                advancedPayment.Id.GetValueOrDefault(), DateTime.Now.AddDays(1));

            Assert.NotNull(advancedPayment);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task GetAsync_Success()
        {
            AdvancedPaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            AdvancedPayment createdPayment = await CreateAsync(request);

            await Task.Delay(5000);

            // Gets the payment
            AdvancedPayment advancedPayment = await GetAsync(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(advancedPayment);
            Assert.Equal(createdPayment.Id, advancedPayment.Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Get_Success()
        {
            AdvancedPaymentCreateRequest request = BuildCreateRequest(true, "approved");
            AdvancedPayment createdPayment = Create(request);

            Thread.Sleep(5000);

            // Gets the payment
            AdvancedPayment advancedPayment = Get(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(advancedPayment);
            Assert.Equal(createdPayment.Id, advancedPayment.Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public async Task SearchAsync_ByExternalReference_Success()
        {
            AdvancedPaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            AdvancedPayment createdPayment = await CreateAsync(request);

            await Task.Delay(5000);

            ResultsResourcesPage<AdvancedPayment> results =
                await SearchByExternalReferenceAsync(createdPayment.ExternalReference);

            Assert.NotNull(results);
            Assert.NotNull(results.Paging);
            Assert.Equal(1, results.Paging.Total);
            Assert.NotNull(results.Results);
            Assert.Equal(createdPayment.Id, results.Results.First().Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Search_ByExternalReference_Success()
        {
            AdvancedPaymentCreateRequest request = BuildCreateRequest(true, "approved");
            AdvancedPayment createdPayment = Create(request);

            Thread.Sleep(5000);

            ResultsResourcesPage<AdvancedPayment> results =
                SearchByExternalReference(createdPayment.ExternalReference);

            Assert.NotNull(results);
            Assert.NotNull(results.Paging);
            Assert.Equal(1, results.Paging.Total);
            Assert.NotNull(results.Results);
            Assert.Equal(createdPayment.Id, results.Results.First().Id);
        }

        [Fact(Skip = "Not running in CI because the time between create and refund can be too long.")]
        public async Task RefundAsync_Total_Success()
        {
            AdvancedPaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            AdvancedPayment createdPayment = await CreateAsync(request);

            await Task.Delay(7000);

            ResourcesList<AdvancedPaymentDisbursementRefund> results =
                await RefundTotalAsync(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(results);
            Assert.True(results.Count == 2);
        }

        [Fact(Skip = "Not running in CI because the time between create and refund can be too long.")]
        public void Refund_Total_Success()
        {
            AdvancedPaymentCreateRequest request = BuildCreateRequest(true, "approved");
            AdvancedPayment createdPayment = Create(request);

            Thread.Sleep(7000);

            ResourcesList<AdvancedPaymentDisbursementRefund> results =
                RefundTotal(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(results);
            Assert.True(results.Count == 2);
        }

        private async Task<AdvancedPaymentCreateRequest> BuildCreateRequestAsync(
            bool capture, string paymentStatus)
        {
            CardToken cardToken =
                await cardTokenClient.CreateTestCardToken(User, paymentStatus);

            return new AdvancedPaymentCreateRequest
            {
                ApplicationId = "59441713004005",
                Payments = new List<AdvancedPaymentSplitPaymentRequest>
                {
                    new AdvancedPaymentSplitPaymentRequest
                    {
                        PaymentMethodId = "master",
                        PaymentTypeId = "credit_card",
                        Token = cardToken.Id,
                        DateOfExpiration = DateTime.UtcNow.Add(TimeSpan.FromDays(120)),
                        TransactionAmount = 1000,
                        Installments = 1,
                        ProcessingMode = "aggregator",
                        Description = "Payment",
                        ExternalReference = "Test" + Guid.NewGuid().ToString(),
                        StatementDescriptor = "ADVPAYTEST",
                    },
                },
                Disbursements = new List<AdvancedPaymentDisbursementRequest>
                {
                    new AdvancedPaymentDisbursementRequest
                    {
                        Amount = 400,
                        ExternalReference = "Seller1" + Guid.NewGuid().ToString(),
                        CollectorId = 539673000,
                        ApplicationFee = 1,
                        MoneyReleaseDays = 5,

                    },
                    new AdvancedPaymentDisbursementRequest
                    {
                        Amount = 600,
                        ExternalReference = "Seller2" + Guid.NewGuid().ToString(),
                        CollectorId = 488656838,
                        ApplicationFee = 0.5m,
                    },
                },
                Payer = new AdvancedPaymentPayerRequest
                {
                    Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                    FirstName = "Test",
                    LastName = "User",
                    Address = new AddressRequest
                    {
                        StreetName = "Street",
                        StreetNumber = 120,
                    },
                    Identification = IdentificationHelper.GetIdentification(User),
                },
                ExternalReference = "ADV" + Guid.NewGuid().ToString(),
                Description = "Test",
                BinaryMode = false,
                Capture = capture,
                AdditionalInfo = new AdvancedPaymentAdditionalInfoRequest
                {
                    IpAddress = "127.0.0.1",
                    Payer = new AdvancedPaymentAdditionalInfoPayerRequest
                    {
                        FirstName = "Test",
                        LastName = "User",
                        RegistrationDate = DateTime.UtcNow.AddDays(-10),
                        Address = new AddressRequest
                        {
                            StreetName = "Street",
                            StreetNumber = 120,
                        },
                        Phone = new PhoneRequest
                        {
                            AreaCode = "11",
                            Number = "999999999",
                        },
                    },
                    Items = new List<AdvancedPaymentItemRequest>
                    {
                        new AdvancedPaymentItemRequest
                        {
                            Id = "123",
                            Title = "Title",
                            PictureUrl = "https://www.mercadopago.com/logomp3.gif",
                            Description = "Description",
                            CategoryId = "Category",
                            Quantity = 1,
                            UnitPrice = 1000,
                        },
                    },
                    Shipments = new AdvancedPaymentShipmentsRequest
                    {
                        ReceiverAddress = new AdvancedPaymentReceiverAddressRequest
                        {
                            StreetName = "Street",
                            StreetNumber = 120,
                            Floor = "1",
                            Apartment = "A",
                        },
                    },
                },
                Metadata = new Dictionary<string, object>
                {
                    ["key1"] = "value1",
                },
            };
        }

        private AdvancedPaymentCreateRequest BuildCreateRequest(
            bool capture, string paymentStatus)
        {
            return BuildCreateRequestAsync(capture, paymentStatus)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private Task<AdvancedPayment> GetAsync(long id)
        {
            return ExecuteAsync(
                () => client.GetAsync(id),
                (ex) => ex.StatusCode == 404);
        }

        private AdvancedPayment Get(long id)
        {
            return Execute(
                () => client.Get(id),
                (ex) => ex.StatusCode == 404);
        }

        private async Task<AdvancedPayment> CreateAsync(AdvancedPaymentCreateRequest request)
        {
            AdvancedPayment createdPayment;
            try
            {
                createdPayment = await client.CreateAsync(request);
            }
            catch (MercadoPagoApiException ex)
            {
                if (ex.StatusCode == 422)
                {
                    await Task.Delay(5000);
                    ResultsResourcesPage<AdvancedPayment> results =
                        await SearchByExternalReferenceAsync(request.ExternalReference);
                    createdPayment = results?.Results?.First();
                }
                else
                {
                    throw;
                }
            }

            return createdPayment;
        }

        private AdvancedPayment Create(AdvancedPaymentCreateRequest request)
        {
            AdvancedPayment createdPayment;
            try
            {
                createdPayment = client.Create(request);
            }
            catch (MercadoPagoApiException ex)
            {
                if (ex.StatusCode == 422)
                {
                    Thread.Sleep(5000);
                    ResultsResourcesPage<AdvancedPayment> results =
                        SearchByExternalReference(request.ExternalReference);
                    createdPayment = results?.Results?.First();
                }
                else
                {
                    throw;
                }
            }

            return createdPayment;
        }

        private Task<AdvancedPayment> CaptureAsync(long id)
        {
            return ExecuteAsync(
                () => client.CaptureAsync(id),
                (ex) => ex.StatusCode == 400 && ex.ApiError.Message.Equals("Unable to complete process."));
        }

        private AdvancedPayment Capture(long id)
        {
            return Execute(
                () => client.Capture(id),
                (ex) => ex.StatusCode == 400 && ex.ApiError.Message.Equals("Unable to complete process."));
        }

        private Task<ResultsResourcesPage<AdvancedPayment>> SearchByExternalReferenceAsync(string externalReference)
        {
            var searchRequest = new AdvancedSearchRequest
            {
                Limit = 10,
                Offset = 0,
                Sort = "date_created",
                Criteria = "desc",
                Range = "date_created",
                BeginDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(1).AddMilliseconds(-1),
                Filters = new Dictionary<string, object>
                {
                    ["external_reference"] = externalReference,
                },
            };
            return client.SearchAsync(searchRequest);
        }

        private ResultsResourcesPage<AdvancedPayment> SearchByExternalReference(string externalReference)
        {
            var searchRequest = new AdvancedSearchRequest
            {
                Limit = 10,
                Offset = 0,
                Sort = "date_created",
                Criteria = "desc",
                Range = "date_created",
                BeginDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(1).AddMilliseconds(-1),
                Filters = new Dictionary<string, object>
                {
                    ["external_reference"] = externalReference,
                },
            };
            return client.Search(searchRequest);
        }

        private Task<ResourcesList<AdvancedPaymentDisbursementRefund>> RefundTotalAsync(long id)
        {
            return ExecuteAsync(
                () => client.RefundAllAsync(id),
                (ex) => ex.StatusCode == 400 && ex.ApiError.Message.Equals("cannot set status refunded"));
        }

        private ResourcesList<AdvancedPaymentDisbursementRefund> RefundTotal(long id)
        {
            return Execute(
                () => client.RefundAll(id),
                (ex) => ex.StatusCode == 400 && ex.ApiError.Message.Equals("cannot set status refunded"));
        }

        private async Task<T> ExecuteAsync<T>(Func<Task<T>> func, Func<MercadoPagoApiException, bool> shouldRetry)
        {
            var maxAttempts = 10;
            var attempts = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine($"Attempt: {attempts}");
                    return await func();
                }
                catch (MercadoPagoApiException ex)
                {
                    Console.WriteLine($"Should retry {ex.StatusCode} | {ex.ApiError.Message}: {shouldRetry(ex)}");
                    if (shouldRetry(ex))
                    {
                        if (++attempts == maxAttempts)
                        {
                            throw;
                        }
                        await Task.Delay(1000);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private T Execute<T>(Func<T> func, Func<MercadoPagoApiException, bool> shouldRetry)
        {
            var maxAttempts = 10;
            var attempts = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine($"Attempt: {attempts}");
                    return func();
                }
                catch (MercadoPagoApiException ex)
                {
                    Console.WriteLine($"Should retry {ex.StatusCode} | {ex.ApiError.Message}: {shouldRetry(ex)}");
                    if (shouldRetry(ex))
                    {
                        if (++attempts == maxAttempts)
                        {
                            throw;
                        }
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
