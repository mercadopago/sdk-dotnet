namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Order reference associated with a <see cref="PaymentCreateRequest"/>.
    /// Links the payment to an existing purchase order in MercadoPago.
    /// </summary>
    public class PaymentOrderRequest
    {
        /// <summary>
        /// Unique identifier of the associated purchase order.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Type of the order (e.g., "mercadolibre").
        /// </summary>
        public string Type { get; set; }
    }
}
