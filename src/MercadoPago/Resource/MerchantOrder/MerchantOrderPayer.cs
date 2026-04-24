namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Represents the payer (buyer) associated with a <see cref="MerchantOrder"/>.
    /// Contains the buyer's MercadoPago account identification.
    /// </summary>
    public class MerchantOrderPayer
    {
        /// <summary>
        /// Unique MercadoPago user ID of the payer (buyer).
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Display nickname of the payer on the MercadoPago platform.
        /// </summary>
        public string Nickname { get; set; }
    }
}
