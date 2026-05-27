namespace MercadoPago.Client.Point
{
    /// <summary>
    /// Payment method details included in a payment intent creation request.
    /// </summary>
    public class PointPaymentRequest
    {
        /// <summary>
        /// Number of installments for the payment.
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Payment type identifier (e.g. <c>credit_card</c>, <c>debit_card</c>).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Installment cost to be paid by the buyer or the seller.
        /// </summary>
        public string InstallmentsCost { get; set; }
    }
}
