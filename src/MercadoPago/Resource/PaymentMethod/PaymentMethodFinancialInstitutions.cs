namespace MercadoPago.Resource.PaymentMethod
{
    /// <summary>
    /// A financial institution (bank or processor) associated with a
    /// <see cref="PaymentMethod"/>. Relevant for payment methods where the
    /// payer must select a specific institution (e.g. bank transfers, ATM
    /// payments).
    /// </summary>
    public class PaymentMethodFinancialInstitutions
    {
        /// <summary>
        /// External identifier of the financial institution (e.g. company ID
        /// for ATM networks).
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Human-readable name of the financial institution.
        /// </summary>
        public string Description { get; set; }
    }
}
