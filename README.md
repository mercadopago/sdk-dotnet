# Mercado Pago SDK for .Net

[![NuGet](http://img.shields.io/nuget/v/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk)
[![APM](https://img.shields.io/apm/l/vim-mode)](https://github.com/mercadopago/dx-dotnet)

This library provides developers with a simple set of bindings to help you integrate Mercado Pago API to a website and start receiving payments.

## 💡 Requirements

4.5 .Net Framework or Major

## 📲 Installation 

### Using our nuget package

First time using Mercado Pago? Create your [Mercado Pago account](https://www.mercadopago.com), if you don’t have one already.

**Using Package Manager**

`PM> Install-Package mercadopago-sdk -Version 1.7.0`

**Using .Net CLI**

`> dotnet add package mercadopago-sdk --version 1.7.0`

**Using Packet CLI**

`> paket add mercadopago-sdk --version 1.7.0`

Copy the access_token in the [credentials](https://www.mercadopago.com/mlb/account/credentials) section of the page and replace YOUR_ACCESS_TOKEN with it.

Thats all, you have Mercado Pago SDK installed.

## 🌟 Getting Started

  Simple usage looks like:
    
```csharp
using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Common;

MercadoPago.SDK.AccessToken = "YOUR_ACCESS_TOKEN";

Payment payment = new Payment
{
    TransactionAmount = 100,
    Token = "YOUR_CARD_TOKEN"
    Description = "Ergonomic Silk Shirt",
    PaymentMethodId = "visa", 
    Installments = 1,
    Payer = new Payer {
        Email = "test.payer@email.com"
    }
};

payment.Save();

Console.Out.WriteLine(payment.Status);
```

## 📚 Documentation 

See our Documentation with all APIs you can integrate in our DevSite: [Spanish](https://www.mercadopago.com.ar/developers/es/guides/payments/api/introduction/) / [Portuguese](https://www.mercadopago.com.br/developers/pt/guides/payments/api/introduction/)

Check [our official code reference](https://mercadopago.github.io/dx-dotnet/) to explore all available functionalities.

## ❤️ Support 

If you require technical support, please contact our support team at [developers.mercadopago.com](https://developers.mercadopago.com)

## 🏻 License 

```
MIT license. Copyright (c) 2018 - Mercado Pago / Mercado Libre 
For more information, see the LICENSE file.
```
