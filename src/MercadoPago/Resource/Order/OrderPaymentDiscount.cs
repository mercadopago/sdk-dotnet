namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a discount applied to an individual <see cref="OrderPayment"/>, identifying the
    /// type of promotional or campaign discount that was used.
    /// </summary>
    public class OrderPaymentDiscount
    {
        /// <summary>
        /// Discount type identifier indicating the kind of promotion applied (e.g., "campaign", "coupon").
        /// </summary>
        public string Type { get; set; }
    }
}
