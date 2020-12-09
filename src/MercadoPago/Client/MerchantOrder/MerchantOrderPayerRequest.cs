namespace MercadoPago.Client.MerchantOrder
{
    /// <summary>
    /// Payer information.
    /// </summary>
    public class MerchantOrderPayerRequest
    {
        /// <summary>
        /// Payer ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Payer nickname.
        /// </summary>
        public string Nickname { get; set; }
    }
}
