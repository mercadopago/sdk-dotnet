using System.Text;
using MercadoPago.Client;
using MercadoPago.Client.CardToken;
using MercadoPago.Client.Common;
using MercadoPago.Client.Customer;
using MercadoPago.Client.Order;
using MercadoPago.Client.Payment;
using MercadoPago.Error;
using MercadoPago.Http;
using MercadoPago.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Payment = MercadoPago.Resource.Payment.Payment;

// Only published MLB/MLM/MLA/MCO test cards are used. Secrets are read and decoded in memory.
// Reference: https://www.mercadopago.com.br/developers/pt/docs/automatic-payments/Integration-test
var mode = args.Length == 0 ? "preflight" : args[0];
if (mode != "preflight" && mode != "initial" && mode != "tokenize" && mode != "orders" && mode != "payments" && mode != "cof-direct")
{
    Console.Error.WriteLine("Use preflight, tokenize, initial, orders, payments, or cof-direct.");
    return 2;
}
var expectedSite = Environment.GetEnvironmentVariable("MP_TEST_SITE") ?? "MLB";
if (expectedSite != "MLB" && expectedSite != "MLM" && expectedSite != "MLA" && expectedSite != "MCO")
{
    Console.Error.WriteLine("MP_TEST_SITE must be MLB, MLM, MLA, or MCO.");
    return 2;
}
var encoded = Environment.GetEnvironmentVariable("MP_TOKEN_BASE64") ?? Environment.GetEnvironmentVariable("MLB_TOKEN");
if (string.IsNullOrWhiteSpace(encoded))
{
    Console.Error.WriteLine("MP_TOKEN_BASE64 (or MLB_TOKEN) is missing. Provide the Base64 value in the environment.");
    return 2;
}
string accessToken;
try
{
    accessToken = Encoding.UTF8.GetString(Convert.FromBase64String(encoded)).Trim();
    if (string.IsNullOrEmpty(accessToken) || accessToken.Any(char.IsWhiteSpace))
        throw new FormatException();
}
catch (FormatException)
{
    Console.Error.WriteLine("The token variable does not contain a valid Base64 credential.");
    return 2;
}

