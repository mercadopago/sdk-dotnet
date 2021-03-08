# Mercado Pago .Net

[Inglês](https://github.com/mercadopago/sdk-dotnet/blob/master/README.md) / [Portugues](https://github.com/mercadopago/sdk-dotnet/blob/master/README.pt.md)

![CI](https://github.com/mercadopago/sdk-dotnet/workflows/CI/badge.svg)
[![NuGet](http://img.shields.io/nuget/v/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk)
[![Download count](https://img.shields.io/nuget/dt/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk/)
[![APM](https://img.shields.io/apm/l/vim-mode)](https://github.com/mercadopago/sdk-dotnet)

El SDK oficial de Mercado Pago.

## 💡 Requisitos

**.NET Standard 2.0+**, **.NET Core 2.0+**, y **.NET Framework 4.6.1+**.

## 📲 Instalación

### Usando el [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/es-es/dotnet/core/tools/)

```bash
dotnet add package mercadopago-sdk
```

### Usando el [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/es-es/nuget/tools/nuget-exe-cli-reference)

```bash
nuget install mercadopago-sdk
```

### Usando el [Package Manager](https://docs.microsoft.com/es-es/nuget/tools/package-manager-console)

```bash
Install-Package mercadopago-sdk
```

### En el Visual Studio

1. Abra el `Solution Explorer`.
2. Haga clic con el botón derecho en un proyecto de su solución.
3. Haga clic en `Manage NuGet Packages...`.
4. Haga clic en la tab `Browse` y busque "mercadopago-sdk".
5. Haga clic en el package `mercadopago-sdk`, seleccione la versión apropiada y haga clic en `Install`.

## 🌟 Empezando

¿Primera vez usando Mercado Pago? Crea tu [cuenta de Mercado Pago](https://www.mercadopago.com).

Copie tu `Access Token` del [painel de credenciales](https://www.mercadopago.com/developers/panel/credentials) y reemplace YOUR_ACCESS_TOKEN con él.

### Uso simple

Para generar un `card token` lea la documentación del [Checkout Transparente](https://www.mercadopago.com/developers/es/guides/online-payments/checkout-api/introduction).

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

### Configuración por solicitud

Todos los métodos de los clients aceptan un objeto `RequestOptions` opcional.
Todos os métodos dos clients aceitam um objeto opcional `RequestOptions`. Esto se usa para configurar algunas opciones por solicitud, como el Access Token o headers personalizados.

```csharp
using MercadoPago.Client;

var requestOptions = new RequestOptions();
requestOptions.AccessToken = "YOUR_ACCESS_TOKEN";
// ...

var client = new PaymentClient();
Payment payment = await client.CreateAsync(request, requestOptions);

```

## Uso avanzado

### Usar un servidor proxy

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

### Configurar reintentos automáticos

El SDK reintenta automáticamente las solicitudes en caso de fallas intermitentes. El número máximo de intentos default es **2**.

```csharp
using MercadoPago.Config;
using MercadoPago.Http;

var retryStrategy = new DefaultRetryStrategy(5);
MercadoPagoConfig.RetryStrategy = retryStrategy;

```

## 📚 Documentación

Visite nuestro Developer Site para obtener más información sobre:
 - [APIs](https://www.mercadopago.com/developers/es/reference)
 - [Checkout Pro](https://www.mercadopago.com/developers/es/guides/online-payments/checkout-pro/introduction)
 - [Checkout Transparente](https://www.mercadopago.com/developers/es/guides/online-payments/checkout-api/introduction)
 - [Web Tokenize Checkout](https://www.mercadopago.com/developers/es/guides/online-payments/web-tokenize-checkout/introduction)

Consulte nuestro [SDK docs](https://mercadopago.github.io/sdk-dotnet/) para explorar todas las funciones disponibles.

## ❤️ Support 

Si necesitas asistencia técnica, póngase en contacto con nuestro equipo de asistencia en [developers.mercadopago.com](https://developers.mercadopago.com).

Para cualquier solicitud, error o comentario [abres una issue](https://github.com/mercadopago/sdk-dotnet/issues/new) o [envías un pull request](https://github.com/mercadopago/sdk-dotnet/pulls).

## 🏻 Licencia 

```
MIT license. Copyright (c) 2021 - Mercado Pago / Mercado Libre 
Para obtener más información, consulte el archivo LICENSE.
```
