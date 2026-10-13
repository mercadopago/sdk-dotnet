<div align="center">
  <img src="assets/mercado-pago.svg" alt="Mercado Pago" width="120" />
  <h1>Mercado Pago SDK for .NET</h1>
  <p><strong>The official Mercado Pago SDK for .NET applications.</strong></p>
  <p>Integrate Mercado Pago payments with an idiomatic client for .NET and .NET Standard.</p>
  <p>
    <a href="https://github.com/mercadopago/sdk-dotnet/actions/workflows/ci.yml"><img src="assets/badges/ci.svg" alt="CI workflow" /></a>
    <a href="#installation"><img src="assets/badges/package.svg" alt="NuGet package" /></a>
    <img src="assets/badges/runtime.svg" alt=".NET 8.0 or later" />
    <a href="LICENSE"><img src="assets/badges/license.svg" alt="MIT license" /></a>
  </p>
  <p>
    <a href="#installation">Installation</a> ·
    <a href="#getting-started">Getting started</a> ·
    <a href="#documentation">Documentation</a> ·
    <a href="#contributing">Contributing</a>
  </p>
  <p><a href="README.es.md">Español</a> · <a href="README.pt.md">Português</a></p>
</div>

---

## 💡 Requirements

**.NET 8.0+** and **.NET Standard 2.1+**.

If you are using previous versions of .NET Framework in your project, please refer to the [older versions](https://github.com/mercadopago/sdk-dotnet/tree/master-dotnet-framework) of the SDK.

## 📲 Installation

Use one of the following options, depending on your preferred environment.

### From Visual Studio

1. Open the `Solution Explorer`.
2. Right-click on a project within your solution.
3. Click on `Manage NuGet Packages...`.
4. Click on the `Browse` tab and search for "mercadopago-sdk".
5. Click on the `mercadopago-sdk` package, select the appropriate version and click Install.

### Using the Package Manager

```bash
Install-Package mercadopago-sdk
```

### Using the .NET Core command-line interface (CLI) tools

```bash
dotnet add package mercadopago-sdk
```

### Using the NuGet Command Line Interface (CLI)

```bash
nuget install mercadopago-sdk
```

## 🌟 Getting Started

First time using Mercado Pago? Create your [Mercado Pago account](https://www.mercadopago.com).

Copy your `Access Token` in the [credentials panel](https://www.mercadopago.com/developers/panel/app) and replace the text `YOUR_ACCESS_TOKEN` with it.

### Simple usage

To generate a `card token` read the [Checkout API](https://www.mercadopago.com/developers/en/guides/online-payments/checkout-api/introduction) documentation.

```csharp
using System;
using MercadoPago.Config;
using MercadoPago.Client.Common;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;
using System.Collections.Generic;

MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

var request = new OrderCreateRequest
{
    Type = "online",
    TotalAmount = "1000.00",
    ExternalReference = "ext_ref_1234",
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
                        Token = "{{CARD_TOKEN}}",
                        Installments = 1,
                    }
                }
            }
    },
    Payer = new OrderPayerRequest
    {
        Email = "{{PAYER_EMAIL}}",
    }
};

var client = new OrderClient();
Order order = client.Create(request);
Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(order, Newtonsoft.Json.Formatting.Indented));
```

### Per-request configuration

All methods that make API calls accept an optional `RequestOptions` object. This can be used to configure some special options of the request, such as changing credentials or custom headers.

```csharp
using MercadoPago.Client;
using MercadoPago.Http;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;

var requestOptions = new RequestOptions();
requestOptions.AccessToken = "YOUR_ACCESS_TOKEN";
requestOptions.CustomHeaders.Add(Headers.IDEMPOTENCY_KEY, "YOUR_IDEMPOTENCY_KEY");

// ...
var client = new OrderClient();
Order order = client.Create(request, requestOptions);
```

### Using a proxy server

```csharp
using System.Net;
using System.Net.Http;
using MercadoPago.Config;
using MercadoPago.Http;

var handler = new HttpClientHandler
{
    Proxy = new WebProxy(proxyUrl),
    UseProxy = true,
};
var httpClient = new HttpClient(handler);
MercadoPagoConfig.HttpClient = new DefaultHttpClient(httpClient);

```

### Configuring automatic retries

The SDK automatically retries requests on intermittent failures. The default max number of attempts is **2**.

```csharp
using MercadoPago.Config;
using MercadoPago.Http;

var retryStrategy = new DefaultRetryStrategy(5);
MercadoPagoConfig.RetryStrategy = retryStrategy;

```

## 📚 Documentation

- [SDK guides](docs/README.md): errors, webhooks, retries, and production guidance.
- [Examples](examples/README.md): integration flows supported by this SDK.
- [API reference](https://www.mercadopago.com/developers/en/reference): request fields and response schemas.
- [Generated SDK reference](https://mercadopago.github.io/sdk-dotnet/): public classes and methods.

## 🤝 Contributing

All contributions are welcome, ranging from people wanting to triage issues, others wanting to write documentation, to people wanting to contribute code.

Please read and follow our [contribution guidelines](CONTRIBUTING.md). Contributions not following this guidelines will be disregarded. The guidelines are in place to make all of our lives easier and make contribution a consistent process for everyone.

## ❤️ Support

If you require technical support, please contact our support team at [developers.mercadopago.com](https://developers.mercadopago.com).

## 🏻 License

```
MIT license. Copyright (c) 2021 - Mercado Pago / Mercado Libre
For more information, see the LICENSE file.
```
