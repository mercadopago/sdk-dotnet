namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Security code (CVV/CVC) configuration for a <see cref="CustomerCard"/>.
    /// Describes the expected length and physical location of the code on the
    /// card.
    /// </summary>
    public class CustomerCardSecurityCode
    {
        /// <summary>
        /// Expected number of digits in the security code (typically 3 or 4).
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Physical location of the security code on the card
        /// (e.g. <c>back</c>, <c>front</c>).
        /// </summary>
        public string CardLocation { get; set; }
    }
}
