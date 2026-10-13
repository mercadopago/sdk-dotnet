# .NET examples

These programs demonstrate integration flows implemented by the .NET SDK. Start with Orders, then choose another API only when the payment product requires it.

## Orders first

Orders is the most complete learning path in this repository: it covers creation, retrieval, processing, capture, cancellation, refunds, and transaction management.

| Stage | Goal | Example |
|---|---|---|
| 1. Create | Submit a basic order | [`Order/Create.cs`](Order/Create.cs) |
| 2. Inspect | Retrieve the server-side result | [`Order/Get.cs`](Order/Get.cs) |
| 3. Advance | Process or capture an order | [`Order/Process.cs`](Order/Process.cs) · [`Order/Capture.cs`](Order/Capture.cs) |
| 4. Reverse | Cancel, partially refund, or fully refund | [`Order/Cancel.cs`](Order/Cancel.cs) · [`Order/PartialRefund.cs`](Order/PartialRefund.cs) · [`Order/TotalRefund.cs`](Order/TotalRefund.cs) |
| 5. Manage transactions | Create, update, or delete a transaction | [`CreateTransaction.cs`](Order/CreateTransaction.cs) · [`UpdateTransaction.cs`](Order/UpdateTransaction.cs) · [`DeleteTransaction.cs`](Order/DeleteTransaction.cs) |
| 6. Add a payment flow | Use PSE, 3DS, or automatic payments | [`CreatePSE.cs`](Order/CreatePSE.cs) · [`Create3DS.cs`](Order/Create3DS.cs) · [`CreateWithAutomaticPayments.cs`](Order/CreateWithAutomaticPayments.cs) |

For a production implementation, carry the same idempotency key across retries, reconcile unknown outcomes, and handle API errors explicitly. See [retries and idempotency](../docs/retries-and-idempotency.md) and [error handling](../docs/error-handling.md).

## Other supported examples

| Goal | API | Examples |
|---|---|---|
| Create a hosted checkout | Preferences API | [`Preference/`](Preference/) |
| Create a subscription plan | Preapproval Plan API | [`PreApprovalPlan/`](PreApprovalPlan/) |
| Create a Point payment intent | Point API | [`Point/`](Point/) |
| Search chargebacks | Chargebacks API | [`Chargeback/`](Chargeback/) |
| Refund a disbursement | Advanced Payments API | [`DisbursementRefund/`](DisbursementRefund/) |

## Before running an example

Use test credentials and test data, replace every placeholder, and confirm required fields in the [API reference](https://www.mercadopago.com/developers/en/reference). Product and country availability may vary. Never commit credentials or use production card data in examples.
