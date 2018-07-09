using MercadoPago.Resources.New;

namespace MercadoPagoExample.Payments
{
    public static class PaymentSearchExample
    {
        public static void Run()
        {
            Utils.LoadOrPromptAccessToken();

            var payments = Payment.Search();
        }
    }
}