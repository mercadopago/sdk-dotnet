// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a sponsor account within <see cref="OrderIntegrationData"/> that receives a share
    /// of the transaction fees for marketplace or platform integrations.
    /// </summary>
    public class OrderSponsor
    {
        /// <summary>
        /// MercadoPago user identifier of the sponsor account that receives a fee split from this order.
        /// </summary>
        public string Id { get; set; }
    }
}
