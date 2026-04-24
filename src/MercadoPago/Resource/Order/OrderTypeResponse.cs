namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Represents type-specific response data for an <see cref="Order"/>, containing additional output
    /// fields that depend on the order type (e.g., QR code data for in-store payments).
    /// </summary>
    public class OrderTypeResponse
    {
        /// <summary>
        /// QR code payload data used for in-store or point-of-sale payment flows.
        /// </summary>
        public string QrData { get; set; }
    }
}
