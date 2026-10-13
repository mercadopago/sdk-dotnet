# Handle API errors

API failures throw `MercadoPagoApiException`; transport and SDK failures throw `MercadoPagoException`. Keep those paths separate: an API exception confirms that Mercado Pago returned a response, while a transport failure may leave the operation outcome unknown.

```csharp
using MercadoPago.Error;

try
{
    var order = await client.CreateAsync(request, requestOptions);
}
catch (MercadoPagoApiException error)
{
    Console.Error.WriteLine($"Status: {error.StatusCode}");
    Console.Error.WriteLine(error.ApiError?.Message ?? error.Message);
}
catch (MercadoPagoException error)
{
    Console.Error.WriteLine("The SDK could not complete the request");
}
```

## Recovery decisions

| Status or failure | Meaning | Application action |
|---|---|---|
| `400`, `422` | Invalid syntax or business data | Correct the payload; do not retry unchanged. |
| `401`, `403` | Credential or permission problem | Stop and fix access; never retry in a tight loop. |
| `404` | Resource not found or not visible | Confirm the ID and account ownership. |
| `409` | Idempotency or state conflict | Reconcile the original operation before creating another one. |
| `423`, `429`, `5xx` | Temporary condition | Retry only with a bounded policy and the same idempotency key. |
| Transport exception | No usable response | Treat a write as indeterminate and reconcile it before retrying. |

`ApiResponse` contains the raw status, headers, and body. `ApiError` contains the parsed API message and error details. Use structured logs with operation name, status, resource ID, and correlation headers, but redact authorization, card data, payer data, and request bodies.

For writes, log your own idempotency key so an indeterminate request can be correlated safely. See [retries and idempotency](retries-and-idempotency.md).
