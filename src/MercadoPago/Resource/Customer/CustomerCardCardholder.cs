namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Cardholder information.
    /// </summary>
    public class CustomerCardCardholder
    {
        /// <summary>
        /// Cardholder name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identification information.
        /// </summary>
        public CustomerCardCardholderIdentification Identification { get; set; }
    }
}
