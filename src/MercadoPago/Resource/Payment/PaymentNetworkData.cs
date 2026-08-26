namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Card-network identifiers returned in the point of interaction for a
    /// credential-on-file payment.
    /// </summary>
    public class PaymentNetworkData
    {
        /// <summary>
        /// Identifier assigned to the transaction by the card network.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Identifier that links related transactions in the card network.
        /// </summary>
        public string TransactionLinkId { get; set; }
    }
}
