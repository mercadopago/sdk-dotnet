// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Identification class.
    /// </summary>
    public class OrderIdentificationRequest
    {
        /// <summary>
        /// Type of identification.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique number of that identification.
        /// </summary>
        public string Number { get; set; }
    }

}
