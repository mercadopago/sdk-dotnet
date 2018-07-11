using MercadoPago.Resources;
using System.Linq;
using MercadoPago.Common;

namespace MercadoPagoExample.Payments
{
    public static class PaymentSearchExample
    {
        public static void Run()
        {
            Utils.LoadOrPromptAccessToken();

            var allPayments = Payment.All();

            var approvedPayments = 
                Payment.Query()
                       .Where(x => x.Status == PaymentStatus.approved)
                       .ToList();

            var rejectedPayments = 
                Payment.Query()
                       .Where(x => x.Status == PaymentStatus.rejected)
                       .ToList();
        }
    }
}