namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Payment's reference.
    /// </summary>
    public class PaymentPaymentReferenceRequest
    {
        /// <summary>
        /// Period.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Acquirer.
        /// </summary>
        public string Acquirer { get; set; }
    }
}