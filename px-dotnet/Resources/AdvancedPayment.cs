using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using AdvPay = MercadoPago.DataStructures.AdvancedPayment;

namespace MercadoPago.Resources
{
    /// <summary>
    /// Provides a solution for Marketplace payments where the business model requires splitting money between multiple sellers
    /// </summary>
    public class AdvancedPayment : MPBase
    {
        /// <summary>
        /// Identification
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date of last update
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Payer info
        /// </summary>
        public AdvPay.Payer Payer { get; set; }

        /// <summary>
        /// Payments made by the payer
        /// </summary>
        public List<AdvPay.Payment> Payments { get; set; }

        /// <summary>
        /// Payments for the seller
        /// </summary>
        public List<Disbursement> Disbursements { get; set; }

        /// <summary>
        /// Indicates whether the payment can be pending (false) or can only be approved or rejected (true)
        /// </summary>
        public bool? BinaryMode { get; set; }

        /// <summary>
        /// Marketplace identification
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Indicates whether the payment was captured (true )or not (false)
        /// </summary>
        public bool? Capture { get; set; }

        /// <summary>
        /// Identification in seller system
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Advanced payment reason
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Information that can improve fraud prevention analysis and conversion rate
        /// </summary>
        public AdvPay.AdditionalInfo AdditionalInfo { get; set; }

        /// <summary>
        /// Metadata info
        /// </summary>
        public JObject Metadata { get; set; }

        /// <summary>
        /// Money release date (internal use only)
        /// </summary>
        [JsonProperty]
        internal DateTime? MoneyReleaseDate { get; set; }

