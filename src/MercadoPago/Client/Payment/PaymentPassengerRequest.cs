namespace MercadoPago.Client.Payment
{
    using MercadoPago.Client.Common;

    /// <summary>
    /// Passenger information for a travel-related <see cref="PaymentCategoryDescriptorRequest"/>.
    /// Contains the passenger's identity details for airline ticket or travel purchases.
    /// </summary>
    public class PaymentPassengerRequest
    {
        /// <summary>
        /// Passenger's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Passenger's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Passenger's identification document (e.g., passport, national ID).
        /// </summary>
        /// <seealso cref="IdentificationRequest"/>
        public IdentificationRequest Identification { get; set; }
    }
}
