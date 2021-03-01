using System;
using System.Threading.Tasks;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;

namespace MercadoPago.Snippets.CheckoutTransparente
{
    public static class CreateBasicPayment
    {
        public async static Task SnippetAsync()
        {
            //MercadoPagoConfig.AccessToken = "YOUR_ACCESS_TOKEN";

            var request = new PaymentCreateRequest
            {
                TransactionAmount = 10,
                Token = "150331a83ab6bc819eb5404ff1022ff2",
                Description = "New payment",
                Installments = 1,
                PaymentMethodId = "visa",
                Payer = new PaymentPayerRequest
                {
                    Email = "test_payer_99999999@testuser.com",
                }
            };
            //{
            //    TransactionAmount = float.Parse(Request["transactionAmount"]),
            //    Token = Request["token"],
            //    Description = Request["description"],
            //    Installments = int.Parse(Request["installments"]),
            //    PaymentMethodId = Request["paymentMethodId"],
            //    Payer = new Client.Payment.Payer
            //    {
            //        Email = Request["email"],
            //        Identification = new Identification
            //        {
            //            Type = Request["docType"],
            //            Number = Request["docNumber]
            //        }
            //    }
            //};

            var client = new PaymentClient();
            Payment payment = await client.CreateAsync(request);

            Console.WriteLine($"Payment ID: {payment.Id}");
        }

        //public static void Snippet()
        //{
        //    MercadoPagoConfig.AccessToken = "APP_USR-736854c6-ed93-4000-8beb-799679d74b7a";
        //    //MercadoPagoConfig.AccessToken = "YOUR_ACCESS_TOKEN";

        //    var request = new PaymentCreateRequest
        //    {
        //        TransactionAmount = 10,
        //        Token = "f2ddce76a3a19baf4826a40a9392ae06",
        //        Description = "New payment",
        //        Installments = 1,
        //        PaymentMethodId = "visa",
        //        Payer = new Client.Payment.Payer
        //        {
        //            Email = "test_payer_99999999@testuser.com",
        //        }
        //    };
        //    //{
        //    //    TransactionAmount = float.Parse(Request["transactionAmount"]),
        //    //    Token = Request["token"],
        //    //    Description = Request["description"],
        //    //    Installments = int.Parse(Request["installments"]),
        //    //    PaymentMethodId = Request["paymentMethodId"],
        //    //    Payer = new Client.Payment.Payer
        //    //    {
        //    //        Email = Request["email"],
        //    //        Identification = new Identification
        //    //        {
        //    //            Type = Request["docType"],
        //    //            Number = Request["docNumber]
        //    //        }
        //    //    }
        //    //};

        //    var client = new PaymentClient();
        //    Payment payment = client.Create(request);

        //    Console.WriteLine($"Payment ID: {payment.Id}");
        //}
    }
}
