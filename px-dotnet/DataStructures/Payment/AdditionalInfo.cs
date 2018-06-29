using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct AdditionalInfo
    {
        /// <summary>
        /// List of items to be paid
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Buyer's information
        /// </summary>
        public AdditionalInfoPayer Payer { get; set; }

        /// <summary>
        /// Shipping information
        /// </summary>
        public Shipment Shipment { get; set; }

        /// <summary>
        /// Barcode information
        /// </summary>
        public Barcode Barcode { get; set; }

        /// <summary>
        /// IP Address Information
        /// </summary>
        public string IpAddress { get; set; }
    }
}
