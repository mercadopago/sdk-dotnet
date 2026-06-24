// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a free shipping method available to the payer.
    /// </summary>
    /// <seealso cref="OrderShipment"/>
    public class OrderFreeMethod
    {
        /// <summary>
        /// Identifier of the free shipping method.
        /// </summary>
        public int? Id { get; set; }
    }
}
