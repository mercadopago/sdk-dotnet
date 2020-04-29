using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MercadoPago.Resources
{
    /// <summary>
    /// Payment for the seller
    /// </summary>
    public class Disbursement : MPBase
    {
        /// <summary>
        /// Identification
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Identification in seller system
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Seller identification
        /// </summary>
        public long? CollectorId { get; set; }

        /// <summary>
        /// Collected fee
        /// </summary>
        public decimal? ApplicationFee { get; set; }

        /// <summary>
        /// Number of days (from the payment approval date) that the payment will be released to the seller
        /// </summary>
        public int? MoneyReleaseDays { get; set; }

        /// <summary>
        /// Money release date (internal use only)
        /// </summary>
        [JsonProperty]
        internal DateTime? MoneyReleaseDate { get; set; }

        /// <summary>
        /// Update money release date for the sellers
        /// </summary>
        /// <param name="advancedPaymentId">Advanced payment ID</param>
        /// <param name="disbursementId">Disbursement ID</param>
        /// <param name="releaseDate">Release date</param>
        /// <param name="requestOptions">Request options</param>
        /// <returns><see langword="true"/> if updated with success, otherwise <see langword="false"/></returns>
        [POSTEndpoint("/v1/advanced_payments/:advanced_payment_id/disbursements/:disbursement_id/disburses")]
        internal static bool UpdateReleaseDate(long advancedPaymentId, long disbursementId, DateTime releaseDate, MPRequestOptions requestOptions)
        {
            var pathParams = new Dictionary<string, string>();
            pathParams.Add("advanced_payment_id", advancedPaymentId.ToString());
            pathParams.Add("disbursement_id", disbursementId.ToString());

            var disbursement = new Disbursement
            {
                MoneyReleaseDate = releaseDate
            };
            return disbursement.ProcessMethodBool<Disbursement>("UpdateReleaseDate", WITHOUT_CACHE, pathParams, requestOptions);
        }
    }
}
