using System;
using MercadoPago.Config;
using MercadoPago.Client.Chargeback;
using MercadoPago.Resource.Chargeback;

internal class GetChargebackExample
{
    private static void Main(string[] args)
    {
        // Set the MercadoPago access token
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        // Create a chargeback client
        var client = new ChargebackClient();

        // Get a chargeback by ID
        string chargebackId = "{{CHARGEBACK_ID}}";
        Chargeback chargeback = client.Get(chargebackId);

        // Display the chargeback details
        Console.WriteLine($"Chargeback ID: {chargeback.Id}");
        Console.WriteLine($"Payment ID: {chargeback.PaymentId}");
        Console.WriteLine($"Amount: {chargeback.Amount} {chargeback.CurrencyId}");
        Console.WriteLine($"Status: {chargeback.Status}");
        Console.WriteLine($"Reason: {chargeback.Reason}");
        Console.WriteLine($"Created: {chargeback.DateCreated}");
        Console.WriteLine($"Last Updated: {chargeback.DateLastUpdated}");
        
        // Display metadata if available
        if (chargeback.Metadata != null && chargeback.Metadata.Count > 0)
        {
            Console.WriteLine("\nMetadata:");
            foreach (var item in chargeback.Metadata)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
