namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Transaction detail information for a <see cref="PaymentCreateRequest"/>.
    /// Contains data specific to certain payment methods, such as the financial institution
    /// used for bank transfer payments.
    /// </summary>
    public class PaymentTransactionDetailsRequest
    {
        /// <summary>
        /// Identifier of the external financial institution processing the payment
        /// (required for bank transfer payment methods).
        /// </summary>
        public string FinancialInstitution { get; set; }
    }
}