using var transport = new ProbeTransport(accessToken);
var serializer = new DefaultSerializer();
var options = new RequestOptions { AccessToken = accessToken };
var report = new JObject
{
    ["mode"] = mode,
    ["expected_site"] = expectedSite,
    ["utc"] = DateTime.UtcNow.ToString("O"),
    ["first_time_use_property_type"] = typeof(PaymentTransactionDataRequest).GetProperty("FirstTimeUse").PropertyType.ToString(),
    ["steps"] = transport.Steps,
};
var stage = "preflight";
var resultCode = 2;
try
{
    if (mode == "tokenize")
    {
        stage = "tokenize_test_card";
        transport.Stage = stage;
        var cardToken = await TokenizeTestCard(transport, serializer, options, expectedSite);
        transport.Secrets.Add(cardToken.Id);
        report["card_token_live_mode"] = cardToken.LiveMode;
        report["outcome"] = "test_card_tokenized";
        resultCode = 0;
    }
    else
    {
        var account = await transport.GetAccountAsync();
        report["site_id"] = account.Value<string>("site_id");
        var testAccount = (account["tags"] as JArray)?.Values<string>().Contains("test_user") == true;
        report["test_user_tag"] = testAccount;
        if (account.Value<string>("site_id") != expectedSite)
            throw new InvalidOperationException("The account site does not match MP_TEST_SITE.");
        if (mode == "preflight")
        {
            report["outcome"] = "preflight_passed";
            resultCode = 0;
        }
        else if (mode == "payments" || mode == "cof-direct")
        {
            stage = "tokenize_test_card";
            transport.Stage = stage;
            var cardToken = await TokenizeTestCard(transport, serializer, options, expectedSite);
            transport.Secrets.Add(cardToken.Id);
            report["card_token_live_mode"] = cardToken.LiveMode;
            if (cardToken.LiveMode != false && !testAccount)
                throw new InvalidOperationException("A test account or explicit test-mode token is required before creating payments.");
            var paymentClient = new PaymentClient(transport, serializer);
            var request = new PaymentCreateRequest
            {
                TransactionAmount = expectedSite == "MCO" ? 10000 : 50,
                Token = cardToken.Id,
                Installments = 1,
                PaymentMethodId = "master",
                ExternalReference = "sdk-payments-probe-" + Guid.NewGuid().ToString("N"),
                Description = "SDK standard test payment",
                Payer = new PaymentPayerRequest
                {
                    Email = TestPayerEmail(accessToken),
                    Identification = TestIdentification(expectedSite),
                },
            };
            if (mode == "cof-direct")
            {
                request.PointOfInteraction = new PaymentPointOfInteractionRequest
                {
                    Type = "CREDENTIAL_ON_FILE",
                    SubType = "recurring",
                    TransactionData = new PaymentTransactionDataRequest
                    {
                        FirstTransaction = true,
                        Storage = "store",
                        TransactionInitiator = "customer",
                        SubscriptionId = Guid.NewGuid().ToString("N"),
                        SubscriptionSequence = new PaymentSubscriptionSequenceRequest { Number = 1, Total = 2 },
                        BillingDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                        InvoicePeriod = new PaymentInvoicePeriodRequest { Period = 1, Type = "monthly" },
                    },
                };
            }
            stage = mode == "cof-direct" ? "create_direct_cof_payment" : "create_standard_payment";
            transport.Stage = stage;
            var payment = await paymentClient.CreateAsync(request, options);
            report["created_payment"] = PaymentSummary(payment);
            stage = "get_payment";
            transport.Stage = stage;
            report["payment"] = PaymentSummary(await paymentClient.GetAsync(payment.Id.Value, options));
            report["outcome"] = mode == "cof-direct" ? "direct_cof_payment_created_and_retrieved" : "standard_payment_created_and_retrieved";
            resultCode = 0;
        }
        else if (mode == "orders")
        {
            stage = "tokenize_test_card";
            transport.Stage = stage;
            var cardToken = await TokenizeTestCard(transport, serializer, options, expectedSite);
            transport.Secrets.Add(cardToken.Id);
            report["card_token_live_mode"] = cardToken.LiveMode;
            if (cardToken.LiveMode != false && !testAccount)
                throw new InvalidOperationException("A test account or explicit test-mode token is required before creating orders.");

            var orderClient = new OrderClient(transport, serializer);
            var request = new OrderCreateRequest
            {
                Type = "online",
                ProcessingMode = "automatic",
                CaptureMode = null,
                TotalAmount = expectedSite == "MCO" ? "10000.00" : "50.00",
                ExternalReference = "sdk-orders-probe-" + Guid.NewGuid().ToString("N"),
                Payer = new OrderPayerRequest { Email = "test@testuser.com" },
                Transactions = new OrderTransactionRequest
                {
                    Payments = new List<OrderPaymentRequest>
                    {
                        new OrderPaymentRequest
                        {
                            Amount = expectedSite == "MCO" ? "10000.00" : "50.00",
                            PaymentMethod = new OrderPaymentMethodRequest
                            {
                                Id = "master",
                                Type = "credit_card",
                                Token = cardToken.Id,
                                Installments = 1,
                            },
                        },
                    },
                },
            };
            stage = "create_order";
            transport.Stage = stage;
            var order = await orderClient.CreateAsync(request, options);
            report["created_order"] = OrderSummary(order);
            stage = "get_order";
            transport.Stage = stage;
            report["order"] = OrderSummary(await orderClient.GetAsync(order.Id, options));
            report["outcome"] = "order_created_and_retrieved";
            resultCode = 0;
        }
        else
        {
            var runId = Guid.NewGuid().ToString("N");
            var customerClient = new CustomerClient(transport, serializer);
            var tokenClient = new CardTokenClient(transport, serializer);
            var paymentClient = new PaymentClient(transport, serializer);
            stage = "create_customer";
            transport.Stage = stage;
            var customer = await customerClient.CreateAsync(new CustomerRequest
            {
                Email = TestPayerEmail(accessToken),
                Identification = TestIdentification(expectedSite),
            }, options);

            stage = "tokenize_test_card";
            transport.Stage = stage;
            var rawToken = await TokenizeTestCard(transport, serializer, options, expectedSite);
            transport.Secrets.Add(rawToken.Id);
            report["card_token_live_mode"] = rawToken.LiveMode;
            if (rawToken.LiveMode != false && !testAccount)
                throw new InvalidOperationException("A test account or explicit test-mode token is required before creating payments.");

            stage = "save_test_card";
            transport.Stage = stage;
            var card = await customerClient.CreateCardAsync(customer.Id,
                new CustomerCardCreateRequest { Token = rawToken.Id, PaymentMethodId = "master" }, options);

            stage = "tokenize_saved_card_cit";
            transport.Stage = stage;
            var citToken = await tokenClient.CreateAsync(new CardTokenRequest
            {
                CardId = card.Id,
                CustomerId = customer.Id,
                SecurityCode = "123",
            }, options);
            transport.Secrets.Add(citToken.Id);
            if (citToken.LiveMode != false && !testAccount)
                throw new InvalidOperationException("A test account or explicit test-mode saved card token is required.");

            var request = new PaymentCreateRequest
            {
                TransactionAmount = expectedSite == "MCO" ? 10000 : 10,
                Token = citToken.Id,
                Installments = 1,
                PaymentMethodId = "master",
                Description = "COF SDK serialization regression test",
                Payer = new PaymentPayerRequest
                {
                    Id = customer.Id,
                    Type = "customer",
                    Identification = TestIdentification(expectedSite),
                },
                PointOfInteraction = new PaymentPointOfInteractionRequest
                {
                    Type = "CREDENTIAL_ON_FILE",
                    SubType = "recurring",
                    TransactionData = new PaymentTransactionDataRequest
                    {
                        FirstTransaction = true,
                        Storage = "store",
                        TransactionInitiator = "customer",
                        SubscriptionId = runId,
                        SubscriptionSequence = new PaymentSubscriptionSequenceRequest { Number = 1, Total = 2 },
                        BillingDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                        InvoicePeriod = new PaymentInvoicePeriodRequest { Period = 1, Type = "monthly" },
                    },
                },
            };
            stage = "create_initial_cit";
            transport.Stage = stage;
            var payment = await paymentClient.CreateAsync(request, options);
            report["initial_payment"] = PaymentSummary(payment);
            if (payment.LiveMode != false && !testAccount)
                throw new InvalidOperationException("Unexpected live payment response.");
            report["outcome"] = "initial_request_accepted";
            resultCode = 0;

            // An approved CIT is needed to test a genuine subsequent MIT chain.
            if (payment.Status == "approved")
            {
                stage = "tokenize_saved_card_mit";
                transport.Stage = stage;
                var mitToken = await tokenClient.CreateAsync(new CardTokenRequest
                {
                    CardId = card.Id,
                    CustomerId = customer.Id,
                }, options);
                transport.Secrets.Add(mitToken.Id);
                if (mitToken.LiveMode != false && !testAccount)
                    throw new InvalidOperationException("A test account or explicit test-mode MIT token is required.");
                request.Token = mitToken.Id;
                request.PointOfInteraction.TransactionData.FirstTransaction = false;
                request.PointOfInteraction.TransactionData.Storage = "stored";
                request.PointOfInteraction.TransactionData.TransactionInitiator = "merchant";
                request.PointOfInteraction.TransactionData.SubscriptionSequence.Number = 2;
                request.PointOfInteraction.TransactionData.Reference = new PaymentReferenceRequest { Id = payment.Id.ToString() };
                request.PointOfInteraction.TransactionData.NetworkTransactionId = payment.Expanded?.Gateway?.Reference?.NetworkTransactionId;
                stage = "create_subsequent_mit";
                transport.Stage = stage;
                var subsequent = await paymentClient.CreateAsync(request, options);
                report["subsequent_payment"] = PaymentSummary(subsequent);
                report["outcome"] = "cit_and_mit_requests_accepted";
            }
            else
            {
                report["mit"] = "not_attempted_initial_cit_not_approved";
            }
        }
    }
}
catch (MercadoPagoApiException error)
{
    report["outcome"] = "api_error";
    report["failed_stage"] = stage;
    report["http_status"] = error.StatusCode;
    resultCode = 1;
}
catch (Exception error)
{
    report["outcome"] = "probe_error";
    report["failed_stage"] = stage;
    report["error_type"] = error.GetType().Name;
    var diagnostic = error.InnerException ?? error;
    report["inner_error_type"] = diagnostic.GetType().Name;
    if (diagnostic is FileNotFoundException missing) report["missing_assembly"] = transport.Sanitize(missing.FileName);
    if (diagnostic is HttpRequestException || diagnostic is InvalidOperationException || diagnostic is FormatException || diagnostic is ArgumentException)
        report["diagnostic"] = transport.Sanitize(diagnostic.Message);
    // Only fixed local guard messages are exposed, never HTTP exception details.
    if (error is InvalidOperationException) report["reason"] = transport.Sanitize(error.Message);
    resultCode = 2;
}
Console.WriteLine(report.ToString(Formatting.Indented));
return resultCode;

