// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Sponsoring marketplace owner associated with an order's integration metadata.
    /// </summary>
    /// <seealso cref="OrderIntegrationDataRequest"/>
    public class OrderSponsorRequest
    {
        /// <summary>MercadoPago user ID of the sponsoring marketplace owner. Type: string.</summary>
        public string Id { get; set; }
    }
}
