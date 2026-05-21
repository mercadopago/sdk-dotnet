using MercadoPago.Client.Payment;

namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Detailed transaction information for a <see cref="Payment"/>, including
    /// net received amounts, installment values, payment references, and
    /// barcode or Pix data.
    /// </summary>
    public class PaymentTransactionDetails
    {
        /// <summary>
        /// External identifier of the financial institution that processed
        /// the payment (e.g., bank code for transfers).
        /// </summary>
        public string FinancialInstitution { get; set; }

        /// <summary>
        /// Net amount received by the seller (collector) after all fees
        /// and commissions have been deducted.
        /// </summary>
        public decimal? NetReceivedAmount { get; set; }

        /// <summary>
        /// Total amount paid by the buyer (payer), including any financing
        /// fees, taxes, and surcharges.
        /// </summary>
        public decimal? TotalPaidAmount { get; set; }

        /// <summary>
        /// Amount of each installment when the payment is split into
        /// multiple installments.
        /// </summary>
        public decimal? InstallmentAmount { get; set; }

        /// <summary>
        /// Amount overpaid by the payer. Only applicable for ticket and
        /// boleto payment methods where the payer may pay more than the
        /// required amount.
        /// </summary>
        public decimal? OverpaidAmount { get; set; }

        /// <summary>
        /// URL of the external resource in the payment processor that
        /// identifies this transaction (e.g., a payment receipt page).
        /// </summary>
        public string ExternalResourceUrl { get; set; }

        /// <summary>
        /// Payment method reference identifier. For credit card payments,
        /// this is the USN (Unique Sequence Number). For offline payment
        /// methods (ticket, boleto), this is the reference code to provide
        /// to the cashier or enter at the ATM.
        /// </summary>
        public string PaymentMethodReferenceId { get; set; }

        /// <summary>
        /// BACEN (Central Bank of Brazil) transaction identifier for Pix
        /// payments. Used for end-to-end traceability within the Pix network.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Reference identifier assigned by the payment acquirer (processor)
        /// for this transaction.
        /// </summary>
        public string AcquirerReference { get; set; }

        /// <summary>
        /// Barcode data for ticket or boleto payment methods, containing
        /// the encoded barcode content.
        /// </summary>
        /// <seealso cref="PaymentBarcode"/>
        public PaymentBarcode Barcode { get; set; }

        /// <summary>
        /// Digitable line (linha digitavel) for boleto payments in Brazil.
        /// This is the numeric representation of the barcode that can be
        /// typed manually for payment.
        /// </summary>
        public string DigitableLine { get; set; }

        /// <summary>
        /// Verification code associated with the transaction, used for
        /// authentication or confirmation purposes.
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// Period (in minutes) during which the payment remains payable
        /// after creation. Applies to deferred payment methods.
        /// </summary>
        public string PayableDeferralPeriod { get; set; }

        /// <summary>
        /// Unique identifier of the bank transfer used to process this payment.
        /// Only present for bank transfer payment methods.
        /// </summary>
        public string BankTransferId { get; set; }

    }
}
