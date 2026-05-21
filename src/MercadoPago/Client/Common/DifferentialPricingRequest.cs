namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Request DTO for associating a differential pricing configuration with a payment preference.
    /// Differential pricing allows sellers to offer different prices or installment plans
    /// to specific buyer segments.
    /// </summary>
    public class DifferentialPricingRequest
    {
        /// <summary>
        /// Unique identifier of a previously created differential pricing configuration
        /// in MercadoPago. When set, the associated pricing rules are applied to the payment.
        /// </summary>
        public long? Id { get; set; }
    }
}
