namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Cardholder information associated with a <see cref="CustomerCard"/>.
    /// Contains the name printed on the card and the holder's identification
    /// document.
    /// </summary>
    public class CustomerCardCardholder
    {
        /// <summary>
        /// Full name of the cardholder as printed on the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Personal identification document of the cardholder.
        /// </summary>
        public CustomerCardCardholderIdentification Identification { get; set; }
    }
}
