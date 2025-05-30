using System;
using MercadoPago.Config;
using MercadoPago.Client;
using MercadoPago.Client.Chargeback;
using MercadoPago.Resource.Chargeback;
using System.Collections.Generic;

internal class SearchChargebackExample
{
    private static void Main(string[] args)
    {
        // Set the MercadoPago access token
        MercadoPagoConfig.AccessToken = "{{ACCESS_TOKEN}}";

        // Create a chargeback client
        var client = new ChargebackClient();

        // Create a search request with filters
        var searchRequest = new SearchRequest();
        searchRequest.Filters.Add("payment_id", "12345"); // Filter by payment ID

        // Search for chargebacks
        var searchResult = client.Search(searchRequest);

        // Display the search results
        Console.WriteLine($"Total results: {searchResult.Paging.Total}");
        foreach (var chargeback in searchResult.Results)
        {
            Console.WriteLine($"Chargeback ID: {chargeback.Id}");
            Console.WriteLine($"Payment ID: {chargeback.PaymentId}");
            Console.WriteLine($"Amount: {chargeback.Amount} {chargeback.CurrencyId}");
            Console.WriteLine($"Status: {chargeback.Status}");
            Console.WriteLine($"Reason: {chargeback.Reason}");
            Console.WriteLine($"Created: {chargeback.DateCreated}");
            Console.WriteLine("-----------------------------------");
        }
    }
}
