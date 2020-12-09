namespace MercadoPago.Client.AdvancedPayment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// One of the payments made by the payer.
    /// </summary>
    public class AdvancedPaymentSplitPaymentRequest
    {
        /// <summary>
        /// Payment reason or item title.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID given by the merchant in their system.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// How will look the payment in the card bill.
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Payment type.
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Payment method chosen to do the payment.
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method option id.
        /// </summary>
        public string PaymentMethodOptionId { get; set; }

        /// <summary>
        /// Processing mode to define if an specific merchant id should be used.
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Payment method issuer.
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Card token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Amount paid.
        /// </summary>
        public decimal? TransactionAmount { get; set; }

        /// <summary>
        /// Payment net amount.
        /// </summary>
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// Selected quantity of installments
        /// </summary>
        public int? Installments { get; set; }

        /// <summary>
        /// Date of expiration.
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Amount of the coupon.
        /// </summary>
        public decimal? CouponAmount { get; set; }

        /// <summary>
        /// Discount campaign ID.
        /// </summary>
        public int? CampaignId { get; set; }

        /// <summary>
        /// Discount campaign coupon code.
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// Merchant Id for complex payment cases.
        /// </summary>
        public string MerchantAccountId { get; set; }

        /// <summary>
        /// Transaction details.
        /// </summary>
        public AdvancedPaymentTransactionDetailsRequest TransactionDetails { get; set; }

        /// <summary>
        /// Taxes for payments.
        /// </summary>
        public IList<AdvancedPaymentTaxRequest> Taxes { get; set; }
    }
}
