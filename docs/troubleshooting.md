# Troubleshooting

## A write timed out and its result is unknown

Do not immediately create another order or payment. Reuse the original idempotency key and first reconcile using the returned ID, your `external_reference`, or the relevant search operation.

## A `POST` is not retried

`DefaultRetryStrategy` requires a non-empty `X-Idempotency-Key` for `POST`. Confirm the header was added through `RequestOptions.CustomHeaders` and that the request uses those options.

## `401` or `403`

Confirm `MercadoPagoConfig.AccessToken` belongs to the intended account and environment. A public key is not an access token. If using `RequestOptions.AccessToken`, remember that it overrides the global token for that call.

## `409` after retrying

Treat it as a reconciliation signal. Check whether the original operation completed under the same idempotency key instead of generating a new key.

## Webhook validation fails

Pass `x-signature`, `x-request-id`, and `data.id` exactly as received. Confirm the application secret, system clock, and tolerance. Do not validate unsigned QR Code notifications with `WebhookSignatureValidator`.

## Useful diagnostic fields

Capture the SDK version, operation name, HTTP status, resource or external reference, idempotency key, and response correlation headers. Never capture access tokens, card tokens, complete payloads, or webhook secrets.
