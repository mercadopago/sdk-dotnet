using MercadoPago.Resources.New;
using System.Linq;
using MercadoPago.Common;

namespace MercadoPagoExample.Payments
{
    public static class PaymentSearchExample
    {
        public static void Run()
        {
            Utils.LoadOrPromptAccessToken();

            var allPayments = Payment.Search();

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