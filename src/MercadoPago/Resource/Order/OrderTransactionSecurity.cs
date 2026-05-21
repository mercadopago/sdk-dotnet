// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents 3-D Secure (3DS) transaction security data within an <see cref="OrderPaymentMethod"/>,
    /// used for cardholder authentication and fraud prevention.
    /// </summary>
    public class OrderTransactionSecurity
    {
        /// <summary>
        /// Unique identifier of the 3DS authentication session.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// URL where the payer is redirected to complete the 3DS challenge authentication step.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Validation mode that determines when 3DS authentication is triggered.
        /// Possible values: "on_fraud_risk", "never".
        /// </summary>
        public string Validation { get; set; }

        /// <summary>
        /// Liability shift configuration that determines whether the transaction requires a liability shift to the issuer.
        /// Possible values: "required".
        /// </summary>
        public string LiabilityShift { get; set; }
    }
}

