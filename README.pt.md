# Mercado Pago .Net

[Inglês](README.md) / [Espanhol](README.es.md)

![CI](https://github.com/mercadopago/sdk-dotnet/workflows/CI/badge.svg)
[![NuGet](http://img.shields.io/nuget/v/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk)
[![Download count](https://img.shields.io/nuget/dt/mercadopago-sdk.svg)](https://www.nuget.org/packages/mercadopago-sdk/)
[![APM](https://img.shields.io/apm/l/vim-mode)](https://github.com/mercadopago/sdk-dotnet)

O SDK oficial do Mercado Pago.

## 💡 Requisitos

**.NET Standard 2.1+**, **.NET Core 2.0+**, e **.NET Framework 6.0+**.

Se você estiver usando versões anteriores do .NET Framework em seu projeto, consulte as [versões mais antigas](https://github.com/mercadopago/sdk-dotnet/tree/master-dotnet-framework) do SDK.

## 📲 Instalação

Use uma das seguintes opções, dependendo do ambiente preferido.

### No Visual Studio

1. Abra o `Solution Explorer`.
2. Clique com o botão direito em um projeto da sua solução.
3. Clique em `Manage NuGet Packages...`.
4. Clique na tab `Browse` e busque por "mercadopago-sdk".
5. Clique no package `mercadopago-sdk`, selecione a versãa apropriada e clique em `Install`.

### Usando o [Package Manager](https://docs.microsoft.com/pt-br/nuget/tools/package-manager-console)

```bash
Install-Package mercadopago-sdk
```

### Usando o [.NET Core command-line interface (CLI) tools](https://docs.microsoft.com/pt-br/dotnet/core/tools/)

```bash
dotnet add package mercadopago-sdk
```

### Usando o [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/pt-br/nuget/tools/nuget-exe-cli-reference)

```bash
nuget install mercadopago-sdk
```

## 🌟 Iniciando

Primeira vez usando o Mercado Pago? Crie sua [conta do Mercado Pago](https://www.mercadopago.com).

Copie seu `Access Token` do [painel de credenciais](https://www.mercadopago.com/developers/panel/credentials) e substitua o texto `YOUR_ACCESS_TOKEN` com ele.

### Uso simples

Para gerar um `card token` leia a documentação do [Checkout Transparente](https://www.mercadopago.com/developers/pt/guides/online-payments/checkout-api/introduction).

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

### Configuração por requisição

Todos os métodos que realizam chamadas às APIs aceitam um objeto opcional `RequestOptions`. Isto pode ser utilizado para configurar algumas opções especiais da requisição, como a alteração das próprias credenciais ou headers personalizados.

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

## 🤝 Contribuindo

Todas as contribuições são bem-vindas, desde pessoas que desejam fazer a triagem de issues, outras que desejam escrever documentação, até pessoas que desejam contribuir com código.

Por favor, leia e siga nossas [diretrizes de contribuição](CONTRIBUTING.md). As contribuições que não seguirem essas diretrizes serão desconsideradas. As diretrizes existem para facilitar todas as nossas vidas e tornar a contribuição um processo consistente para todos.

## ❤️ Suporte

Se você necessita de suporte técnico, por favor entre em contato com nosso time de suporte em [developers.mercadopago.com](https://developers.mercadopago.com)

## 🏻 Licença

```
MIT license. Copyright (c) 2021 - Mercado Pago / Mercado Libre
Para mais informação, veja o arquivo LICENSE.
```