static JObject PaymentSummary(Payment payment) => new JObject
{
    ["id"] = payment.Id,
    ["status"] = payment.Status,
    ["status_detail"] = payment.StatusDetail,
    ["live_mode"] = payment.LiveMode,
};

static JObject OrderSummary(MercadoPago.Resource.Order.Order order) => new JObject
{
    ["id"] = order.Id,
    ["status"] = order.Status,
    ["status_detail"] = order.StatusDetail,
    ["total_amount"] = order.TotalAmount,
    ["total_paid_amount"] = order.TotalPaidAmount,
    ["country_code"] = order.CountryCode,
    ["external_reference"] = order.ExternalReference,
    ["payments"] = new JArray((order.Transactions?.Payments ?? new List<MercadoPago.Resource.Order.OrderPayment>()).Select(payment => new JObject
    {
        ["id"] = payment.Id,
        ["status"] = payment.Status,
        ["status_detail"] = payment.StatusDetail,
        ["amount"] = payment.Amount,
        ["paid_amount"] = payment.PaidAmount,
    })),
};

static Task<MercadoPago.Resource.CardToken.CardToken> TokenizeTestCard(ProbeTransport transport, ISerializer serializer, RequestOptions options, string site)
    => new CardTokenClient(transport, serializer).CreateAsync(new CardTokenRequest
    {
        CardNumber = site switch
        {
            "MLB" => "5480832801033311",
            "MLM" => "5474925432670366",
            "MLA" => "5031755734530604",
            "MCO" => "5254133674403564",
            _ => throw new InvalidOperationException("Unsupported test-card site."),
        },
        ExpirationMonth = 11,
        ExpirationYear = 2030,
        SecurityCode = "123",
        Cardholder = new CustomerCardCardholderRequest
        {
            Name = "APRO",
            Identification = TestIdentification(site),
        },
    }, options);

