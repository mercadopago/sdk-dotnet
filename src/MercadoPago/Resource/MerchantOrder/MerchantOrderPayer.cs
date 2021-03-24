namespace MercadoPago.Resource.MerchantOrder
{
    /// <summary>
    /// Payer information of Merchant Order.
    /// </summary>
    public class MerchantOrderPayer
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
