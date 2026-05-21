namespace MercadoPago.Resource.Payment
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Information about the cardholder associated with the
    /// <see cref="PaymentCard"/> used in a payment, including name
    /// and identification document.
    /// </summary>
    public class PaymentCardholder
    {
        /// <summary>
        /// Full name of the cardholder as printed on the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cardholder's identification document (e.g., CPF, DNI, CURP),
        /// including type and number.
        /// </summary>
        public Identification Identification { get; set; }
    }
}
