namespace MercadoPago.Client.Preference
{
    using System.Collections.Generic;

    /// <summary>
    /// Configuration for which payment methods and installment options are available at checkout.
    /// Use this to exclude specific methods or types, set defaults, and limit installment plans.
    /// </summary>
    /// <seealso cref="PreferenceRequest"/>
    public class PreferencePaymentMethodsRequest
    {
        /// <summary>
        /// List of specific payment methods to exclude from checkout (except <c>account_money</c>,
        /// which cannot be excluded). Each entry identifies a payment method by its ID.
        /// </summary>
        /// <seealso cref="PreferencePaymentMethodRequest"/>
        public IList<PreferencePaymentMethodRequest> ExcludedPaymentMethods { get; set; }

        /// <summary>
        /// List of payment types to exclude from checkout (e.g., <c>"ticket"</c>, <c>"atm"</c>).
        /// </summary>
        /// <seealso cref="PreferencePaymentTypeRequest"/>
        public IList<PreferencePaymentTypeRequest> ExcludedPaymentTypes { get; set; }

        /// <summary>
        /// ID of the payment method to pre-select in the checkout payment methods list.
        /// </summary>
        public string DefaultPaymentMethodId { get; set; }

        /// <summary>
        /// Maximum number of credit card installments accepted for this preference.
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Preferred number of credit card installments to pre-select at checkout.
        /// </summary>
        public int? DefaultInstallments { get; set; }
    }
}
