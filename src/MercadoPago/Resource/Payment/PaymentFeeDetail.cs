namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Detailed breakdown of a fee charged on a payment, specifying the fee type,
    /// who absorbs the cost, and the amount. Part of the <see cref="Payment.FeeDetails"/> list.
    /// </summary>
    public class PaymentFeeDetail
    {
        /// <summary>
        /// Type of fee charged. Possible values include "mercadopago_fee"
        /// (MercadoPago commission) and "financing_fee" (installment financing cost).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicates who absorbs this fee. Possible values: "collector"
        /// (seller pays) or "payer" (buyer pays).
        /// </summary>
        public string FeePayer { get; set; }

        /// <summary>
        /// Amount of this fee in the payment's currency.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}
