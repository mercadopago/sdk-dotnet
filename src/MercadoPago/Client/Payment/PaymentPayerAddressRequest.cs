namespace MercadoPago.Client.Payment
{
        using MercadoPago.Client.Common;

    /// <summary>
    /// Payer address details for a payment request. Extends <see cref="AddressRequest"/>
    /// with neighborhood, city, and federal unit fields specific to payment payer addresses.
    /// </summary>
    public class PaymentPayerAddressRequest : AddressRequest
    {
        /// <summary>
        /// Neighborhood or district name of the payer's address.
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        /// City name of the payer's address.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Federal unit (state or province) of the payer's address.
        /// </summary>
        public string FederalUnit { get; set; }
    }
}