namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// OrderPaymentMethodConfig class.
    /// </summary>
    public class OrderPaymentMethodConfig
    {
        /// <summary>
        /// Default type.
        /// </summary>
        public string DefaultType { get; set; }

        /// <summary>
        /// Installments cost.
        /// </summary>
        public string InstallmentsCost { get; set; }

        /// <summary>
        /// Installments.
        /// </summary>
        public OrderInstallments Installments { get; set; }

        /// <summary>
        /// Minimum installments.
        /// </summary>
        public int? MinInstallments { get; set; }
    }
}
