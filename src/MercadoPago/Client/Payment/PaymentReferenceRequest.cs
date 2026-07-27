namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Reference to a related resource within a CREDENTIAL_ON_FILE payment flow,
    /// used within <see cref="PaymentTransactionDataRequest"/> to link a mandate
    /// or agreement identifier.
    /// </summary>
    public class PaymentReferenceRequest
    {
        /// <summary>
        /// Identifier of the referenced resource (e.g., a mandate or agreement ID).
        /// </summary>
        public string Id { get; set; }
    }
}
