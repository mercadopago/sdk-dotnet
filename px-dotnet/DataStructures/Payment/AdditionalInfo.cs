using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct AdditionalInfo
    {
        #region Properties
        private string _ip_address;
        private List<Item> _items;
        private AdditionalInfoPayer _payer;
        private Shipment _shipment; 
        private Barcode _barcode;
        #endregion

        #region Accessors
        /// <summary>
        /// List of items to be paid
        /// </summary>
        public List<Item> Items { 
            private get => _items; 
            set => _items = value; 
        }
        /// <summary>
        /// Buyer's information
        /// </summary>
        public AdditionalInfoPayer Payer { 
            private get => _payer; 
            set => _payer = value; 
        }
        /// <summary>
        /// Shipping information
        /// </summary>
        public Shipment Shipment { 
            private get => _shipment; 
            set => _shipment = value; 
        }
        /// <summary>
        /// Barcode information
        /// </summary>
        public Barcode Barcode { 
            get => _barcode; 
            set => _barcode = value; 
        } 
        #endregion
    }
}
