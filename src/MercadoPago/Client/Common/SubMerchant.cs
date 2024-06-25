namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Address information.
    /// </summary>
    public class SubMerchant
    {
        /// <summary>
        /// Sub-commercial establishment establishment code
        /// </summary>
        public string SubMerchantId { get; set; }

        /// <summary>
        /// Sub-commerce MCC as determined by Abecs and/or primary CNAE
        /// </summary>
        public string MCC { get; set; }

        /// <summary>
        /// Country in which the sub commerce is located
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Street number where the sub-commerce is located
        /// </summary>
        public string AddressDoorNumber { get; set; }

        /// <summary>
        /// Sub trade name
        /// </summary>
        public string LegalName { get; set; }

        /// <summary>
        /// State where the sub commerce is located
        /// </summary>
        public string RegionCodeIso { get; set; }

        /// <summary>
        /// ISO code of the sub-commerce region (“BR”)
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// Sub-commerce CPF or CNPJ number
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Sub-commerce telephone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Payment Facilitator URL
        /// </summary>
        public string Url { get; set; }
    }
}