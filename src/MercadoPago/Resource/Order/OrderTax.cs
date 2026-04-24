namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents a tax entry applied to an <see cref="Order"/>, defining the tax type,
    /// applicable payer condition, and the tax amount.
    /// </summary>
    public class OrderTax
    {
        /// <summary>
        /// Tax condition of the payer that triggers this tax (e.g., fiscal status or registration category).
        /// </summary>
        public string PayerCondition { get; set; }

        /// <summary>
        /// Tax type identifier (e.g., "IVA", "IGF", "VAT") defining which tax regulation applies.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Tax amount or rate value applied to the order, expressed in the order currency or as a percentage.
        /// </summary>
        public string Value { get; set; }
    }
}
