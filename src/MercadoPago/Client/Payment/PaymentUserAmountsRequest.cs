namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Currency and transaction amount for a specific user (collector or payer) within
    /// <see cref="PaymentAmountsRequest"/>. Allows specifying different currencies and
    /// amounts for each side of a cross-border transaction.
    /// </summary>
    public class PaymentUserAmountsRequest
    {
        /// <summary>
        /// ISO 4217 currency code for this user's amount (e.g., "USD", "BRL", "ARS").
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Transaction amount in the specified currency for this user.
        /// </summary>
        public decimal? Transaction { get; set; }
    }
} 