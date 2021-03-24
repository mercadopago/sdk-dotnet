namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Phone information.
    /// </summary>
    public class PhoneRequest
    {
        /// <summary>
        /// Area code.
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        public string Number { get; set; }
    }
}
