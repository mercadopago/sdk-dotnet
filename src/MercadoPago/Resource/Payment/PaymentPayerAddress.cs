namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Resource.Common;
    
     /// <summary>
    /// Payer's address information.
    /// </summary>
    public class PaymentPayerAddress : Address
    {
        /// <summary>
        /// Neighborhood.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Federal unity.
        /// </summary>
        public string FederalUnit { get; set; }
    }
}