static IdentificationRequest TestIdentification(string site) => site switch
{
    "MLB" => new IdentificationRequest { Type = "CPF", Number = "12345678909" },
    "MLA" => new IdentificationRequest { Type = "DNI", Number = "12345678" },
    "MCO" => new IdentificationRequest { Type = "CC", Number = "123456789" },
    _ => null,
};

static string TestPayerEmail(string token) => token.StartsWith("TEST-", StringComparison.Ordinal)
    ? "test_payer@example.com"
    : "test_payer_" + System.Security.Cryptography.RandomNumberGenerator.GetInt32(100000000, int.MaxValue) + "@testuser.com";

sealed class ProbeTransport : MercadoPago.Http.IHttpClient, IDisposable
{
    private readonly System.Net.Http.HttpClient client = new(new HttpClientHandler { AllowAutoRedirect = false })
    {
        Timeout = TimeSpan.FromSeconds(30),
    };
    private readonly string accessToken;
    public string Stage { get; set; } = "preflight";
    public JArray Steps { get; } = new();
    public List<string> Secrets { get; } = new() { "5480832801033311", "5474925432670366", "5031755734530604", "5254133674403564", "12345678909", "123456789", "12345678" };

    public ProbeTransport(string token) { accessToken = token; Secrets.Add(token); }

