# COF serialization comparison

`verify_cof_serialization.py` demonstrates the nullable boolean regression fix
without credentials or API calls. It compares a Git baseline (default: `master`)
against the same source with the working tree's `PaymentTransactionDataRequest`
model. Both snapshots run the same five regression cases from the working tree.
Uncommitted model and test changes are included.

## Requirements

- Python 3 and Git.
- .NET 10 SDK; the test project targets .NET 8 and .NET 10.
- .NET 8 and .NET 10 runtimes for the default comparison.
- NuGet access for the first dependency restore, or an existing package cache.

## Run

From the repository root:

```bash
python3 scripts/verify_cof_serialization.py --output artifacts/cof-comparison-master
python3 scripts/verify_cof_serialization.py --baseline-ref 3.7.0 --output artifacts/cof-comparison-3.7.0
```

Use `--dotnet /path/to/dotnet` for an SDK outside PATH, or
`--frameworks net10.0` to run only one framework. The output directory must be
new or empty. Without `--output`, reports are retained in a new temporary
directory whose path is printed.

The script succeeds only if all five baseline cases fail on the expected
`Assert.False` omission assertions and all five fixed cases pass. A build,
restore, or unrelated assertion failure is not accepted as reproduction.

Cases cover COF initial and subsequent payments, legacy `FirstTimeUse` set to
either `true` or `false`, and unset booleans. Explicit false values must remain
in the payload, while unset values must disappear.

Each framework gets a baseline and fixed `test.log` and `results.trx`.
`summary.json` records the baseline commit, model hashes, and individual test
results. Source copies are temporary; the checkout and Git branches are not
modified. Reports under `artifacts/` are ignored by Git.

This verifies the serialization defect and its correction. Reproducing the API
400 and verifying API acceptance require a separate sandbox test with valid
MLM Automatic Payments credentials and test payment data.

## MLB / MLM / MLA / MCO API comparison

`verify_cof_api.sh` builds isolated copies of SDK 3.7.0 and the working tree model,
then calls `PaymentClient.CreateAsync` with the same initial COF scenario in each.
The HTTP transport forwards the SDK-generated request without altering its JSON,
uses HTTPS with a 30-second timeout, disables redirects, and performs no retries.

The script reads `MP_TOKEN_BASE64` (or the legacy `MLB_TOKEN`) from the environment
and decodes it from Base64 in memory. Set `MP_TEST_SITE` to `MLB` (default), `MLM`, `MLA`, or `MCO`.
Use a test credential authorized for Customers, Card Tokens, and Automatic Payments.
It creates synthetic customers with the documented test-user email pattern and
cards using the country's published test Mastercard, then attempts an initial CIT
payment for 10 units of the local currency (10,000 COP in MCO). The published test
CPF is used for MLB, DNI for MLA, and CC for MCO. The legacy `TEST-` credential flow
uses the documented `test_payer@example.com` email; the test-user credential flow
uses the documented `test_payer_<digits>@testuser.com` pattern. An approved CIT is
followed by a MIT payment without CVV. Before creating a
payment, either `/users/me` must confirm the account's `test_user` tag or the card
token must explicitly report `live_mode=false`. APP_USR credentials on a verified
test account can return `live_mode=true` for tokenization. Only use this script for
an authorized test account.

```bash
DOTNET_BIN=/path/to/dotnet bash scripts/verify_cof_api.sh
# For Mexico, with MP_TOKEN_BASE64 already exported:
MP_TEST_SITE=MLM DOTNET_BIN=/path/to/dotnet bash scripts/verify_cof_api.sh
# For Argentina:
MP_TEST_SITE=MLA DOTNET_BIN=/path/to/dotnet bash scripts/verify_cof_api.sh
# For Colombia, compare a direct initial COF payment without saved customers:
MP_TEST_SITE=MCO MP_PROBE_FLOW=cof-direct DOTNET_BIN=/path/to/dotnet bash scripts/verify_cof_api.sh
```

Reports are saved in a new `artifacts/cof-api.*` directory. They include the COF
metadata, HTTP status, selected sanitized API errors, and test payment results;
access tokens, card tokens, full card data, and request headers are never logged.
Created test resources are retained for diagnosis. The comparison is successful
only if the original initial payment receives a 400 mentioning `first_time_use`
and the fixed initial request receives a successful HTTP response under a verified
test account or with `live_mode=false`. Other failures are inconclusive, not proof
of the bug or fix. A 401 with cause 300 (`Unauthorized use of live credentials`)
from Customers means the supplied credential is not accepted for that operation,
even if `/users/me` and raw card tokenization succeed. Follow the Automatic Payments
documentation's instructions for obtaining test credentials from the production
user's application.

`MP_PROBE_FLOW=cof-direct` compares fresh card-token payments with initial COF
metadata (`first_transaction=true`, `storage=store`, `transaction_initiator=customer`)
and payer email. This variant bypasses saved Customers and directly exercises the
reported request-model defect. It does not store a reusable card or test a subsequent
MIT. In MCO, this comparison reproduced the original 400 / cause 4118 for
`first_time_use` and produced an approved test payment with the fixed model.
`MP_PROBE_FLOW=initial` (default) retains the saved-customer/card flow and MIT check.

For a read-only credential check:

```bash
dotnet run --project scripts/CofApiProbe --configuration Release -- preflight
```

For a separate authorization check on the card-token endpoint (creates a token
for the published test card, but does not create a customer, saved card, or payment):

```bash
dotnet run --project scripts/CofApiProbe --configuration Release -- tokenize
```

## Standard Orders payment probe

The `orders` mode creates a standard card order through `OrderClient.CreateAsync`
and reads it back through `OrderClient.GetAsync`. It uses a fresh published test
Mastercard token with cardholder `APRO`, the required `test@testuser.com` payer
email, automatic processing, and an amount of 50 local currency units. It does
not require a saved customer or configure stored credentials. The account must
match `MP_TEST_SITE`, and the same test-account/token checks apply before creation.

```bash
MP_TEST_SITE=MLM dotnet run --project scripts/CofApiProbe --configuration Release -- orders
```

The output includes order and payment IDs, statuses, amounts, HTTP results, and
the order request with its card token redacted. This checks Orders payment
creation and processing; it does not validate the `PaymentTransactionDataRequest`
COF fix, which is exercised through the Payments API comparison.

## Standard Payments authorization probe

The `payments` mode tokenizes a fresh published test card and sends a standard
50-unit card payment (10,000 COP in MCO) through `PaymentClient.CreateAsync`, with a synthetic test
payer email and no saved customer or COF metadata. On success, it reads the payment
back. This isolates `/v1/payments` authorization from `/v1/customers` authorization.

```bash
MP_TEST_SITE=MLM dotnet run --project scripts/CofApiProbe --configuration Release -- payments
```

Request card tokens are redacted from the report. This mode checks ordinary
Payments creation and retrieval, not the COF boolean regression.
