using System.Collections.Generic;

namespace MercadoPago.DataStructures.AdvancedPayment
{
    /// <summary>
    /// Information that can improve fraud prevention analysis and conversion rate
    /// </summary>
    public class AdditionalInfo
    {
        /// <summary>
        /// Request source IP
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Purchased items
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Payer info
        /// </summary>
        public AdditionalInfoPayer Payer { get; set; }

        /// <summary>
        /// Delivery info
        /// </summary>
        public Shipments Shipments { get; set; }
    }
}
