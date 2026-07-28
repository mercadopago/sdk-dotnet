using System;
using System.Collections.Generic;
using MercadoPago.Config;
using MercadoPago.Client.Order;
using MercadoPago.Resource.Order;

/// <summary>
/// Mercado Pago Create Order — Automatic Payments (recurring charges).
///
/// Demonstrates the two-step Automatic Payments flow:
///   1. First payment  — CVV-validated charge that registers the card credential.
///   2. Recurring charge — subsequent MIT charge without CVV, referencing step 1.
///
/// Prerequisites:
///   - A customer created via POST /v1/customers                               → CUSTOMER_ID
///   - A payment profile created via POST /v1/customers/{id}/payment-profiles  → PAYMENT_PROFILE_ID
/// </summary>
internal class CreateOrderWithAutomaticPaymentsExample
{
    private static void Main(string[] args)
    {
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        var customerId      = "{{CUSTOMER_ID}}";
        var paymentProfileId = "{{PAYMENT_PROFILE_ID}}";
        var payerEmail      = "{{PAYER_EMAIL}}";
        var cardToken       = "{{CARD_TOKEN}}";

        var client = new OrderClient();

        // ── Step 1: First payment ─────────────────────────────────────────────
        // Registers the card credential with FirstPayment: true.
        // No PrevTransactionRef is needed on the first charge.
        var firstPaymentRequest = new OrderCreateRequest
        {
            Type              = "online",
            ProcessingMode    = "automatic",
            TotalAmount       = "100.00",
            ExternalReference = "subscription-001-payment-1",
            Payer = new OrderPayerRequest
            {
                Email      = payerEmail,
                CustomerId = customerId,
            },
            Transactions = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>
                {
                    new OrderPaymentRequest
                    {
                        Amount = "100.00",
                        PaymentMethod = new OrderPaymentMethodRequest
                        {
                            Id           = "master",
                            Type         = "credit_card",
                            Token        = cardToken,
                            Installments = 1,
                        },
                        AutomaticPayments = new OrderAutomaticPaymentsRequest
                        {
                            PaymentProfileId = paymentProfileId,
                        },
                        StoredCredential = new OrderStoredCredentialRequest
                        {
                            PaymentInitiator = "customer",
                            Reason           = "recurring",
                            FirstPayment     = true,
                        },
                    }
                }
            }
        };

        Order firstOrder = client.Create(firstPaymentRequest);
        Console.WriteLine($"First payment order ID: {firstOrder.Id}");
        Console.WriteLine($"Status: {firstOrder.Status}");

        // Save the payment ID — required as PrevTransactionRef in subsequent charges.
        var firstPaymentId = firstOrder.Transactions?.Payments?[0]?.Id;
        if (string.IsNullOrEmpty(firstPaymentId))
        {
            Console.WriteLine("Could not retrieve first payment ID.");
            return;
        }
        Console.WriteLine($"First payment ID (save for next charge): {firstPaymentId}");

        // ── Step 2: Recurring charge ──────────────────────────────────────────
        // Subsequent MIT charge — no card token needed, uses the payment profile.
        // PrevTransactionRef links this charge to the original card-network authorization.
        var recurringRequest = new OrderCreateRequest
        {
            Type              = "online",
            ProcessingMode    = "automatic_async",
            TotalAmount       = "100.00",
            ExternalReference = "subscription-001-payment-2",
            Payer = new OrderPayerRequest
            {
                Email      = payerEmail,
                CustomerId = customerId,
            },
            Transactions = new OrderTransactionRequest
            {
                Payments = new List<OrderPaymentRequest>
                {
                    new OrderPaymentRequest
                    {
                        Amount = "100.00",
                        AutomaticPayments = new OrderAutomaticPaymentsRequest
                        {
                            PaymentProfileId = paymentProfileId,
                            Retries          = 3,
                            ScheduleDate     = "2026-09-01T00:00:00.000-04:00",
                            DueDate          = "2026-09-05T00:00:00.000-04:00",
                        },
                        StoredCredential = new OrderStoredCredentialRequest
                        {
                            PaymentInitiator = "merchant",
                            Reason           = "recurring",
                            FirstPayment     = false,
                            PrevTransactionRef = firstPaymentId,
                        },
                        SubscriptionData = new OrderSubscriptionDataRequest
                        {
                            InvoiceId   = "INV-002",
                            BillingDate = "2026-08-01",
                            SubscriptionSequence = new OrderSubscriptionSequenceRequest
                            {
                                Number = 2,
                                Total  = 12,
                            },
                            InvoicePeriod = new OrderInvoicePeriodRequest
                            {
                                Type   = "monthly",
                                Period = 1,
                            },
                        },
                    }
                }
            }
        };

        Order recurringOrder = client.Create(recurringRequest);
        Console.WriteLine($"\nRecurring charge order ID: {recurringOrder.Id}");
        Console.WriteLine($"Status: {recurringOrder.Status}");
        Console.WriteLine($"Status detail: {recurringOrder.StatusDetail}");
    }
}
