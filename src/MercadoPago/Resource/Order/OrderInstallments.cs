namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// OrderInstallments class.
    /// </summary>
    public class OrderInstallments
    {
        /// <summary>
        /// Interest free installments.
        /// </summary>
        public OrderInstallmentsInterestFree InterestFree { get; set; }

        /// <summary>
        /// Available installments.
        /// </summary>
        public OrderInstallmentsAvailable Available { get; set; }
    }
}
