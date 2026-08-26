namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Card-network identifiers sent in the point of interaction for a
    /// credential-on-file payment.
    /// </summary>
    public class PaymentNetworkDataRequest
    {
        /// <summary>
        /// Identifier assigned to the transaction by the card network.
        /// </summary>
        public string NetworkTransactionId { get; set; }

        /// <summary>
        /// Identifier that links related transactions in the card network.
        /// </summary>
        public string TransactionLinkId { get; set; }
    }
}
