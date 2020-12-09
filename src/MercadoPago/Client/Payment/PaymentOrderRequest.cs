namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Order identifier.
    /// </summary>
    public class PaymentOrderRequest
    {
        /// <summary>
        /// Id of the associated purchase order.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Order type.
        /// </summary>
        public string Type { get; set; }
    }
}
