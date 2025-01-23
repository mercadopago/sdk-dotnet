namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Payment Method class.
    /// </summary>
    public class OrderPaymentMethod
    {
        /// <summary>
        /// Payment Method ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Card ID.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Payment Method Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Payment Method Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// How will look the payment in the card bill (e.g.: MERCADOPAGO).
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Number of installments.
        /// </summary>
        public int Installments { get; set; }
    }
}