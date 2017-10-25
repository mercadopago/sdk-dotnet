using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct ReceiverAddress
    {
        #region Properties 
        [StringLength(256)]
        private string _street_name; 
        private int _street_number;
        [StringLength(256)]
        private string _zip_code;
        [StringLength(256)]
        private string _floor;
        [StringLength(256)]
        private string _apartment; 
        #endregion

        #region Accessors 
        /// <summary>
        /// Street name
        /// </summary>
        public string StreetName { 
            get => _street_name;
            set => _street_name = value;
        }
        /// <summary>
        /// Street name
        /// </summary>
        public int StreetNumber
        {
            get => _street_number;
            set => _street_number = value;
        }
        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode {
            get => _zip_code; 
            set => _zip_code = value;
        }
        /// <summary>
        /// Floor
        /// </summary>
        public string Floor {
            get => _floor; 
            set => _floor = value;
        }
        /// <summary>
        /// Apartment
        /// </summary>
        public string Apartment 
        {
            get => _apartment; 
            set => _apartment = value;
        } 
        #endregion
    }
}
