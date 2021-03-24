namespace MercadoPago.Client.AdvancedPayment
{
    using System;

    /// <summary>
    /// Request to update money release date.
    /// </summary>
    public class AdvancedPaymentUpdateReleaseDateRequest
    {
        /// <summary>
        /// Money release date.
        /// </summary>
        public DateTime? MoneyReleaseDate { get; set; }
    }
}
