namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Tax applied to a <see cref="Payment"/>, representing country-specific
    /// taxes such as IVA or other withholding taxes.
    /// Part of the <see cref="Payment.Taxes"/> list.
    /// </summary>
    public class PaymentTax
    {
        /// <summary>
        /// Type of tax applied. Possible values include "IVA" (value-added tax)
        /// and other country-specific tax identifiers.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Amount of the tax in the payment's currency.
        /// </summary>
        public decimal? Value { get; set; }
    }
}
