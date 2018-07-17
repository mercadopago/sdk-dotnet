
# Mercado Pago SDK for .Net


[![Build Status](https://travis-ci.org/mercadopago/px-dotnet.svg?branch=develop)](https://travis-ci.org/mercadopago/px-dotnet)


This library provides developers with a simple set of bindings to the Mercado Pago API.

### .Net versions supported:
.Net Framework 3.5 and above

## Installation 

### Using our nuget package

**Using Package Manager**

`PM> Install-Package mercadopago-sdk -Version 1.0.29`

**Using .Net CLI**

`> dotnet add package mercadopago-sdk --version 1.0.29`

**Using Paket CLI**

`> paket add mercadopago-sdk --version 1.0.29`

## Quick Start

### 1. You have to import the Mercado Pago SDK.
```csharp
using MercadoPago;
```
### 2. Setup your credentials

**For Web-checkout:**
```csharp
MercadoPago.SDK.ClientId = "YOUR_CLIENT_ID";
MercadoPago.SDK.ClientSecret = "YOUR_CLIENT_SECRET";
```
**For API or custom checkout:**
```csharp
MercadoPago.SDK.AccessToken = "YOUR_ACCESS_TOKEN";
```
### 3. Using resource objects

You can interact with all the resources available in the public API, to this each resource is represented by classes according to the following diagram:

![sdk resource structure](https://user-images.githubusercontent.com/864790/34393059-9acad058-eb2e-11e7-9987-494eaf19d109.png)

**Sample (Creating a Payment)**
    
```csharp
using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Common;

MercadoPago.SDK.AccessToken = "YOUR_ACCESS_TOKEN";

Payment payment = new Payment
{
    TransactionAmount = 100.0m,
    Token = "YOUR_CARD_TOKEN"
    Description = "Ergonomic Silk Shirt",
    PaymentMethodId = "visa", 
    Installments = 1,
    Payer = new Payer {
        Email = "larue.nienow@hotmail.com"
    }
};

payment.Save();

Console.WriteLine(payment.Status);
```

> You can find more examples in the `MercadoPagoExample` folder.

### 4. Handling Errors

**Error response structure**

![errorstructure](https://user-images.githubusercontent.com/864790/40929584-9cc4c96e-67fb-11e8-80a4-8d797953233a.png)

You can check the errors and causes returned by the API using the `errors` attribute.

```csharp
Console.WriteLine(payment.Errors.Message) // Print the error Message 
```

### Support 

Write us at [developers.mercadopago.com](https://developers.mercadopago.com)
