using System;

namespace MercadoPago.DataStructures.AdvancedPayment
{
    /// <summary>
    /// Payment data
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Payment identification
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Status details
        /// </summary>
        public string StatusDetails { get; set; }

        /// <summary>
        /// Payment method type
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Payment method
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method option ID
        /// </summary>
        public string PaymentMethodOptionId { get; set; }

        /// <summary>
        /// Card token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Number of installments selected
        /// </summary>
        public int Installments { get; set; }

        /// <summary>
        /// Processing mode
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Payment method issuer identifier
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Payment reason
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Determines if the payment should be captured (true) or only reserved (false)
        /// </summary>
        public bool? Capture { get; set; }

        /// <summary>
        /// Identification in seller system
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// How the payment will appear on your card statement
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Due date for the "ticket" payment method
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Transaction details
        /// </summary>
        public TransactionDetails TransactionDetails { get; set; }
    }
}
