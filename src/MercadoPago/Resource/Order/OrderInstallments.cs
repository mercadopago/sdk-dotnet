namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the installment plan configuration within <see cref="OrderPaymentMethodConfig"/>,
    /// including interest-free and available installment options.
    /// </summary>
    public class OrderInstallments
    {
        /// <summary>
        /// Interest-free installment configuration specifying which installment counts carry no interest.
        /// See <see cref="OrderInstallmentsInterestFree"/>.
        /// </summary>
        public OrderInstallmentsInterestFree InterestFree { get; set; }

        /// <summary>
        /// Available installment configuration defining which installment plans are offered to the payer.
        /// See <see cref="OrderInstallmentsAvailable"/>.
        /// </summary>
        public OrderInstallmentsAvailable Available { get; set; }
    }
}
