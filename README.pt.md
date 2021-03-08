# Mercado Pago .Net

[Inglês](https://github.com/mercadopago/sdk-dotnet/blob/master/README.md) / [Espanhol](https://github.com/mercadopago/sdk-dotnet/blob/master/README.es.md)

![CI](https://github.com/mercadopago/sdk-dotnet/workflows/CI/badge.svg)
[![NuGet](http://img.shields.io/nuget/v/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk)
[![Download count](https://img.shields.io/nuget/dt/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk/)
[![APM](https://img.shields.io/apm/l/vim-mode)](https://github.com/mercadopago/sdk-dotnet)

O SDK oficial do Mercado Pago.

## 💡 Requisitos

**.NET Standard 2.0+**, **.NET Core 2.0+**, e **.NET Framework 4.6.1+**.

Se você estiver usando versões anteriores do .NET Framework em seu projeto, consulte as [versões mais antigas](https://github.com/mercadopago/sdk-dotnet/tree/master-dotnet-framework) do SDK.

## 📲 Instalação 

### Usando o [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/pt-br/dotnet/core/tools/)

```bash
dotnet add package mercadopago-sdk
```

### Usando o [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/pt-br/nuget/tools/nuget-exe-cli-reference)

```bash
nuget install mercadopago-sdk
```

### Usando o [Package Manager](https://docs.microsoft.com/pt-br/nuget/tools/package-manager-console)

```bash
Install-Package mercadopago-sdk
```

### No Visual Studio

1. Abra o `Solution Explorer`.
2. Clique com o botão direito em um projeto da sua solução.
3. Clique em `Manage NuGet Packages...`.
4. Clique na tab `Browse` e busque por "mercadopago-sdk".
5. Clique no package `mercadopago-sdk`, selecione a versãa apropriada e clique em `Install`.

## 🌟 Iniciando

Primeira vez usando o Mercado Pago? Crie sua [conta do Mercado Pago](https://www.mercadopago.com).

Copie seu `Access Token` do [painel de credenciais](https://www.mercadopago.com/developers/panel/credentials) e substitua YOUR_ACCESS_TOKEN com ele.

### Uso simples

Para gerar um `card token` leia a documentação do [Checkout Transparente](https://www.mercadopago.com/developers/pt/guides/online-payments/checkout-api/introduction).

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

### Configuração por requisição

Todos os métodos dos clients aceitam um objeto opcional `RequestOptions`. Isto é usado para configurar algumas opções por requisição, como o Access Token ou headers customizados.

```csharp
using MercadoPago.Client;

var requestOptions = new RequestOptions();
requestOptions.AccessToken = "YOUR_ACCESS_TOKEN";
// ...

var client = new PaymentClient();
Payment payment = await client.CreateAsync(request, requestOptions);

```

## Uso avançado

### Usar um servidor de proxy

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

### Configurar retentativas automáticas

O SDK automaticamente retenta as requisições no caso de falhas intermitentes. O número máximo de tentativas default é **2**.

```csharp
using MercadoPago.Config;
using MercadoPago.Http;

var retryStrategy = new DefaultRetryStrategy(5);
MercadoPagoConfig.RetryStrategy = retryStrategy;

```

## 📚 Documentação

Visite nosso Developer Site para mais informações sobre:
 - [APIs](https://www.mercadopago.com/developers/pt/reference)
 - [Checkout Pro](https://www.mercadopago.com/developers/pt/guides/online-payments/checkout-pro/introduction)
 - [Checkout Transparente](https://www.mercadopago.com/developers/pt/guides/online-payments/checkout-api/introduction)
 - [Web Tokenize Checkout](https://www.mercadopago.com/developers/pt/guides/online-payments/web-tokenize-checkout/introduction)

Veja nosso [SDK docs](https://mercadopago.github.io/sdk-dotnet/) para explorar todas as funcionalidades disponíveis.

## ❤️ Soporte 

Se você necessita de suporte técnico, por favor entre em contato com nosso time de suporte em [developers.mercadopago.com](https://developers.mercadopago.com)

Para qualquer requisição, bug ou comentário [abra uma issue](https://github.com/mercadopago/sdk-dotnet/issues/new) ou [envie um pull request](https://github.com/mercadopago/sdk-dotnet/pulls).

## 🏻 Licença

```
MIT license. Copyright (c) 2021 - Mercado Pago / Mercado Libre 
Para mais informação, veja o arquivo LICENSE.
```
