# Validate webhook signatures

Signature validation proves that a signed notification matches its headers and configured secret. It does not prove that the event has not already been processed or that the referenced resource is in its final state.

Validate before parsing the event into business commands:

```csharp
using MercadoPago.Webhook;

WebhookSignatureValidator.Validate(
    xSignature,
    xRequestId,
    dataId,
    webhookSecret,
    tolerance: TimeSpan.FromMinutes(5));
```

`Validate` throws `InvalidWebhookSignatureException` when verification fails. Pass `x-signature`, `x-request-id`, and `data.id` exactly as received. QR Code notifications are not signed and must not be sent through this validator.

## Processing sequence

1. Read the raw header and query values without changing case or formatting.
2. Call `Validate` with a short timestamp tolerance such as five minutes.
3. On failure, return an unauthorized response and stop processing.
4. Enqueue or persist the notification, then return success promptly.
5. Fetch the referenced resource server-side before applying a business transition.
6. Deduplicate deliveries using the event/resource identity in your application.

`InvalidWebhookSignatureException` exposes `Reason`, `RequestId`, and `Timestamp`. Log those fields as structured metadata, but never log the webhook secret or full signature. `TimestampOutOfTolerance` can indicate replay, clock drift, or delayed delivery; check the server clock before widening the window.

Signature verification and idempotent event processing solve different problems: always implement both. QR Code notifications require the product-specific verification flow because they are not signed by this mechanism.
