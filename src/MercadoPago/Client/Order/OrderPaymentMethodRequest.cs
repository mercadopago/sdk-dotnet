namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Payment Method class.
    /// </summary>       
    public class OrderPaymentMethodRequest
    {
        /// <summary>
        /// Payment method ID.
        /// </summary>       
        public string Id { get; set; }

        /// <summary>
        /// Payment method type.
        /// </summary>       
        public string Type { get; set; }

        /// <summary>
        /// Payment method token.
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