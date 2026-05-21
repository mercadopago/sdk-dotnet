namespace MercadoPago.Resource.Preference
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the payment method configuration for a <see cref="Preference"/>.
    /// Controls which payment methods and types are available, excluded, or set as default
    /// during the Checkout Pro flow.
    /// </summary>
    public class PreferencePaymentMethods
    {
        /// <summary>
        /// List of specific payment methods excluded from the checkout flow.
        /// Note: <c>account_money</c> cannot be excluded via this list.
        /// </summary>
        public IList<PreferencePaymentMethod> ExcludedPaymentMethods { get; set; }

        /// <summary>
        /// List of payment types excluded from the checkout flow
        /// (e.g., <c>credit_card</c>, <c>debit_card</c>, <c>ticket</c>).
        /// </summary>
        public IList<PreferencePaymentType> ExcludedPaymentTypes { get; set; }

        /// <summary>
        /// Identifier of the payment method to be pre-selected as the default option
        /// in the checkout flow.
        /// </summary>
        public string DefaultPaymentMethodId { get; set; }

        /// <summary>
        /// Maximum number of credit card installments allowed for payments created from this preference.
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Preferred (pre-selected) number of credit card installments shown by default in the checkout flow.
        /// </summary>
        public int? DefaultInstallments { get; set; }
    }
}
