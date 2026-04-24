// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Configuration for 3-D Secure (3DS) authentication on payment transactions.
    /// Controls when cardholder verification is triggered and how liability is shifted.
    /// </summary>
    /// <seealso cref="OrderOnlineConfigRequest"/>
    public class OrderTransactionSecurityRequest
    {
        /// <summary>
        /// Defines when 3-D Secure validation is executed.
        /// Possible values: "on_fraud_risk" (only when fraud risk is detected), "never" (disabled).
        /// </summary>
        public string Validation { get; set; }

        /// <summary>
        /// Defines the liability shift requirement for 3-D Secure transactions.
        /// Possible values: "required" (the transaction is declined if liability shift cannot be obtained).
        /// </summary>
        public string LiabilityShift { get; set; }
    }
}

