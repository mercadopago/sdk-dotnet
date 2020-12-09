# Mercado Pago SDK for .Net

![CI](https://github.com/mercadopago/dx-dotnet/workflows/CI/badge.svg)
[![NuGet](http://img.shields.io/nuget/v/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk)
[![Download count](https://img.shields.io/nuget/dt/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk/)
[![APM](https://img.shields.io/apm/l/vim-mode)](https://github.com/mercadopago/dx-dotnet)

This library provides developers with a simple set of bindings to help you integrate Mercado Pago API to a website and start receiving payments.

## 💡 Requirements

4.6.1 .Net Framework or higher (including .Net Core).

## 📲 Installation 

### Using our nuget package

First time using Mercado Pago? Create your [Mercado Pago account](https://www.mercadopago.com), if you don’t have one already.

**Using Package Manager**

`PM> Install-Package mercadopago-sdk -Version 2.0.0`

**Using .Net CLI**

`> dotnet add package mercadopago-sdk --version 2.0.0`

**Using Packet CLI**

`> paket add mercadopago-sdk --version 2.0.0`

Copy the access_token in the [credentials](https://www.mercadopago.com/developers/panel/credentials) section of the page and replace YOUR_ACCESS_TOKEN with it.

That's it! Mercado Pago SDK has been successfully installed.

## 🌟 Getting Started

  Simple usage looks like:
    
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

## 📚 Documentation 

Visit our Dev Site for further information regarding:
 - Payments APIs: [Spanish](https://www.mercadopago.com.ar/developers/es/guides/payments/api/introduction/) / [Portuguese](https://www.mercadopago.com.br/developers/pt/guides/payments/api/introduction/)
 - Mercado Pago checkout: [Spanish](https://www.mercadopago.com.ar/developers/es/guides/payments/web-payment-checkout/introduction/) / [Portuguese](https://www.mercadopago.com.br/developers/pt/guides/payments/web-payment-checkout/introduction/)
 - Web Tokenize checkout: [Spanish](https://www.mercadopago.com.ar/developers/es/guides/payments/web-tokenize-checkout/introduction/) / [Portuguese](https://www.mercadopago.com.br/developers/pt/guides/payments/web-tokenize-checkout/introduction/)

Check [our official code reference](https://mercadopago.github.io/dx-dotnet/) to explore all available functionalities.

## ❤️ Support 

If you require technical support, please contact our support team at [developers.mercadopago.com](https://developers.mercadopago.com)

## 🏻 License 

```
MIT license. Copyright (c) 2018 - Mercado Pago / Mercado Libre 
For more information, see the LICENSE file.
```
