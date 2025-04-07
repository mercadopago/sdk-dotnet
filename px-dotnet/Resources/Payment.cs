﻿using MercadoPago.DataStructures.Payment;
using MercadoPago.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json.Converters;

namespace MercadoPago.Resources
{

    /// <summary>
    /// This class provides the methods to access the API that will allow you to create your own payment experience on your website.
    /// From basic to advanced configurations, you control the whole experience.
    /// </summary>
    public class Payment : MPBase
    {
        #region Actions

        /// <summary>
        /// Load payment by your ID.
        /// </summary>
        /// <param name="id">Payment ID.</param>
        /// <returns>The payment.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_id/get/">here</a>.
        /// </remarks>
        public Payment Load(string id)
        {
            return FindById(long.Parse(id), WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Finds the payment by your ID.
        /// </summary>
        /// <param name="id">Payment ID.</param>
        /// <returns>The payment.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_id/get/">here</a>.
        /// </remarks>
        public static Payment FindById(long? id)
        {
            return FindById(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Finds the payment by your ID.
        /// </summary>
        /// <param name="id">Payment ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The payment.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_id/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/v1/payments/:id")]
        public static Payment FindById(long? id, bool useCache, MPRequestOptions requestOptions)
        {
            return (Payment)ProcessMethod<Payment>(typeof(Payment), "FindById", id.ToString(), useCache, requestOptions);
        }

        /// <summary>
        /// Saves a new payment.
        /// </summary>
        /// <returns><c>true</c> if the payment was saved, otherwise <c>false</c>.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments/post/">here</a>.
        /// </remarks>
        public Boolean Save()
        {
            return ProcessMethodBool<Payment>("Save", WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Saves a new payment.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns><c>true</c> if the payment was saved, otherwise <c>false</c>.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments/post/">here</a>.
        /// </remarks>
        [POSTEndpoint("/v1/payments")]
        public Boolean Save(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Payment>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Updates the payment editable properties.
        /// </summary>
        /// <returns><c>true</c> if the payment was updated, otherwise <c>false</c>.</returns>
        public Boolean Update()
        {
            return ProcessMethodBool<Payment>("Update", WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Updates the payment editable properties.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns><c>true</c> if the payment was updated, otherwise <c>false</c>.</returns>
        [PUTEndpoint("/v1/payments/:id")]
        public Boolean Update(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Payment>("Update", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Get all payments.
        /// </summary>
        /// <returns>A list of payments.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_search/get/">here</a>.
        /// </remarks>
        public static List<Payment> All()
        {
            return All(WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Search the payments.
        /// </summary>
        /// <param name="filters">Search filters.</param>
        /// <returns>A list of payments.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_search/get/">here</a>.
        /// </remarks>
        public static List<Payment> Search(Dictionary<string, string> filters)
        {
            return Search(filters, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Get all payments
        /// </summary>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>A list of payments.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_search/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/v1/payments/search")]
        public static List<Payment> All(bool useCache, MPRequestOptions requestOptions)
        {
            return (List<Payment>)ProcessMethodBulk<Payment>(typeof(Payment), "Search", useCache, requestOptions);
        }

        /// <summary>
        /// Search the payments.
        /// </summary>
        /// <param name="filters">Search filters.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>A list of payments.</returns>
        /// <remarks>
        /// Check the API documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference/payments/_payments_search/get/">here</a>.
        /// </remarks>
        [GETEndpoint("/v1/payments/search")]
        public static List<Payment> Search(Dictionary<string, string> filters, bool useCache, MPRequestOptions requestOptions)
        {
            return (List<Payment>)ProcessMethodBulk<Payment>(typeof(Payment), "Search", filters, useCache, requestOptions);
        }
        #endregion

        #region Interactions
        /// <summary>
        /// Refunds a payment.
        /// </summary>
        /// <returns>The refunded payment.</returns>
        public Payment Refund()
        {
            return Refund(null, null);
        }

        /// <summary>
        /// Refunds a payment.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The refunded payment.</returns>
        public Payment Refund(MPRequestOptions requestOptions)
        {
            return Refund(null, requestOptions);
        }

        /// <summary>
        /// Refunds a payment.
        /// </summary>
        /// <param name="amount">Amount to be refunded.</param>
        /// <returns>The refunded payment.</returns>
        public Payment Refund(decimal amount)
        {
            return Refund(amount, null);
        }

        /// <summary>
        /// Refunds a payment.
        /// </summary>
        /// <param name="amount">Amount to be refunded.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The refunded payment.</returns>
        public Payment Refund(decimal? amount, MPRequestOptions requestOptions)
        {
            Refund refund = new Refund();
            refund.manualSetPaymentId((decimal)Id);
            refund.Amount = amount;
            refund.Save(requestOptions);

            if (refund.Id.HasValue)
            {
                Thread.Sleep(500);
                var payment = Payment.FindById(Id, WITHOUT_CACHE, requestOptions);
                Status = payment.Status;
                StatusDetail = payment.StatusDetail;
                TransactionAmountRefunded = payment.TransactionAmountRefunded;
                Refunds = payment.Refunds;
            }
            else
            {
                _errors = refund.Errors;
            }

            return this;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Payment identifier
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Payment’s creation date
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Payment’s approval date
        /// </summary>
        public DateTime? DateApproved { get; set; }

        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Release date of payment
        /// </summary>
        public DateTime? MoneyReleaseDate { get; set; }

        /// <summary>
        /// Identifies the seller
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Payment type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationType? OperationType { get; set; }

        /// <summary>
        /// Identifies the buyer  
        /// </summary>
        public Payer Payer { get; set; }

        /// <summary>
        /// When set to true, the payment can only be approved or rejected. 
        /// Otherwise in_process status is added
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Whether the payment will be processed in sandbox or in production mode
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// Order identifier
        /// </summary>
        public Order? Order { get; set; }

        /// <summary>
        /// ID given by the merchant in their system
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Payment reason or item title
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Valid JSON that can be attached to the payment to record additional attributes of the merchant
        /// </summary>
        public JObject Metadata { get; set; }

        /// <summary>
        /// ID of the currency used in the payment
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyId? CurrencyId { get; set; }

        /// <summary>
        /// Product cost
        /// </summary>
        public float? TransactionAmount { get; set; }

        /// <summary>
        /// Product net
        /// </summary>
        public float? NetAmount { get; set; }

        /// <summary>
        /// Total refunded amount in this payment
        /// </summary>
        public float? TransactionAmountRefunded { get; set; }

        /// <summary>
        /// Amount of the coupon discount
        /// </summary>
        public float? CouponAmount { get; set; }

        /// <summary>
        /// Discount campaign ID
        /// </summary>
        public long? CampaignId { get; set; }

        /// <summary>
        /// Discount campaign with a specific code
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// Groups the details of the transaction
        /// </summary>
        public TransactionDetail? TransactionDetails { get; set; }

        /// <summary>
        /// List of fees
        /// </summary>
        public List<FeeDetail> FeeDetails { get; set; }

        /// <summary>
        /// Id of the scheme for the absorption of financing fee
        /// </summary>
        public long? DifferentialPricingId { get; set; }

        /// <summary>
        /// Fee collected by a marketplace or MercadoPago Application
        /// </summary>
        public float? ApplicationFee { get; set; }

        /// <summary>
        /// Payment status
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus? Status { get; set; }

        /// <summary>
        /// Gives more detailed information on the current state or rejection cause
        /// </summary>
        public string StatusDetail { get; set; }

        /// <summary>
        /// Gives more detailed information on the current state or rejection cause
        /// </summary>
        public bool? Capture { get; set; }

        /// <summary>
        /// Gives more detailed information on the current state or rejection cause
        /// </summary>
        public bool? Captured { get; set; }

        /// <summary>
        /// Gives more detailed information on the current state or rejection cause
        /// </summary>
        public string CallForAuthorizeId { get; set; }

        /// <summary>
        /// Gives more detailed information on the current state or rejection cause
        /// </summary>
        public string PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method issuer
        /// </summary>
        public string IssuerId { get; set; }

        /// <summary>
        /// Type of payment method chosen
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentTypeId? PaymentTypeId { get; set; }

        /// <summary>
        /// Card token ID
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Details of the card used
        /// </summary>
        public DataStructures.Payment.Card? Card { get; set; }

        /// <summary>
        /// How will look the payment in the card bill (e.g.: MERCADOPAGO)
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// Selected quantity of installments
        /// </summary>
        public long? Installments { get; set; }

        /// <summary>
        /// URL where mercadopago will send notifications associated to changes in this payment
        /// </summary>
        public string NotificationUrl { get; set; }

        /// <summary>
        /// URL where mercadopago does the final redirect (only for bank transfers)
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// List of refunds that were made to this payment
        /// </summary>
        public List<Refund> Refunds { get; set; }

        /// <summary>
        /// Data that could improve fraud analysis and conversion rates. 
        /// Try to send as much information as possible.
        /// </summary>
        public AdditionalInfo? AdditionalInfo { get; set; }

        /// <summary>
        /// Processing mode to define if an specific merchannt id should be used.
        /// </summary>
        public string ProcessingMode { get; set; }

        /// <summary>
        /// Merchant Id for complex payment cases
        /// </summary>
        public string MerchantAccountId { get; set; }

        /// <summary>
        /// Date of expiration
        /// </summary>
        public DateTime? DateOfExpiration { get; set; }

        /// <summary>
        /// Sponsor Identification
        /// </summary>
        public long? SponsorId { get; set; }

        /// <summary>
        /// Taxes for payments
        /// </summary>
        public List<Taxes> Taxes { get; set; }

        /// <summary>
        /// Payment method option.
        /// </summary>
        public string PaymentMethodOptionId { get; set; }

        /// <summary>
        /// Merchant services
        /// </summary>
        public MerchantServices MerchantServices { get; set; }

        /// <summary>
        /// Point of interaction
        /// </summary>
        public PointOfInteraction PointOfInteraction { get; set; }

        /// <summary>
        /// Integrator ID
        /// </summary>
        public string IntegratorId { get; set; }

        /// <summary>
        /// Platform ID
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// Corporation ID
        /// </summary>
        public string CorporationId { get; set; }
        #endregion

    }
}
