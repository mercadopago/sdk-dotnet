// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Installment plan configuration for an order payment method.
    /// </summary>
    /// <seealso cref="OrderPaymentMethodConfigRequest"/>
    public class OrderInstallmentsRequest
    {
        /// <summary>
        /// Interest-free installment configuration.
        /// </summary>
        /// <seealso cref="OrderInstallmentsInterestFreeRequest"/>
        public OrderInstallmentsInterestFreeRequest InterestFree { get; set; }
    }
}
