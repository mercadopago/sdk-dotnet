namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// OrderInstallmentsInterestFree class.
    /// </summary>
    public class OrderInstallmentsInterestFree
    {
        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Values.
        /// </summary>
        public IList<int> Values { get; set; }
    }
}
