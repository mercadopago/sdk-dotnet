namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// OrderDiscountPaymentMethod class.
    /// </summary>
    public class OrderDiscountPaymentMethod
    {
        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// New total amount.
        /// </summary>
        public string NewTotalAmount { get; set; }
    }
}
