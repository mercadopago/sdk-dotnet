# Mercado Pago .NET SDK documentation

Use the root README to install the SDK and send a first request. This index connects the runnable examples with the operational decisions needed for production.

## Start with Orders

Orders is the recommended learning path because one API demonstrates the complete payment lifecycle. Begin with [Create](../examples/Order/Create.cs), inspect the result with [Get](../examples/Order/Get.cs), and then follow the lifecycle through [Process](../examples/Order/Process.cs), [Capture](../examples/Order/Capture.cs), [Cancel](../examples/Order/Cancel.cs), or a [refund](../examples/Order/TotalRefund.cs).

Before retrying writes, read [retries and idempotency](retries-and-idempotency.md). When adding failure handling, use [error handling](error-handling.md). See the [Orders-first example catalog](../examples/README.md#orders-first) for transactions, partial refunds, PSE, 3DS, and automatic payments supported by this SDK.

## Operational guides

| Question | Guide |
|---|---|
| How should failed API calls be classified? | [Error handling](error-handling.md) |
| When is a retry safe? | [Retries and idempotency](retries-and-idempotency.md) |
| How should signed notifications be processed? | [Webhook validation](webhooks.md) |
| What should be checked first during an incident? | [Troubleshooting](troubleshooting.md) |

Endpoint fields and response schemas belong to the [Mercado Pago API reference](https://www.mercadopago.com/developers/en/reference).
