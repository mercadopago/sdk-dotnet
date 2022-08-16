namespace MercadoPago.Client.Payment
{
        using MercadoPago.Client.Common;

    /// <summary>
    /// Address information.
    /// </summary>
    public class PaymentPayerAddressRequest : AddressRequest
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