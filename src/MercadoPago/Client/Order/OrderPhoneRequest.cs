// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Phone class.
    /// </summary>
    public class OrderPhoneRequest
    {
        /// <summary>
        /// Area Code.
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string Number { get; set; }
    }

}
