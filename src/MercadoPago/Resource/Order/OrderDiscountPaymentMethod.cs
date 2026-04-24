namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a discount applied to a specific payment method type within <see cref="OrderDiscounts"/>,
    /// adjusting the total amount when that payment method is used.
    /// </summary>
    public class OrderDiscountPaymentMethod
    {
        /// <summary>
        /// Payment method type that qualifies for this discount (e.g., "credit_card", "debit_card", "account_money").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Adjusted total order amount after applying this payment-method-specific discount.
        /// </summary>
        public string NewTotalAmount { get; set; }
    }
}
