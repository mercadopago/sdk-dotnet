namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents discount configurations applied to an <see cref="Order"/>, organized by payment method type.
    /// </summary>
    public class OrderDiscounts
    {
        /// <summary>
        /// List of <see cref="OrderDiscountPaymentMethod"/> entries defining discounts for specific payment method types.
        /// </summary>
        public IList<OrderDiscountPaymentMethod> PaymentMethods { get; set; }
    }
}
