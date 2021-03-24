namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Security code information.
    /// </summary>
    public class CustomerCardSecurityCode
    {
        /// <summary>
        /// Security code's length.
        /// </summary>
        public int? Length { get; set; }

        /// <summary>
        /// Security code's card location.
        /// </summary>
        public string CardLocation { get; set; }
    }
}
