namespace MercadoPago.Client.Common
{
    /// <summary>
    /// Contains network-level transaction identifiers returned by card payment networks.
    /// This data is typically used for reconciliation or when referencing a prior transaction
    /// in subsequent operations (e.g., recurring payments or refunds).
    /// </summary>
    public class NetworkTransactionData
    {
        /// <summary>
        /// Transaction identifier assigned by the card network (e.g., Visa, Mastercard)
        /// for the original payment, used to link follow-up transactions to the initial one.
        /// </summary>
        public string NetworkTransactionId { get; set; }
    }
}
