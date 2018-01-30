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
        public List<Item> Items 
        {
            get
            {
                return _items;
            }

            set
            {
                _items = value;
            }
        }
        /// <summary>
        /// Buyer's information
        /// </summary>
        public AdditionalInfoPayer Payer
        {
            get
            {
                return _payer;
            }

            set
            {
                _payer = value;
            }
        }
        /// <summary>
        /// Shipping information
        /// </summary>
        public Shipment Shipment 
        {
            get
            {
                return _shipment;
            }

            set
            {
                _shipment = value;
            }
        }
        /// <summary>
        /// Barcode information
        /// </summary>
        public Barcode Barcode 
        {
            get
            {
                return _barcode;
            }

            set
            {
                _barcode = value;
            }
        }
        /// <summary>
        /// IP Address Information
        /// </summary>
        public string IpAddress
        {
            get
            {
                return _ip_address;
            }

            set
            {
                _ip_address = value;
            }
        }
         

        #endregion
    }
}
