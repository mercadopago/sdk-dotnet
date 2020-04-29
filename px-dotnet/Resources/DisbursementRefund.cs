using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercadoPago.Resources
{
    /// <summary>
    /// Refund a disbursement
    /// </summary>
    public class DisbursementRefund : MPBase
    {
        /// <summary>
        /// Refund ID
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Disbursement ID
        /// </summary>
        [JsonProperty("payment_id")]
        public long? DisbursementId { get; set; }

        /// <summary>
        /// Refund amount
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Refund status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Creation date of refund
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Create disbursement refunds
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>Created disbursement refund</returns>
        [POSTEndpoint("/v1/advanced_payments/:advanced_payment_id/refunds")]
        internal static List<DisbursementRefund> CreateAll(long advancedPaymentId, MPRequestOptions requestOptions)
        {
            var pathParams = new Dictionary<string, string>();
            pathParams.Add("advanced_payment_id", advancedPaymentId.ToString());

            return ProcessMethodBulk<DisbursementRefund>(typeof(DisbursementRefund), "CreateAll", pathParams, WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Create a disbursement refund
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <param name="amount">Refund amount</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns>Created disbursement refund</returns>
        [POSTEndpoint("/v1/advanced_payments/:advanced_payment_id/disbursements/:disbursement_id/refunds")]
        internal static DisbursementRefund Create(long advancedPaymentId, long disbursementId, decimal? amount, MPRequestOptions requestOptions)
        {
            var pathParams = new Dictionary<string, string>();
            pathParams.Add("advanced_payment_id", advancedPaymentId.ToString());
            pathParams.Add("disbursement_id", disbursementId.ToString());

            var disbursementRefund = new DisbursementRefund
            {
                Amount = amount
            };

            return ProcessMethod(typeof(DisbursementRefund), disbursementRefund, "Create", pathParams, WITHOUT_CACHE, requestOptions);
        }
    }
}
