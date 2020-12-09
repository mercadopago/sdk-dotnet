namespace MercadoPago.Client.Payment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Passenger info.
    /// </summary>
    public class PaymentPassengerRequest
    {
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Identification.
        /// </summary>
        public IdentificationRequest Identification { get; set; }
    }
}
