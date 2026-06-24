# Releases

## VERSION 3.3.0-beta.1 - 2026-06-24
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
