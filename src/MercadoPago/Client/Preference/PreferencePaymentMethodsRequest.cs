namespace MercadoPago.Client.Preference
{
    using System.Collections.Generic;

    /// <summary>
    /// Set up payment methods.
    /// </summary>
    public class PreferencePaymentMethodsRequest
    {
        /// <summary>
        /// Payment methods not allowed in payment process (except account_money).
        /// </summary>
        public IList<PreferencePaymentMethodRequest> ExcludedPaymentMethods { get; set; }

        /// <summary>
        /// Payment types not allowed in payment process.
        /// </summary>
        public IList<PreferencePaymentTypeRequest> ExcludedPaymentTypes { get; set; }

        /// <summary>
        /// Payment method to be preferred on the payments methods list.
        /// </summary>
        public string DefaultPaymentMethodId { get; set; }

        /// <summary>
        /// Maximum number of credit card installments to be accepted.
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Prefered number of credit card installments.
        /// </summary>
        public int? DefaultInstallments { get; set; }
    }
}
