using System;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;

namespace MercadoPagoExample.Payments
{
    public static class ApiPaymentExample
    {
        public static string Run()
        {
            Utils.LoadOrPromptAccessToken();

            var payment = new Payment
            {
                TransactionAmount = 1000,
                Token = "card_token_id",
                Description = "Cats",
                ExternalReference = "YOUR_REFERENCE",
                PaymentMethodId = "visa",
                Installments = 1,
                Payer = new Payer {
                    Email = "some@mail.com",
                    FirstName = "Diana",
                    LastName = "Prince"
                },
            };

            payment.Save();

            return payment.Status.ToString();
        }
    }
}
