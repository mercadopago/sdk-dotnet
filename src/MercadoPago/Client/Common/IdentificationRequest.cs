namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Personal identification.
    /// </summary>
    public class IdentificationRequest
    {
        /// <summary>
        /// Identification type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Identification number.
        /// </summary>
        public string Number { get; set; }
    }
}
