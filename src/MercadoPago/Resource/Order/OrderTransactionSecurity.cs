// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Transaction security information for 3DS.
    /// </summary>
    public class OrderTransactionSecurity
    {
        /// <summary>
        /// URL for the 3DS Challenge.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Validation mode used.
        /// Possible values: "on_fraud_risk", "never".
        /// </summary>
        public string Validation { get; set; }

        /// <summary>
        /// Liability shift configuration.
        /// Possible values: "required".
        /// </summary>
        public string LiabilityShift { get; set; }
    }
}

