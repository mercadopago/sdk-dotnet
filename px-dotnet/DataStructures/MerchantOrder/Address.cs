using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.MerchantOrder
{
    /// <summary>
    /// Address information.
    /// </summary>
    public struct Address
    {
        #region Properties

        [StringLength(256)]
        private string zipCode;
        [StringLength(256)]
        private string streetName;
        private int streetNumber;
        [StringLength(256)]
        private string floor;
        [StringLength(256)]
        private string apartment;
        
        #endregion

        #region Accessors

        /// <summary>
        /// Zip code.
        /// </summary>
        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        /// <summary>
        /// Street name.
        /// </summary>
        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        /// <summary>
        /// Street number.
        /// </summary>
        public int StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }

        /// <summary>
        /// Floor.
        /// </summary>
        public string Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        /// <summary>
        /// Apartment.
        /// </summary>
        public string Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }

        #endregion
    }
}
