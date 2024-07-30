# Mercado Pago .Net

[Portuguese](README.pt.md) / [Spanish](README.es.md)

![CI](https://github.com/mercadopago/sdk-dotnet/workflows/CI/badge.svg)
[![NuGet](http://img.shields.io/nuget/v/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk)
[![Download count](https://img.shields.io/nuget/dt/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk/)
[![APM](https://img.shields.io/apm/l/vim-mode)](https://github.com/mercadopago/sdk-dotnet)

The official Mercado Pago .NET SDK.

## 💡 Requirements

**.NET Standard 2.1+**, **.NET Core 2.0+**, and **.NET Framework 6.0+**.

If you are using previous versions of .NET Framework in your project, please refer to the [older versions](https://github.com/mercadopago/sdk-dotnet/tree/master-dotnet-framework) of the SDK.

## 📲 Installation

### Using the [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/en-us/dotnet/core/tools/)

```bash
dotnet add package mercadopago-sdk
```

### Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference)

```bash
nuget install mercadopago-sdk
```

### Using the [Package Manager](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console)

```bash
Install-Package mercadopago-sdk
```

### From Visual Studio

1. Open the `Solution Explorer`.
2. Right-click on a project within your solution.
3. Click on `Manage NuGet Packages...`.
4. Click on the `Browse` tab and search for "mercadopago-sdk".
5. Click on the `mercadopago-sdk` package, select the appropriate version and click Install.

## 🌟 Getting Started

First time using Mercado Pago? Create your [Mercado Pago account](https://www.mercadopago.com).

Copy your `Access Token` in the [credentials panel](https://www.mercadopago.com/developers/panel/credentials) and replace the text `YOUR_ACCESS_TOKEN` with it.

### Simple usage

To generate a `card token` read the [Checkout API](https://www.mercadopago.com/developers/en/guides/online-payments/checkout-api/introduction) documentation.

```csharp
using System;
using System.Threading.Tasks;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;

MercadoPagoConfig.AccessToken = "YOUR_ACCESS_TOKEN";

var request = new PaymentCreateRequest
{
    TransactionAmount = 10,
    Token = "CARD_TOKEN",
    Description = "Payment description",
    Installments = 1,
    PaymentMethodId = "visa",
    Payer = new PaymentPayerRequest
    {
        Email = "test.payer@email.com",
    }
};

var client = new PaymentClient();
Payment payment = await client.CreateAsync(request);

Console.WriteLine($"Payment ID: {payment.Id}");
```

### Per-request configuration

All methods that make API calls accept an optional `RequestOptions` object. This can be used to configure some special options of the request, such as changing credentials or custom headers.

```csharp
using MercadoPago.Client;

var requestOptions = new RequestOptions();
requestOptions.AccessToken = "YOUR_ACCESS_TOKEN";
// ...

var client = new PaymentClient();
Payment payment = await client.CreateAsync(request, requestOptions);

```

## Advanced usage

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

Visit our Developer Site for further information regarding:
 - [APIs](https://www.mercadopago.com/developers/en/reference)
 - [Checkout Pro](https://www.mercadopago.com/developers/en/guides/online-payments/checkout-pro/introduction)
 - [Checkout API](https://www.mercadopago.com/developers/en/guides/online-payments/checkout-api/introduction)
 - [Web Tokenize Checkout](https://www.mercadopago.com/developers/en/guides/online-payments/web-tokenize-checkout/introduction)

Check our [SDK docs](https://mercadopago.github.io/sdk-dotnet/) to explore all available functionalities.

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
