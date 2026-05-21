namespace MercadoPago.Resource.Payment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Payment method information associated with a <see cref="Payment"/>,
    /// containing rules and reference data for the payment method used.
    /// Not to be confused with
    /// <see cref="MercadoPago.Resource.PaymentMethod.PaymentMethod"/>
    /// which describes available payment methods from the Payment Methods API.
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        /// Data associated with this payment method, including applicable
        /// rules (discounts, fines, interest) and external references.
        /// </summary>
        /// <seealso cref="PaymentData"/>
        public PaymentData Data { get; set; }
    }
}