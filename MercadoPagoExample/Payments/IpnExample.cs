using System;
using MercadoPago;
using MercadoPago.Resources;

namespace MercadoPagoExample.Payments
{
    public static class IpnExample
    {
        public static void Run()
        {
            Utils.LoadOrPromptAccessToken();

            // You will receive this invocation via an HTTP POST from MercadoPago to your web application
            IpnNotification("payment", "1234");
        }

        // Put this in an ASP.NET controller supporting HTTP POST
        public static void IpnNotification(string topic, string id)
        {
            Ipn.HandleNotification(topic, id, onPaymentReceived: OnPaymentReceived, onMerchantOrderReceived: OnMerchantOrderReceived);
        }

        private static void OnPaymentReceived(Payment payment)
        {
            Console.WriteLine($"Payment Received: {payment.Id}");
        }

        private static void OnMerchantOrderReceived(MerchantOrder merchantOrder)
        {
            Console.WriteLine($"Merchant Order Received: {merchantOrder.Id}");
        }
    }
}