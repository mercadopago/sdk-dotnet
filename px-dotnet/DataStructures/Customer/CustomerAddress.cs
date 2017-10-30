using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct CustomerAddress
    {
        #region Properties
        private string _id;
        private string _phone;
        private string _name;
        private string _floor;
        private string _apartment;
        private string _street_name;
        private string _street_number;
        private string _zip_code;
        private City? _city;
        private State? _state;
        private Country? _country;
        private Neighborhood? _neighborhood;
        private Municipality? _municipality;
        private string _comments;
        private DateTime? _date_created;
        private Verification _verifications;
        private bool _live_mode;
        #endregion

        #region Accessors
        /// <summary> Address ID </summary>
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        /// <summary> Address phone </summary>
        public string Phone
        {
            get
            {
                return _phone;
            }

            set
            {
                _phone = value;
            }
        }
        /// <summary> Address name </summary>
        public string Name 
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        /// <summary> Floor </summary>
        public string Floor
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        /// <summary> Apartment </summary>
        public string Apartment
        {
            get
            {
                return _apartment;
            }

            set
            {
                _apartment = value;
            }
        }
        /// <summary> Street name </summary>
        public string StreetName
        {
            get
            {
                return _street_name;
            }

            set
            {
                _street_name = value;
            }
        }
        /// <summary> Street number </summary>
        public string StreetNumber
        {
            get
            {
                return _street_number;
            }

            set
            {
                _street_number = value;
            }
        }
        /// <summary> Postal code of an Address </summary>
        public string ZipCode
        {
            get
            {
                return _zip_code;
            }

            set
            {
                _zip_code = value;
            }
        }
        /// <summary> City information </summary>
        public City? City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }
        /// <summary> State information </summary>
        public State? State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
        /// <summary> Country information </summary>
        public Country? Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }
        /// <summary> Neighborhood information </summary>
        public Neighborhood? Neighborhood
        {
            get
            {
                return _neighborhood;
            }

            set
            {
                _neighborhood = value;
            }
        }
        /// <summary> Municipality information </summary>
        public Municipality? Municipality
        {
            get
            {
                return _municipality;
            }

            set
            {
                _municipality = value;
            }
        }
        /// <summary> Additional information </summary>
        public string Comments
        {
            get
            {
                return _comments;
            }

            set
            {
                _comments = value;
            }
        }
        /// <summary> Address date created </summary>
        public DateTime? DateCreated
        {
            get
            {
                return _date_created;
            }

            set
            {
                _date_created = value;
            }
        }
        /// <summary> The result of addresses validations </summary>
        public Verification Verifications
        {
            get
            {
                return _verifications;
            }

            set
            {
                _verifications = value;
            }
        }
        /// <summary> 
        /// Whether the customers 
        /// will be in sandbox or in production mode 
        /// </summary>
        public bool LiveMode
        {
            get
            {
                return _live_mode;
            }

            set
            {
                _live_mode = value;
            }
        } 
        #endregion
    }
}
