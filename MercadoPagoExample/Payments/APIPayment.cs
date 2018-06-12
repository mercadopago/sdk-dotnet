using System;
namespace MercadoPagoExample.Payments
{
    public class APIPayment
    {
        public string DoPayment()
        {
            MercadoPago.SDK.ClientSecret = "ACCESS_TOKEN_VALUE";

            Payment payment = new Payment
            {
                TransactionAmount = (float)1000,
                Token = "card_token_id",
                Description = "Cats",
                ExternalReference = "YOUR_REFERENCE",
                PaymentMethodId = "visa",
                Installments = 1,
                Payer = new Payer {
                    Email = "some@mail.com",
                    FistName = "Diana",
                    LastName = "Prince"
                }
            };

            payment.Save();

            return payment.Status;
        }
    }
}
