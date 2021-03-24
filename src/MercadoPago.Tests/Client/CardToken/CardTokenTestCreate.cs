namespace MercadoPago.Tests.Client.CardToken
{
    /// <summary>
    /// Card with data to create a test card token.
    /// </summary>
    public class CardTokenTestCreate
    {
        /// <summary>
        /// Test card number.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Test security code.
        /// </summary>
        public string SecurityCode { get; set; }

        /// <summary>
        /// Test expiration month.
        /// </summary>
        public int? ExpirationMonth { get; set; }

        /// <summary>
        /// Test expiration year.
        /// </summary>
        public int? ExpirationYear { get; set; }

        /// <summary>
        /// Test cardholder.
        /// </summary>
        public CardTokenCardholderTestCreate Cardholder { get; set; }
    }
}
