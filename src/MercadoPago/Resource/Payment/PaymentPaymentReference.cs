namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Reference to a related payment within <see cref="PaymentTransactionData"/>,
    /// used to link subscription or recurring payments to their originating payment.
    /// </summary>
    public class PaymentPaymentReference
    {
        /// <summary>
        /// Identifier of the referenced payment that this transaction is
        /// linked to (e.g., the initial payment in a subscription series).
        /// </summary>
        public string Id { get; set; }

    }
}