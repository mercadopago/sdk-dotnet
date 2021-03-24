namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Order identifier.
    /// </summary>
    public class PaymentOrder
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
