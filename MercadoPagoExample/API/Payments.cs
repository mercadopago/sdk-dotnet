using System;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;

namespace MercadoPagoExample.API
{
    public class Payments : IExample 
    {
        public string Name => "Payments with API";

        public void Run()
        {

            MercadoPago.SDK.AccessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");

            Console.WriteLine("Example of Payment");
            //var payment = new Payment
            //{
            //    TransactionAmount = 1000,
            //    Token = "card_token_id",
            //    Description = "Cats",
            //    ExternalReference = "YOUR_REFERENCE",
            //    PaymentMethodId = "visa",
            //    Installments = 1,
            //    Payer = new Payer {
            //        Email = "some@mail.com",
            //        FirstName = "Diana",
            //        LastName = "Prince"
            //    },
            //};

            //payment.Save();

        }
         
    }
}
