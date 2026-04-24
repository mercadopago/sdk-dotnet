// API version: d0494f1c-8d81-4c76-ae1d-0c65bb8ef6de

namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Represents the payer's phone contact information within a payment order.
    /// </summary>
    /// <seealso cref="OrderPayerRequest"/>
    public class OrderPhoneRequest
    {
        /// <summary>
        /// Phone area code (e.g., "11" for Sao Paulo, "54" for Argentina country code).
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Phone number without the area code.
        /// </summary>
        public string Number { get; set; }
    }

}
