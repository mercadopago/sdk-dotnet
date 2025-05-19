namespace MercadoPago.Tests.Client.Payment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Client.Common;
    using MercadoPago.Client.Payment;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Resource.Payment;
    using MercadoPago.Serialization;
    using MercadoPago.Tests.Client.CardToken;
    using MercadoPago.Tests.Client.Helper;
    using Xunit;

    [Collection("Uses User Email")]
    public class PaymentClientTest : BaseClientTest
    {
        private readonly CardTokenTestClient cardTokenClient;
        private readonly PaymentClient client;

        public PaymentClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            cardTokenClient = new CardTokenTestClient();
            client = new PaymentClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new PaymentClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new PaymentClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new PaymentClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new PaymentClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public async Task CreateAsync_Approved_Success()
        {
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");

            Payment payment = await client.CreateAsync(request);

            Assert.NotNull(payment);
            Assert.NotNull(payment.Id);
            Assert.True(payment.Captured);
            Assert.Equal(request.ExternalReference, payment.ExternalReference);
        }

        [Fact]
        public void Create_Approved_Success()
        {
            PaymentCreateRequest request = BuildCreateRequest(true, "approved");

            Payment payment = client.Create(request);

            Assert.NotNull(payment);
            Assert.NotNull(payment.Id);
            Assert.True(payment.Captured);
            Assert.Equal(request.ExternalReference, payment.ExternalReference);
        }

        [Fact]
        public async Task CancelAsync_PendingPayment_Success()
        {
            // Creates a pending payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "pending");
            Payment payment = await client.CreateAsync(request);

            await Task.Delay(3000);

            // Cancels the payment
            payment = await client.CancelAsync(payment.Id.GetValueOrDefault());

            Assert.NotNull(payment);
            Assert.Equal(PaymentStatus.Cancelled, payment.Status);
        }

        [Fact]
        public void Cancel_PendingPayment_Success()
        {
            // Creates a pending payment
            PaymentCreateRequest request = BuildCreateRequest(true, "pending");
            Payment payment = client.Create(request);

            Thread.Sleep(3000);

            // Cancels the payment
            payment = client.Cancel(payment.Id.GetValueOrDefault());

            Assert.NotNull(payment);
            Assert.Equal(PaymentStatus.Cancelled, payment.Status);
        }

        [Fact]
        public async Task CaptureAsync_Full_Success()
        {
            // Creates a authorized payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(false, "approved");
            Payment payment = await client.CreateAsync(request);

            Assert.NotNull(payment);
            Assert.False(payment.Captured);

            await Task.Delay(3000);

            // Captures the payment
            payment = await client.CaptureAsync(payment.Id.GetValueOrDefault());

            Assert.NotNull(payment);
            Assert.True(payment.Captured);
        }

        [Fact]
        public void Capture_Full_Success()
        {
            // Creates a authorized payment
            PaymentCreateRequest request = BuildCreateRequest(false, "approved");
            Payment payment = client.Create(request);

            Assert.NotNull(payment);
            Assert.False(payment.Captured);

            Thread.Sleep(3000);

            // Captures the payment
            payment = client.Capture(payment.Id.GetValueOrDefault());

            Assert.NotNull(payment);
            Assert.True(payment.Captured);
        }

        [Fact]
        public async Task CaptureAsync_Partial_Success()
        {
            // Creates a authorized payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(false, "approved");
            Payment payment = await client.CreateAsync(request);

            Assert.NotNull(payment);
            Assert.False(payment.Captured);

            await Task.Delay(3000);

            // Captures the payment
            decimal amount = Math.Floor(request.TransactionAmount.GetValueOrDefault() / 2);
            payment = await client.CaptureAsync(payment.Id.GetValueOrDefault(), amount);

            Assert.NotNull(payment);
            Assert.True(payment.Captured);
        }

        [Fact]
        public void Capture_Partial_Success()
        {
            // Creates a authorized payment
            PaymentCreateRequest request = BuildCreateRequest(false, "approved");
            Payment payment = client.Create(request);

            Assert.NotNull(payment);
            Assert.False(payment.Captured);

            Thread.Sleep(3000);

            // Captures the payment
            decimal amount = Math.Floor(request.TransactionAmount.GetValueOrDefault() / 2);
            payment = client.Capture(payment.Id.GetValueOrDefault(), amount);

            Assert.NotNull(payment);
            Assert.True(payment.Captured);
        }

        [Fact]
        public async Task GetAsync_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            Payment createdPayment = await client.CreateAsync(request);

            await Task.Delay(3000);

            // Gets the payment
            Payment payment = await client.GetAsync(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(payment);
            Assert.Equal(createdPayment.Id, payment.Id);
        }

        [Fact]
        public void Get_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = BuildCreateRequest(true, "approved");
            Payment createdPayment = client.Create(request);

            Thread.Sleep(3000);

            // Gets the payment
            Payment payment = client.Get(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(payment);
            Assert.Equal(createdPayment.Id, payment.Id);
        }

        [Fact]
        public async Task SearchAsync_ByExternalReference_Success()
        {
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            Payment createdPayment = await client.CreateAsync(request);

            await Task.Delay(5000);

            var searchRequest = new AdvancedSearchRequest
            {
                Limit = 1,
                Offset = 0,
                Sort = "date_created",
                Criteria = "desc",
                Range = "date_created",
                BeginDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(1).AddMilliseconds(-1),
                Filters = new Dictionary<string, object>
                {
                    ["external_reference"] = createdPayment.ExternalReference,
                },
            };
            ResultsResourcesPage<Payment> results = await client.SearchAsync(searchRequest);

            Assert.NotNull(results);
            Assert.NotNull(results.Paging);
            Assert.Equal(1, results.Paging.Total);
            Assert.NotNull(results.Results);
            Assert.Equal(createdPayment.Id, results.Results.First().Id);
        }

        [Fact(Skip = "Not running in CI.")]
        public void Search_ByExternalReference_Success()
        {
            PaymentCreateRequest request = BuildCreateRequest(true, "approved");
            Payment createdPayment = client.Create(request);

            Thread.Sleep(3000);

            var searchRequest = new AdvancedSearchRequest
            {
                Limit = 1,
                Offset = 0,
                Sort = "date_created",
                Criteria = "desc",
                Range = "date_created",
                BeginDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(1).AddMilliseconds(-1),
                Filters = new Dictionary<string, object>
                {
                    ["external_reference"] = createdPayment.ExternalReference,
                },
            };
            ResultsResourcesPage<Payment> results = client.Search(searchRequest);

            Assert.NotNull(results);
            Assert.NotNull(results.Paging);
            Assert.Equal(1, results.Paging.Total);
            Assert.NotNull(results.Results);
            Assert.Equal(createdPayment.Id, results.Results.First().Id);
        }

        [Fact]
        public async Task RefundAsync_Partial_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            Payment createdPayment = await client.CreateAsync(request);

            await Task.Delay(7000);

            PaymentRefund refund =
                await client.RefundAsync(createdPayment.Id.GetValueOrDefault(), 5);

            Assert.NotNull(refund);
            Assert.NotNull(refund.Id);
            Assert.Equal(createdPayment.Id, refund.PaymentId);
        }

        [Fact]
        public void Refund_Partial_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = BuildCreateRequest(true, "approved");
            Payment createdPayment = client.Create(request);

            Thread.Sleep(7000);

            PaymentRefund refund =
                client.Refund(createdPayment.Id.GetValueOrDefault(), 5);

            Assert.NotNull(refund);
            Assert.NotNull(refund.Id);
            Assert.Equal(createdPayment.Id, refund.PaymentId);
        }

        [Fact]
        public async Task RefundAsync_Total_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            Payment createdPayment = await client.CreateAsync(request);

            await Task.Delay(7000);

            PaymentRefund refund =
                await client.RefundAsync(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(refund);
            Assert.NotNull(refund.Id);
            Assert.Equal(createdPayment.Id, refund.PaymentId);
        }

        [Fact]
        public void Refund_Total_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = BuildCreateRequest(true, "approved");
            Payment createdPayment = client.Create(request);

            Thread.Sleep(7000);

            PaymentRefund refund =
                client.Refund(createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(refund);
            Assert.NotNull(refund.Id);
            Assert.Equal(createdPayment.Id, refund.PaymentId);
        }

        [Fact]
        public async Task GetRefundAsync_Total_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            Payment createdPayment = await client.CreateAsync(request);

            await Task.Delay(7000);

            // Creates a refund
            PaymentRefund createdRefund =
                await client.RefundAsync(createdPayment.Id.GetValueOrDefault());

            await Task.Delay(3000);

            // Gets the refund
            PaymentRefund refund = await client.GetRefundAsync(
                createdPayment.Id.GetValueOrDefault(),
                createdRefund.Id.GetValueOrDefault());

            Assert.NotNull(refund);
            Assert.Equal(createdRefund.Id, refund.Id);
        }

        [Fact]
        public void GetRefund_Total_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = BuildCreateRequest(true, "approved");
            Payment createdPayment = client.Create(request);

            Thread.Sleep(7000);

            // Creates a refund
            PaymentRefund createdRefund =
                client.Refund(createdPayment.Id.GetValueOrDefault());

            Thread.Sleep(3000);

            // Gets the refund
            PaymentRefund refund = client.GetRefund(
                createdPayment.Id.GetValueOrDefault(),
                createdRefund.Id.GetValueOrDefault());

            Assert.NotNull(refund);
            Assert.Equal(createdRefund.Id, refund.Id);
        }

        [Fact]
        public async Task ListRefundsAsync_Total_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = await BuildCreateRequestAsync(true, "approved");
            Payment createdPayment = await client.CreateAsync(request);

            await Task.Delay(7000);

            // Creates a refund
            PaymentRefund createdRefund =
                await client.RefundAsync(createdPayment.Id.GetValueOrDefault());

            await Task.Delay(3000);

            // List the refund
            ResourcesList<PaymentRefund> refunds = await client.ListRefundsAsync(
                createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(refunds);
            Assert.Equal(createdRefund.Id, refunds.First().Id);
        }

        [Fact]
        public void ListRefunds_Total_Success()
        {
            // Creates a payment
            PaymentCreateRequest request = BuildCreateRequest(true, "approved");
            Payment createdPayment = client.Create(request);

            Thread.Sleep(7000);

            // Creates a refund
            PaymentRefund createdRefund =
                client.Refund(createdPayment.Id.GetValueOrDefault());

            Thread.Sleep(3000);

            // List the refund
            ResourcesList<PaymentRefund> refunds = client.ListRefunds(
                createdPayment.Id.GetValueOrDefault());

            Assert.NotNull(refunds);
            Assert.Equal(createdRefund.Id, refunds.First().Id);
        }

        private async Task<PaymentCreateRequest> BuildCreateRequestAsync(
            bool capture, string paymentStatus)
        {
            CardToken cardToken =
                await cardTokenClient.CreateTestCardToken(User, paymentStatus);

            return new PaymentCreateRequest
            {
                Payer = new PaymentPayerRequest
                {
                    Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                    EntityType = "individual",
                    Type = "customer",
                    Identification = IdentificationHelper.GetIdentification(User),
                    FirstName = "Test",
                    LastName = "User",
                },
                BinaryMode = false,
                Capture = capture,
                ExternalReference = Guid.NewGuid().ToString(),
                Description = "Payment description",
                Metadata = new Dictionary<string, object>
                {
                    ["key1"] = "value1",
                    ["key2"] = "value2",
                },
                TransactionAmount = 10,
                PaymentMethodId = "master",
                Token = cardToken.Id,
                Installments = 1,
                StatementDescriptor = "STAT-DESC",
                NotificationUrl = "https://seu-site.com.br/webhooks",
                CallbackUrl = "https://seu-site.com.br/callbackurl",
                ProcessingMode = "aggregator",
                DateOfExpiration = DateTime.Now.AddDays(30),
                AdditionalInfo = new PaymentAdditionalInfoRequest
                {
                    IpAddress = "127.0.0.1",
                    Items = new List<PaymentItemRequest>
                    {
                        new PaymentItemRequest
                        {
                            Id = "SKU-1",
                            Title = "Product",
                            PictureUrl = "https://www.mercadopago.com/org-img/MLB/design/2015/m_pago/logos/mp_processado_02.png",
                            Description = "Product description",
                            CategoryId = "cat",
                            Quantity = 1,
                            UnitPrice = 10,
                            Warranty = false,
                            EventDate = DateTime.Now,
                            CategoryDescriptor = new PaymentCategoryDescriptorRequest
                            {
                                Passenger = new PaymentPassengerRequest
                                {
                                    Identification = IdentificationHelper.GetIdentification(User),
                                    FirstName = "Test",
                                    LastName = "User",
                                },
                                Route = new PaymentRouteRequest
                                {
                                    ArrivalDateTime = DateTime.Now.AddDays(30),
                                    Company = "company",
                                    Departure = "derpature",
                                    DepartureDateTime = DateTime.Now.AddDays(30),
                                    Destination = "destination",
                                },
                            },
                        },
                    },
                    Payer = new PaymentAdditionalInfoPayerRequest
                    {
                        FirstName = "Test",
                        LastName = "User",
                        RegistrationDate = DateTime.Now.AddDays(-30),
                        Phone = new PhoneRequest
                        {
                            AreaCode = "11",
                            Number = "999999999",
                        },
                        Address = new AddressRequest
                        {
                            StreetName = "Street",
                            StreetNumber = 123,
                        },
                        AuthenticationType = "None",
                        IsFirstPurchaseOnline = false,
                        IsPrimeUser = false,
                        LastPurchase = DateTime.Now.AddDays(-10),
                    },
                    Shipments = new PaymentShipmentsRequest
                    {
                        ReceiverAddress = new PaymentReceiverAddressRequest
                        {
                            StreetName = "Street",
                            StreetNumber = 123,
                            Apartment = "23",
                            Floor = "First",
                            CityName = "City",
                            StateName = "State",
                        },
                        ExpressShipment = false,
                        LocalPickup = false,
                    },
                },
            };
        }

        private PaymentCreateRequest BuildCreateRequest(bool capture, string paymentStatus)
        {
            return BuildCreateRequestAsync(capture, paymentStatus)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
