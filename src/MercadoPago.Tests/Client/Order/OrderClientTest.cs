namespace MercadoPago.Tests.Client.Order
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MercadoPago.Client.Order;
    using MercadoPago.Client;
    using MercadoPago.Config;
    using MercadoPago.Http;
    using MercadoPago.Resource.Order;
    using MercadoPago.Serialization;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Tests.Client.CardToken;
    using Xunit;

    public class OrderClientTest : BaseClientTest
    {

        private const string automatic = "automatic";
        private const string automaticAsync = "automatic_async";
        private const string manual = "manual";
        private const string processed = "processed";
        private const string canceled = "canceled";
        private const string refunded = "refunded";
        private const string partiallyRefunded = "partially_refunded";

        private readonly OrderClient orderClient;

        private readonly CardTokenTestClient cardTokenClient;

        public OrderClientTest(ClientFixture clientFixture)
            : base(clientFixture)
        {
            cardTokenClient = new CardTokenTestClient();
            orderClient = new OrderClient();
        }

        [Fact]
        public void Constructor_HttpClientAndSerializer_Success()
        {
            var httpClient = new DefaultHttpClient();
            var serializer = new DefaultSerializer();
            var client = new OrderClient(httpClient, serializer);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_HttpClient_Success()
        {
            var httpClient = new DefaultHttpClient();
            var client = new OrderClient(httpClient);

            Assert.Equal(httpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_Serializer_Success()
        {
            var serializer = new DefaultSerializer();
            var client = new OrderClient(serializer);

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(serializer, client.Serializer);
        }

        [Fact]
        public void Constructor_NullParameters_Success()
        {
            var client = new OrderClient();

            Assert.Equal(MercadoPagoConfig.HttpClient, client.HttpClient);
            Assert.Equal(MercadoPagoConfig.Serializer, client.Serializer);
        }

        [Fact]
        public async Task Create_Success()
        {
            OrderCreateRequest request = await BuildRequest(automatic, automaticAsync);

            Order order = await orderClient.CreateAsync(request);

            Assert.NotNull(order);
            Assert.NotNull(order.Id);
            Assert.Equal(processed, order.Status);
        }

        [Fact]
        public async Task Process_Success()
        {
            OrderCreateRequest request = await BuildRequest(manual, automaticAsync);
            Order createOrder = await orderClient.CreateAsync(request);

            var requestOptions = new RequestOptions { };
            requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());

            Order orderProcess = orderClient.Process(createOrder.Id, requestOptions);

            Assert.NotNull(orderProcess);
            Assert.Equal(processed, orderProcess.Status);
        }

        [Fact]
        public async Task Get_Success()
        {
            OrderCreateRequest request = await BuildRequest(automatic, automaticAsync);
            Order createOrder = await orderClient.CreateAsync(request);

            Order order = orderClient.Get(createOrder.Id);

            Assert.NotNull(order);
            Assert.Equal(processed, order.Status);
        }

        [Fact]
        public async Task Capture_Success()
        {
            OrderCreateRequest request = await BuildRequest(automatic, manual);
            Order createOrder = await orderClient.CreateAsync(request);

            var requestOptions = new RequestOptions { };
            requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());

            Order orderCapture = orderClient.Capture(createOrder.Id, requestOptions);

            Assert.NotNull(orderCapture);
            Assert.Equal(processed, orderCapture.Status);
        }

        [Fact]
        public async Task Cancel_Success()
        {
            OrderCreateRequest request = await BuildRequest(manual, automaticAsync);
            Order createOrder = await orderClient.CreateAsync(request);

            var requestOptions = new RequestOptions { };
            requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());

            Order orderCanceled = orderClient.Cancel(createOrder.Id, requestOptions);

            Assert.NotNull(orderCanceled);
            Assert.Equal(canceled, orderCanceled.Status);
        }

        [Fact]
        public async Task RefundTotal_Success()
        {
            OrderCreateRequest request = await BuildRequest(automatic, automaticAsync);

            Order createOrder = await orderClient.CreateAsync(request);
            var requestOptions = new RequestOptions { };
            requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());

            Order orderRefund = orderClient.Refund(createOrder.Id, null, requestOptions);

            Assert.NotNull(orderRefund);
            Assert.Equal(refunded, orderRefund.Status);
            Assert.Equal(refunded, orderRefund.StatusDetail);
            Assert.Equal(processed, orderRefund.Transactions.Refunds[0].Status);
        }

        [Fact]
        public async Task RefundPartial_Success()
        {
            OrderCreateRequest request = await BuildRequest(automatic, automaticAsync);
            Order createOrder = await orderClient.CreateAsync(request);

            var requestOptions = new RequestOptions { };
            requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());

            OrderRefundPaymentRequest refund = new OrderRefundPaymentRequest
            {
                Transactions = new List<OrderRefundTransactionRequest>{
                    new OrderRefundTransactionRequest{
                        Id = createOrder.Transactions.Payments[0].Id,
                        Amount = "500.00"
                    }
                }
            };

            Order orderProcess = orderClient.Refund(createOrder.Id, refund, requestOptions);

            Assert.NotNull(orderProcess);
            Assert.Equal(processed, orderProcess.Status);
            Assert.Equal(partiallyRefunded, orderProcess.StatusDetail);
            Assert.Equal(processed, orderProcess.Transactions.Refunds[0].Status);
        }

        [Fact]
        public async Task CreateTransaction_Success()
        {
            OrderCreateRequest request = BuildRequestWithoutTransaction(manual, automaticAsync);
            Order createOrder = await orderClient.CreateAsync(request);

            CardToken cardToken = await cardTokenClient.CreateTestCardToken(User, "approved");

            OrderTransactionRequest transaction = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>{
                    new OrderPaymentRequest{
                        Amount = "1000.00",
                        PaymentMethod = new OrderPaymentMethodRequest{
                            Id = "master",
                                Type = "credit_card",
                                Token = cardToken.Id,
                                Installments = 1,
                        }
                    }
                }
            };

            var requestOptions = new RequestOptions { };
            requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());
            OrderTransaction orderTransaction = orderClient.CreateTransaction(createOrder.Id, transaction, requestOptions);

            Assert.NotNull(orderTransaction);
            Assert.NotEmpty(orderTransaction.Payments);
            Assert.NotEmpty(orderTransaction.Payments[0].Id);

            Order orderGet = orderClient.Get(createOrder.Id);
            Assert.Equal(orderTransaction.Payments[0].Id, orderGet.Transactions.Payments[0].Id);
        }

        [Fact]
        public async Task UpdateTransaction_Success()
        {
            OrderCreateRequest request = await BuildRequest(manual, automaticAsync);
            Order order = await orderClient.CreateAsync(request);

            OrderPaymentRequest paymentRequest = new OrderPaymentRequest
            {
                PaymentMethod = new OrderPaymentMethodRequest
                {
                    Id = "master",
                    Type = "credit_card",
                    Installments = 3
                }
            };

            var requestOptions = new RequestOptions { };
            requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, Guid.NewGuid().ToString());
            OrderUpdateTransaction transactionRequest = orderClient.UpdateTransaction(order.Id, order.Transactions.Payments[0].Id, paymentRequest, requestOptions);

            Assert.Equal(transactionRequest.PaymentMethod.Installments, paymentRequest.PaymentMethod.Installments);
        }

        [Fact]
        public async Task DeleteTransaction_Success()
        {
            OrderCreateRequest request = await BuildRequest(manual, automaticAsync);
            Order order = await orderClient.CreateAsync(request);

            OrderTransaction orderTransaction = orderClient.DeleteTransaction(order.Id, order.Transactions.Payments[0].Id);

            Assert.Null(orderTransaction);

            Order getOrder = orderClient.Get(order.Id);
            Assert.Null(getOrder.Transactions);
        }

        private async Task<OrderCreateRequest> BuildRequest(string processingMode, string captureMode)
        {

            CardToken cardToken = await cardTokenClient.CreateTestCardToken(User, "approved");
            OrderCreateRequest order = new OrderCreateRequest
            {
                Type = "online",
                TotalAmount = "1000.00",
                ExternalReference = "ext_ref_1234",
                ProcessingMode = processingMode,
                CaptureMode = captureMode,
                Transactions = new OrderTransactionRequest
                {
                    Payments = new List<OrderPaymentRequest>
                    {
                        new OrderPaymentRequest
                        {
                            Amount = "1000.00",
                            PaymentMethod = new OrderPaymentMethodRequest
                            {
                                Id = "master",
                                Type = "credit_card",
                                Token = cardToken.Id,
                                Installments = 1,
                            }
                        }
                    }
                },
                Payer = new OrderPayerRequest
                {
                    Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                },
            };
            return order;
        }

        private OrderCreateRequest BuildRequestWithoutTransaction(string processingMode, string captureMode)
        {
            OrderCreateRequest order = new OrderCreateRequest
            {
                Type = "online",
                TotalAmount = "1000.00",
                ExternalReference = "ext_ref_1234",
                ProcessingMode = processingMode,
                CaptureMode = captureMode,
                Payer = new OrderPayerRequest
                {
                    Email = Environment.GetEnvironmentVariable("USER_EMAIL"),
                },
            };
            return order;
        }
    }
}
