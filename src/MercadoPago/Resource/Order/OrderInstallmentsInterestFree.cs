namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the interest-free installment configuration within <see cref="OrderInstallments"/>,
    /// specifying which installment counts are offered without interest charges.
    /// </summary>
    public class OrderInstallmentsInterestFree
    {
        /// <summary>
        /// Interest-free installment type that determines how the interest-free rules are applied (e.g., "custom", "all").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// List of installment counts that qualify for interest-free financing (e.g., [3, 6, 12]).
        /// </summary>
        public IList<int> Values { get; set; }
    }
}
