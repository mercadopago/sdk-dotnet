namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Expanded data information.
    /// </summary>
    public class PaymentExpandedData
    {
        /// <summary>
        /// Gateway information.
        /// </summary>
        public PaymentGatewayData Gateway { get; set; }
    }

    /// <summary>
    /// Gateway data information.
    /// </summary>
    public class PaymentGatewayData
    {
        /// <summary>
        /// Reference information.
        /// </summary>
        public PaymentReferenceData Reference { get; set; }
    }

    /// <summary>
    /// Reference data information.
    /// </summary>
    public class PaymentReferenceData
    {
        /// <summary>
        /// Network transaction ID.
        /// </summary>
        public string NetworkTransactionId { get; set; }
    }
}