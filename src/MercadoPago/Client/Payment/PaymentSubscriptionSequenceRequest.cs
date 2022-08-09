namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Payment's subscription sequence.
    /// </summary>
    public class PaymentSubscriptionSequenceRequest 
    {
        /// <summary>
        /// Number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Total.
        /// </summary>
        public int? Total { get; set; }
    }
}