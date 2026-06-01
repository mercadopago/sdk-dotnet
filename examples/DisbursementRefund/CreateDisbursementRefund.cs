using MercadoPago.Client.DisbursementRefund;
using MercadoPago.Config;

MercadoPagoConfig.AccessToken = "<YOUR_ACCESS_TOKEN>";

var client = new DisbursementRefundClient();
var advancedPaymentId = 123456789L;

// List all refunds for an advanced payment
var refunds = await client.ListAllAsync(advancedPaymentId);
Console.WriteLine($"Total refunds: {refunds?.Count ?? 0}");

// Refund a specific disbursement
var disbursementId = 987654321L;
var request = new DisbursementRefundCreateRequest { Amount = 50.00m };
var refund = await client.CreateAsync(advancedPaymentId, disbursementId, request);
Console.WriteLine($"Refund ID: {refund.Id}, Status: {refund.Status}");
