namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Payment's reference.
    /// </summary>
    public class PaymentPaymentReference
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