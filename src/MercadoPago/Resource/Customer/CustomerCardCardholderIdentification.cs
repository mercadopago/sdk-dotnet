namespace MercadoPago.Resource.Customer
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Identification information.
    /// </summary>
    public class CustomerCardCardholderIdentification : Identification
    {
        /// <summary>
        /// Identification subtype.
        /// </summary>
        public string Subtype { get; set; }
    }
}
