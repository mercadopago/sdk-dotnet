namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// OrderDiscounts class.
    /// </summary>
    public class OrderDiscounts
    {
        /// <summary>
        /// Payment methods discounts.
        /// </summary>
        public IList<OrderDiscountPaymentMethod> PaymentMethods { get; set; }
    }
}
