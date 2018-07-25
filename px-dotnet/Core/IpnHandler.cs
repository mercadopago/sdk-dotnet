using System;
using MercadoPago.Resources;

namespace MercadoPago
{
    public static class Ipn
    {
        internal const string Payment = "payment";
        internal const string MerchantOrder = "merchant_order";

        public static void HandleNotification(string topic, string id, Action<Payment> onPaymentReceived = null, Action<MerchantOrder> onMerchantOrderReceived = null)
        {
            if (string.IsNullOrEmpty(topic) || string.IsNullOrEmpty(id))
            {
                throw new MPException("Topic and Id can not be null in the IPN request.");
            }

            if (onPaymentReceived == null && onMerchantOrderReceived == null)
                throw new ArgumentNullException($"{nameof(onPaymentReceived)} and {nameof(onMerchantOrderReceived)} cannot be null at the same time. Please specify at least one of them.");

            switch (topic)
            {
                case Payment:
                    if (onPaymentReceived != null)
                    {
                        if (!int.TryParse(id, out var paymentId))
                            throw new MPException($"Invalid Payment Id: {id}");
                        var payment = Resources.Payment.FindById(paymentId);
                        onPaymentReceived(payment);
                    }
                    break;
                case MerchantOrder:
                    if (onMerchantOrderReceived != null)
                    {
                        var merchantOrder = Resources.MerchantOrder.FindById(id);
                        onMerchantOrderReceived(merchantOrder);
                    }
                    break;
            }
        }
    }
}