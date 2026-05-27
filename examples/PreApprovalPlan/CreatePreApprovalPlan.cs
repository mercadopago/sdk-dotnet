using MercadoPago.Client.PreApprovalPlan;
using MercadoPago.Config;

MercadoPagoConfig.AccessToken = "<YOUR_ACCESS_TOKEN>";

var client = new PreApprovalPlanClient();

var request = new PreApprovalPlanCreateRequest
{
    Reason = "Monthly subscription plan",
    BackUrl = "https://yourapp.com/back",
    AutoRecurring = new PreApprovalPlanAutoRecurringRequest
    {
        Frequency = 1,
        FrequencyType = "months",
        CurrencyId = "BRL",
        TransactionAmount = 49.90m
    }
};

var plan = await client.CreateAsync(request);
Console.WriteLine($"Plan ID: {plan.Id}");
Console.WriteLine($"Init point: {plan.InitPoint}");
