namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents the available installment plan options within <see cref="OrderInstallments"/>,
    /// defining which installment configurations are offered to the payer.
    /// </summary>
    public class OrderInstallmentsAvailable
    {
        /// <summary>
        /// Installment availability type that controls which plans are shown to the payer (e.g., "all", "custom").
        /// </summary>
        public string Type { get; set; }
    }
}
