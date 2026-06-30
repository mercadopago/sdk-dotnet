namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents payment method configuration options for an <see cref="Order"/>, controlling
    /// default payment types, installment plans, and cost absorption settings.
    /// </summary>
    public class OrderPaymentMethodConfig
    {
        /// <summary>
        /// Default payment method type pre-selected in the checkout (e.g., "credit_card", "debit_card").
        /// </summary>
        public string DefaultType { get; set; }

        /// <summary>
        /// List of payment method IDs blocked for this order.
        /// </summary>
        public IList<string> NotAllowedIds { get; set; }

        /// <summary>
        /// List of payment method types blocked for this order.
        /// </summary>
        public IList<string> NotAllowedTypes { get; set; }

        /// <summary>
        /// Maximum number of installments accepted for this order.
        /// </summary>
        public int? MaxInstallments { get; set; }

        /// <summary>
        /// Determines who absorbs the installment interest cost. Possible values: "seller" (seller absorbs) or "buyer" (payer absorbs).
        /// </summary>
        public string InstallmentsCost { get; set; }

        /// <summary>
        /// Installment plan configuration including interest-free and available options.
        /// See <see cref="OrderInstallments"/>.
        /// </summary>
        public OrderInstallments Installments { get; set; }

        /// <summary>
        /// Minimum number of installments that must be offered to the payer during checkout.
        /// </summary>
        public int? MinInstallments { get; set; }
    }
}
