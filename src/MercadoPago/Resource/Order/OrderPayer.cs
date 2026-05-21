// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the payer associated with an <see cref="Order"/>, identifying who is responsible for the payment.
    /// </summary>
    public class OrderPayer
    {
        /// <summary>
        /// MercadoPago customer identifier for the payer, used to retrieve saved cards and payment preferences.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Legal entity type of the payer (e.g., "individual" for a person, "association" for a business entity).
        /// </summary>
        public string EntityType { get; set; }
    }
}
