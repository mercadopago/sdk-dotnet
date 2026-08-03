namespace MercadoPago.Client.Point
{
    /// <summary>
    /// Request body for changing the operating mode of a Point device
    /// via <see cref="PointClient.ChangeDeviceOperatingModeAsync"/> /
    /// <see cref="PointClient.ChangeDeviceOperatingMode"/>.
    /// </summary>
    public class PointDeviceOperatingModeRequest
    {
        /// <summary>
        /// Target operating mode for the device (e.g. <c>PDV</c>, <c>STANDALONE</c>).
        /// </summary>
        public string OperatingMode { get; set; }
    }
}
