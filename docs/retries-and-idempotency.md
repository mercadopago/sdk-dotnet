# Retries and idempotency

`DefaultRetryStrategy` uses exponential backoff from 500 ms up to 5 seconds. It retries transport failures, `409`, `429`, and `5xx` responses while attempts remain. A `POST` is eligible only when it carries a non-empty idempotency key; other HTTP methods follow the configured retry strategy.

```csharp
using MercadoPago.Client;

var requestOptions = new RequestOptions();
requestOptions.CustomHeaders.Add("X-Idempotency-Key", "order-2026-0001");
```

## Key lifecycle

Generate the key at the business-operation boundary, not inside the retry loop. Persist it with the checkout, order, or job if retries can cross processes.

| Situation | Key to send |
|---|---|
| Retrying the same logical write | Reuse the original key. |
| Worker resumes the same queued operation | Reuse the persisted key. |
| Buyer starts a new purchase | Generate a new key. |
| Payload changed materially | Treat it as a new operation and use a new key. |

The SDK retry loop is not a replacement for business reconciliation. If the connection fails after sending a write, query the resource by its ID or `external_reference` before issuing another write.

## Configuration scope

Set `MercadoPagoConfig.RetryStrategy` only when one policy fits the whole process. Use `RequestOptions.RetryStrategy` for an operation-specific policy. Keep retry counts low enough to remain within the caller's overall deadline.

Do not retry `400`, `401`, `403`, `404`, or `422` without changing the request or credentials. When `429` is returned, respect the API response and avoid concurrent retry storms.
