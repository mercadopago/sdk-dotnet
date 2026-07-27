namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Reference to a related resource within <see cref="PaymentTransactionData"/>,
    /// used to link a CREDENTIAL_ON_FILE payment to a mandate or agreement.
    /// </summary>
    public class PaymentReference
    {
        /// <summary>
        /// Identifier of the referenced resource (e.g., a mandate or agreement ID).
        /// </summary>
        public string Id { get; set; }
    }
}
