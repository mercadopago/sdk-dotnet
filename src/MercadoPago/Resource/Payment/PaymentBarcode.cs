using MercadoPago.Client.Payment;

namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Barcode information associated with a ticket or boleto payment method,
    /// used within <see cref="PaymentTransactionDetails"/>.
    /// </summary>
    public class PaymentBarcode
    {
        /// <summary>
        /// Encoded content of the barcode (e.g., the numeric string for
        /// a boleto or ticket payment slip).
        /// </summary>
        public string Content { get; set; }
    }
}