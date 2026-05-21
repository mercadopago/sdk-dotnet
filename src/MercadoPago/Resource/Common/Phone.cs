namespace MercadoPago.Resource.Common
{
    /// <summary>
    /// Phone contact information used across several MercadoPago API responses
    /// (customers, payments, preferences, etc.).
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Phone area code (e.g. <c>11</c> for Sao Paulo, <c>54</c> for Buenos Aires).
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Local phone number without the area code.
        /// </summary>
        public string Number { get; set; }
    }
}
