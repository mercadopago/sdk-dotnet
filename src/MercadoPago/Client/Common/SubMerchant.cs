namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Data Transfer Object representing a sub-merchant (sub-commerce) in a payment facilitator model.
    /// Payment facilitators use this to identify the actual seller in transactions processed
    /// on behalf of sub-merchants through the MercadoPago API.
    /// </summary>
    public class SubMerchant
    {
        /// <summary>
        /// Unique establishment code assigned to the sub-merchant by the payment facilitator.
        /// </summary>
        public string SubMerchantId { get; set; }

        /// <summary>
        /// Merchant Category Code (MCC) of the sub-merchant, as determined by ABECS
        /// and/or the primary CNAE classification code.
        /// </summary>
        public string Mcc { get; set; }

        /// <summary>
        /// ISO 3166-1 alpha-2 country code where the sub-merchant is located (e.g., <c>”BR”</c>).
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Street name of the sub-merchant's physical address.
        /// </summary>
        public string AddressStreet { get; set; }

        /// <summary>
        /// Door or building number of the sub-merchant's street address.
        /// </summary>
        public int AddressDoorNumber { get; set; }

        /// <summary>
        /// Registered legal or trade name of the sub-merchant.
        /// </summary>
        public string LegalName { get; set; }

        /// <summary>
        /// City where the sub-merchant is located.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ISO 3166-2 region/state code of the sub-merchant's location (e.g., <c>”BR-SP”</c>).
        /// </summary>
        public string RegionCodeIso { get; set; }

        /// <summary>
        /// Short region or state code of the sub-merchant (e.g., <c>”SP”</c> for Sao Paulo).
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// Type of the sub-merchant's tax identification document (e.g., <c>”CPF”</c> or <c>”CNPJ”</c>).
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Tax identification number of the sub-merchant (CPF or CNPJ value).
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Contact telephone number of the sub-merchant.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Postal / ZIP code of the sub-merchant's address.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Website URL of the payment facilitator or sub-merchant.
        /// </summary>
        public string Url { get; set; }
    }
}