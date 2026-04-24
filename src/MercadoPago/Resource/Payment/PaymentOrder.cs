namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Order information linking a <see cref="Payment"/> to a purchase order
    /// in MercadoPago. Allows correlating payments with their originating orders.
    /// </summary>
    public class PaymentOrder
    {
        /// <summary>
        /// Unique identifier of the associated purchase order in MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Type of the associated order. Possible values: "mercadolibre"
        /// (for Mercado Libre marketplace orders) or "mercadopago"
        /// (for MercadoPago checkout orders).
        /// </summary>
        public string Type { get; set; }
    }
}
