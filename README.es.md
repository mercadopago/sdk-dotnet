# Mercado Pago .Net

[Inglês](README.md) / [Portugues](README.pt.md)

![CI](https://github.com/mercadopago/sdk-dotnet/workflows/CI/badge.svg)
[![NuGet](http://img.shields.io/nuget/v/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk)
[![Download count](https://img.shields.io/nuget/dt/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk/)
[![APM](https://img.shields.io/apm/l/vim-mode)](https://github.com/mercadopago/sdk-dotnet)

El SDK oficial de Mercado Pago.

## 💡 Requisitos

**.NET Standard 2.1+**, **.NET Core 2.0+**, y **.NET Framework 6.0+**.

Si estás utilizando versiones anteriores del .NET Framework en tu proyecto, consulta las [versiones anteriores](https://github.com/mercadopago/sdk-dotnet/tree/master-dotnet-framework) del SDK.

## 📲 Instalación

Usar una de las siguientes opciones, dependiendo de tu entorno preferido.

### En el Visual Studio

1. Abra el `Solution Explorer`.
2. Haga clic con el botón derecho en un proyecto de su solución.
3. Haga clic en `Manage NuGet Packages...`.
4. Haga clic en la tab `Browse` y busque "mercadopago-sdk".
5. Haga clic en el package `mercadopago-sdk`, seleccione la versión apropiada y haga clic en `Install`.

### Usando el [Package Manager](https://docs.microsoft.com/es-es/nuget/tools/package-manager-console)

```bash
Install-Package mercadopago-sdk
```

### Usando el [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/es-es/dotnet/core/tools/)

```bash
dotnet add package mercadopago-sdk
```

### Usando el [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/es-es/nuget/tools/nuget-exe-cli-reference)

```bash
nuget install mercadopago-sdk
```

## 🌟 Empezando

¿Primera vez usando Mercado Pago? Crea tu [cuenta de Mercado Pago](https://www.mercadopago.com).

Copie su `Access Token` del [panel de credenciales](https://www.mercadopago.com/developers/panel/credentials) y reemplace el texto `YOUR_ACCESS_TOKEN` con él.

### Uso simple

Para generar un `card token` lea la documentación del [Checkout Transparente](https://www.mercadopago.com/developers/es/guides/online-payments/checkout-api/introduction).

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

### Configuración por solicitud

Todos los métodos de los que realizan llamadas a APIs aceptan un objeto `RequestOptions` opcional. Esto puede ser utilizado para configurar algunas opciones especiales de la solicitud, como el propio cambio de credenciales o headers presonalizados.

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

## 🤝 Contribuyendo

Todas las contribuciones son bienvenidas, desde personas que deseen filtrar las issues, otras que quieran escribir documentación, hasta personas que quieran contribuir con código.

Lea y siga nuestras [pautas de contribución](CONTRIBUTING.md). Las contribuciones que no sigan estas pautas no se tendrán en cuenta. Las pautas están establecidas para hacernos la vida más fácil y hacer que la contribución sea un proceso consistente para todos.

## ❤️ Soporte

Si necesitas asistencia técnica, póngase en contacto con nuestro equipo de asistencia en [developers.mercadopago.com](https://developers.mercadopago.com).

## 🏻 Licencia

```
MIT license. Copyright (c) 2021 - Mercado Pago / Mercado Libre
Para obtener más información, consulte el archivo LICENSE.
```
