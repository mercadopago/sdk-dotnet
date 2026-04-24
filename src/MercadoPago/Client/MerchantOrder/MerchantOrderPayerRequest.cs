namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Information about the buyer associated with a merchant order.
    /// Used in <see cref="MerchantOrderCreateRequest"/> and <see cref="MerchantOrderUpdateRequest"/>.
    /// </summary>
    public class MerchantOrderPayerRequest
    {
        /// <summary>
        /// Unique MercadoPago identifier of the payer.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Payer's display name or nickname within MercadoPago.
        /// </summary>
        public string Nickname { get; set; }
    }
}