        /// <summary>
        /// Save advanced payment data
        /// </summary>
        /// <returns><see langword="true"/> if saved with success, otherwise <see langword="false"/></returns>
        public bool Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Save advanced payment data
        /// </summary>
        /// <param name="requestOptions">Request options</param>
        /// <returns><see langword="true"/> if saved with success, otherwise <see langword="false"/></returns>
        [POSTEndpoint("/v1/advanced_payments")]
        public bool Save(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<AdvancedPayment>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Cancels a pending advanced payment
        /// </summary>
        /// <param name="id">Advanced payment ID</param>
        /// <returns><see langword="true"/> if cancelled with success, otherwise <see langword="false"/></returns>
        public static bool Cancel(long id)
        {
            return Cancel(id, null);
        }

        /// <summary>
        /// Cancels a pending advanced payment
        /// </summary>
        /// <param name="id">Advanced payment ID</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns><see langword="true"/> if cancelled with success, otherwise <see langword="false"/></returns>
        [PUTEndpoint("/v1/advanced_payments/:id")]
        public static bool Cancel(long id, MPRequestOptions requestOptions)
        {
            var pathParams = new Dictionary<string, string>();
            pathParams.Add("id", id.ToString());

            var advancedPayment = new AdvancedPayment
            {
                Status = "cancelled"
            };
            return advancedPayment.ProcessMethodBool<AdvancedPayment>("Cancel", WITHOUT_CACHE, pathParams, requestOptions);
        }

        /// <summary>
        /// Capture the advanced payment
        /// </summary>
        /// <param name="id">Advanced payment ID</param>
        /// <returns><see langword="true"/> if captured with success, otherwise <see langword="false"/></returns>
        [PUTEndpoint("/v1/advanced_payments/:id")]
        public static bool DoCapture(long id)
        {
            return DoCapture(id, null);
        }

        /// <summary>
        /// Capture the advanced payment
        /// </summary>
        /// <param name="id">Advanced payment ID</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns><see langword="true"/> if captured with success, otherwise <see langword="false"/></returns>
        [PUTEndpoint("/v1/advanced_payments/:id")]
        public static bool DoCapture(long id, MPRequestOptions requestOptions)
        {
            var pathParams = new Dictionary<string, string>();
            pathParams.Add("id", id.ToString());

            var advancedPayment = new AdvancedPayment
            {
                Capture = true
            };
            return advancedPayment.ProcessMethodBool<AdvancedPayment>("DoCapture", WITHOUT_CACHE, pathParams, requestOptions);
        }

        /// <summary>
        /// Update money release date for the sellers
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="releaseDate">Release date</param>
        /// <returns><see langword="true"/> if updated with success, otherwise <see langword="false"/></returns>
        public static bool UpdateReleaseDate(long advancedPaymentId, DateTime releaseDate)
        {
            return UpdateReleaseDate(advancedPaymentId, releaseDate, null);
        }

        /// <summary>
        /// Update money release date for the sellers
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="releaseDate">Release date</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns><see langword="true"/> if updated with success, otherwise <see langword="false"/></returns>
        [POSTEndpoint("/v1/advanced_payments/:advanced_payment_id/disburses")]
        public static bool UpdateReleaseDate(long advancedPaymentId, DateTime releaseDate, MPRequestOptions requestOptions)
        {
            var pathParams = new Dictionary<string, string>();
            pathParams.Add("advanced_payment_id", advancedPaymentId.ToString());

            var advancedPayment = new AdvancedPayment
            {
                MoneyReleaseDate = releaseDate
            };
            return advancedPayment.ProcessMethodBool<AdvancedPayment>("UpdateReleaseDate", WITHOUT_CACHE, pathParams, requestOptions);
        }

        /// <summary>
        /// Update money release date for the sellers
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <param name="releaseDate">Release date</param>
        /// <returns><see langword="true"/> if updated with success, otherwise <see langword="false"/></returns>
        public static bool UpdateReleaseDate(long advancedPaymentId, long disbursementId, DateTime releaseDate)
        {
            return UpdateReleaseDate(advancedPaymentId, disbursementId, releaseDate, null);
        }

        /// <summary>
        /// Update money release date for the sellers
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <param name="releaseDate">Release date</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns><see langword="true"/> if updated with success, otherwise <see langword="false"/></returns>
        public static bool UpdateReleaseDate(long advancedPaymentId, long disbursementId, DateTime releaseDate, MPRequestOptions requestOptions)
        {
            return Disbursement.UpdateReleaseDate(advancedPaymentId, disbursementId, releaseDate, requestOptions);
        }

        /// <summary>
        /// Refund all advanced payment disbursements
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <returns>A list with all disbursement refunds</returns>
        public static List<DisbursementRefund> RefundAll(long advancedPaymentId)
        {
            return RefundAll(advancedPaymentId, null);
        }

        /// <summary>
        /// Refund all advanced payment disbursements
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>A list with all disbursement refunds</returns>
        [POSTEndpoint("/v1/advanced_payments/:advanced_payment_id/refunds")]
        public static List<DisbursementRefund> RefundAll(long advancedPaymentId, MPRequestOptions requestOptions)
        {
            return DisbursementRefund.CreateAll(advancedPaymentId, requestOptions);
        }

        /// <summary>
        /// Refund a disbursement
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <returns>Disbursement refund data</returns>
        public static DisbursementRefund Refund(long advancedPaymentId, long disbursementId)
        {
            return Refund(advancedPaymentId, disbursementId, null, null);
        }

        /// <summary>
        /// Refund a disbursement
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>Disbursement refund data</returns>
        public static DisbursementRefund Refund(long advancedPaymentId, long disbursementId, MPRequestOptions requestOptions)
        {
            return Refund(advancedPaymentId, disbursementId, null, requestOptions);
        }

        /// <summary>
        /// Refund a disbursement
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <param name="amount">Amount to refund</param>
        /// <returns>Disbursement refund data</returns>
        public static DisbursementRefund Refund(long advancedPaymentId, long disbursementId, decimal? amount)
        {
            return Refund(advancedPaymentId, disbursementId, amount, null);
        }

        /// <summary>
        /// Refund a disbursement
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <param name="amount">Amount to refund</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>Disbursement refund data</returns>
        [POSTEndpoint("/v1/advanced_payments/:advanced_payment_id/disbursements/:payment_id/refunds")]
        public static DisbursementRefund Refund(long advancedPaymentId, long disbursementId, decimal? amount, MPRequestOptions requestOptions)
        {
            return DisbursementRefund.Create(advancedPaymentId, disbursementId, amount, requestOptions);
        }

        /// <summary>
        /// Find advanced payment by ID
        /// </summary>
        /// <param name="id">Advanced payment ID</param>
        /// <returns>Advanced payment with ID equals to <paramref name="id"/></returns>
        [GETEndpoint("/v1/advanced_payments/:id")]
        public static AdvancedPayment FindById(long? id)
        {
            return FindById(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Find advanced payment by ID
        /// </summary>
        /// <param name="id">Advanced payment ID</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>Advanced payment with ID equals to <paramref name="id"/></returns>
        [GETEndpoint("/v1/advanced_payments/:id")]
        public static AdvancedPayment FindById(long? id, MPRequestOptions requestOptions)
        {
            return FindById(id, WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Find advanced payment by ID
        /// </summary>
        /// <param name="id">Advanced payment ID</param>
        /// <param name="useCache">Use cache or not</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>Advanced payment with ID equals to <paramref name="id"/></returns>
        [GETEndpoint("/v1/advanced_payments/:id")]
        public static AdvancedPayment FindById(long? id, bool useCache, MPRequestOptions requestOptions)
        {
            return (AdvancedPayment)ProcessMethod<AdvancedPayment>(typeof(AdvancedPayment), "FindById", id.ToString(), useCache, requestOptions);
        }

        /// <summary>
        /// Get all advanced payments
        /// </summary>
        /// <returns>List of advanced payments</returns>
        public static List<AdvancedPayment> All()
        {
            return All(WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Get all advanced payments
        /// </summary>
        /// <param name="requestOptions">Request options</param>
        /// <returns>List of advanced payments</returns>
        public static List<AdvancedPayment> All(MPRequestOptions requestOptions)
        {
            return All(WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Get all advanced payments
        /// </summary>
        /// <param name="useCache">Use cache or not</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>List of advanced payments</returns>
        [GETEndpoint("/v1/advanced_payments/search")]
        public static List<AdvancedPayment> All(bool useCache, MPRequestOptions requestOptions)
        {
            return ProcessMethodBulk<AdvancedPayment>(typeof(AdvancedPayment), "Search", useCache, requestOptions);
        }

        /// <summary>
        /// Search advanced payments
        /// </summary>
        /// <param name="filters">Search filters</param>
        /// <returns>List of advanced payments</returns>
        public static List<AdvancedPayment> Search(Dictionary<string, string> filters)
        {
            return Search(filters, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Search advanced payments
        /// </summary>
        /// <param name="filters">Search filters</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>List of advanced payments</returns>
        public static List<AdvancedPayment> Search(Dictionary<string, string> filters, MPRequestOptions requestOptions)
        {
            return Search(filters, WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Search advanced payments
        /// </summary>
        /// <param name="filters">Search filters</param>
        /// <param name="useCache">Use cache or not</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>List of advanced payments</returns>
        [GETEndpoint("/v1/advanced_payments/search")]
        public static List<AdvancedPayment> Search(Dictionary<string, string> filters, bool useCache, MPRequestOptions requestOptions)
        {
            return ProcessMethodBulk<AdvancedPayment>(typeof(AdvancedPayment), "Search", filters, useCache, requestOptions);
        }
    }
}
