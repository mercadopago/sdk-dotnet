namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Identification class.
    /// </summary>
    public class OrderIdentificationRequest
    {
        /// <summary>
        /// Type of identification.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Unique number of that identification.
        /// </summary>
        public string Number { get; set; }
    }

}