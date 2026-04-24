namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Reference to a previous payment in a subscription series,
    /// used within <see cref="PaymentTransactionDataRequest"/> to link recurring payments.
    /// </summary>
    public class PaymentPaymentReferenceRequest
    {
        /// <summary>
        /// Identifier of the referenced payment from a previous billing cycle.
        /// </summary>
        public string Id { get; set; }

    }
}