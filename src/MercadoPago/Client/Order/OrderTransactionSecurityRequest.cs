// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Transaction security configuration class for 3DS.
    /// </summary>
    public class OrderTransactionSecurityRequest
    {
        /// <summary>
        /// Defines when 3DS validation should be executed.
        /// Possible values: "on_fraud_risk", "never".
        /// </summary>
        public string Validation { get; set; }

        /// <summary>
        /// Defines the liability shift configuration.
        /// Possible values: "required".
        /// </summary>
        public string LiabilityShift { get; set; }
    }
}