    public async Task<JObject> GetAccountAsync()
    {
        var request = new MercadoPagoRequest { Url = "https://api.mercadopago.com/users/me" };
        request.Headers["Authorization"] = "Bearer " + accessToken;
        var response = await SendAsync(request, null, CancellationToken.None);
        if (response.StatusCode != 200) throw new MercadoPagoApiException("Account preflight failed.", response);
        return JObject.Parse(response.Content);
    }

    public async Task<MercadoPagoResponse> SendAsync(MercadoPagoRequest request, IRetryStrategy retryStrategy, CancellationToken cancellationToken)
    {
        var destination = new Uri(request.Url);
        if (destination.Scheme != "https" || destination.Host != "api.mercadopago.com" || destination.Port != 443)
            throw new InvalidOperationException("Unexpected API destination.");
        using var outgoing = new HttpRequestMessage(new System.Net.Http.HttpMethod(request.Method.ToString()), destination);
        if (request.Content != null) outgoing.Content = new StringContent(request.Content, Encoding.UTF8, "application/json");
        foreach (var header in request.Headers) outgoing.Headers.TryAddWithoutValidation(header.Key, header.Value);
        using var response = await client.SendAsync(outgoing, cancellationToken);
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var entry = new JObject { ["stage"] = Stage, ["http_status"] = (int)response.StatusCode };
        if (destination.AbsolutePath == "/v1/payments" && request.Content != null)
        {
            var body = JObject.Parse(request.Content);
            entry["point_of_interaction"] = body["point_of_interaction"]?.DeepClone();
            body["token"] = "[REDACTED]";
            entry["payment_request"] = body;
        }
        if (destination.AbsolutePath == "/v1/orders" && request.Content != null)
        {
            var body = JObject.Parse(request.Content);
            foreach (var payment in body["transactions"]?["payments"] as JArray ?? new JArray())
                if (payment["payment_method"] is JObject method) method["token"] = "[REDACTED]";
            entry["order_request"] = body;
        }
        if (!response.IsSuccessStatusCode)
        {
            try
            {
                var body = JObject.Parse(content);
                entry["api_message"] = Sanitize(body.Value<string>("message"));
                entry["api_error"] = Sanitize(body.Value<string>("error"));
                entry["errors"] = new JArray((body["errors"] as JArray ?? new JArray()).Select(error => new JObject
                {
                    ["code"] = Sanitize(error["code"]?.ToString()),
                    ["message"] = Sanitize(error["message"]?.ToString()),
                    ["details"] = Sanitize(error["details"]?.ToString()),
                }));
                entry["causes"] = new JArray((body["cause"] as JArray ?? new JArray()).Select(cause => new JObject
                {
                    ["code"] = Sanitize(cause["code"]?.ToString()),
                    ["description"] = Sanitize(cause.Value<string>("description")),
                }));
            }
            catch (JsonException) { entry["api_message"] = "non_json_error_response"; }
        }
        Steps.Add(entry);
        var headers = response.Headers.ToDictionary(pair => pair.Key, pair => string.Join(",", pair.Value));
        return new MercadoPagoResponse((int)response.StatusCode, headers, content);
    }

    public string Sanitize(string value)
    {
        if (value == null) return null;
        foreach (var secret in Secrets.Where(secret => !string.IsNullOrEmpty(secret))) value = value.Replace(secret, "[REDACTED]");
        return value.Length > 1000 ? value.Substring(0, 1000) : value;
    }
    public void Dispose() => client.Dispose();
}
