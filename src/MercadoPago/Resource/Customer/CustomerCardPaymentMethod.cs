namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Payment method information.
    /// </summary>
    public class CustomerCardPaymentMethod
    {
        /// <summary>
        /// Payment method ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Payment method name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Payment method type.
        /// </summary>
        public string PaymentTypeId { get; set; }

        /// <summary>
        /// Payment method thumbnail.
        /// </summary>
        public string Thumbnail { get; set; }


        /// <summary>
        /// Payment method secure thumbnail.
        /// </summary>
        public string SecureThumbnail { get; set; }
    }
}
