using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Address
    {
        #region Properties 
        [StringLength(256)]
        private string _street_name;
        private int _street_number;
        [StringLength(256)]
        private string _zip_code;
        private string _neighborhood;
        private string _city;
        private string _federal_unit;
        #endregion

        #region Accessors 
        /// <summary>
        /// Street name
        /// </summary>
        public string StreetName
        {
            get { return  _street_name; }
            set {  _street_name = value; }
        }
        /// <summary>
        /// Street name
        /// </summary>
        public int StreetNumber
        {
            get { return  _street_number; }
            set {  _street_number = value; }
        }
        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode
        {
            get { return  _zip_code; }
            set {  _zip_code = value; }
        }

        public string Neighborhood
        {
            get {  return _neighborhood; }
            set {  _neighborhood = value; }
        }

        public string City
        {
            get {  return _city; } 
            set { _city = value; }
        }

        public string FederalUnit
        {
            get { return _federal_unit; } 
            set { _federal_unit = value; }
        }
        #endregion
    }
}
