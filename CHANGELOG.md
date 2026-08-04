# Releases

## VERSION 3.4.0 - 2026-08-04
- feat: SDK ergonomics — typed exceptions, configurable retry and auto-pagination ([#265](https://github.com/mercadopago/sdk-dotnet/pull/265)). `MercadoPagoApiException` now has 12 specific subtypes per HTTP status code. Request options gain optional `MaxRetries`, `RetryOn`, `InitialDelayMs`, `MaxDelayMs` and `OnRetry` callback. New auto-pagination support on search endpoints.
- feat: add missing API methods — `DisbursementRefundClient.List()`, `AdvancedPaymentClient.Update()`, `CustomerCardClient.Update()`, `PaymentClient.Update()` ([#264](https://github.com/mercadopago/sdk-dotnet/pull/264))
- feat: add CREDENTIAL_ON_FILE messaging fields to Payment types ([#261](https://github.com/mercadopago/sdk-dotnet/pull/261)): `FirstTransaction`, `Storage`, `TransactionInitiator`, `Reference`
- fix: webhook `ToleranceSeconds` unit mismatch — `ts` header value compared in seconds against a millisecond clock ([#266](https://github.com/mercadopago/sdk-dotnet/pull/266))
- fix: `ConstantTimeEquals` error on multibyte v1 hash ([#266](https://github.com/mercadopago/sdk-dotnet/pull/266))
- fix(order): make `OrderPaymentMethod.Installments` nullable to prevent serialization errors for non-card payments (Pix, bank_transfer) ([#259](https://github.com/mercadopago/sdk-dotnet/pull/259))
- Bump `actions/checkout` to `v7.0.1` ([#263](https://github.com/mercadopago/sdk-dotnet/pull/263))
- Bump `actions/setup-dotnet` to `v6.0.0` ([#260](https://github.com/mercadopago/sdk-dotnet/pull/260))

## VERSION 3.3.0 - 2026-06-30
- PreApprovalPlan: subscription plan template management — Create, Get, Update, Search (`POST/GET/PUT /preapproval_plan`).
- Point: in-person payment intent management for Point devices — Create, Get, Cancel (`POST/GET/DELETE /point/integration-api/...`).
- Chargeback: read-only access to payment dispute records — Get, Search (`GET /v1/chargebacks`).
- DisbursementRefund: refund management for advanced (split) payments — ListAll, CreateAll, Create (`GET/POST /v1/advanced_payments/{id}/refunds`).

## VERSION 2.9.0
- Order: set default `capture_mode = "automatic_async"` and update fields/tests.
- Examples: fix `examples/Order/Create.cs` example.
- Examples: improve `examples/Order/Get.cs` (env vars, boleto, additional_info).
- Chore: remove `.idea` project files.
- Refactor: standardize messages to English and align .NET target version.
- Fix: null-safety when building error message in `MercadoPagoApiException`.

## VERSION 2.4.0
- Require .NET Framework 6.0 as minimum version.
- Avoid rethrowing exception that changes stack trace information.
- Add pre-commit.
- Add CHANGELOG file.
