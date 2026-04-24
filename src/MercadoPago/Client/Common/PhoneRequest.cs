namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Reusable phone contact DTO used across payment payer information and customer profiles.
    /// </summary>
    public class PhoneRequest
    {
        /// <summary>
        /// Telephone area code (e.g., <c>"11"</c> for Sao Paulo, <c>"21"</c> for Rio de Janeiro).
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// Local phone number without the area code (e.g., <c>"987654321"</c>).
        /// </summary>
        public string Number { get; set; }
    }
}
