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
        public string Id {
            get => _id; 
            private set => _id = value;
        } 
        /// <summary> Address phone </summary>
        public string Phone {
            get => _phone; 
            private set => _phone = value; 
        }
        /// <summary> Address name </summary>
        public string Name { 
            get => _name; 
            private set => _name = value; 
        }
        /// <summary> Floor </summary>
        public string Floor { 
            get => _floor; 
            private set => _floor = value; 
        }
        /// <summary> Apartment </summary>
        public string Apartment { 
            get => _apartment; 
            private set => _apartment = value; 
        }
        /// <summary> Street name </summary>
        public string StreetName {
            get => _street_name; 
            private set => _street_name = value;
        }
        /// <summary> Street number </summary>
        public string StreetNumber {
            get => _street_number; 
            private set => _street_number = value;
        }
        /// <summary> Postal code of an Address </summary>
        public string ZipCode { 
            get => _zip_code; 
            private set => _zip_code = value;
        }
        /// <summary> City information </summary>
        public City? City {
            get => _city;
            set => _city = value;
        }
        /// <summary> State information </summary>
        public State? State {
            get => _state; 
            private set => _state = value;
        }
        /// <summary> Country information </summary>
        public Country? Country {
            get => _country; 
            private set => _country = value;
        }
        /// <summary> Neighborhood information </summary>
        public Neighborhood? Neighborhood {
            get => _neighborhood; 
            private set => _neighborhood = value;
        }
        /// <summary> Municipality information </summary>
        public Municipality? Municipality {
            get => _municipality; 
            private set => _municipality = value;
        }
        /// <summary> Additional information </summary>
        public string Comments {
            get => _comments; 
            private set => _comments = value;
        }
        /// <summary> Address date created </summary>
        public DateTime? DateCreated {
            get => _date_created; 
            private set => _date_created = value;
        }
        /// <summary> The result of addresses validations </summary>
        public Verification Verifications {
            get => _verifications; 
            private set => _verifications = value;
        }
        /// <summary> 
        /// Whether the customers 
        /// will be in sandbox or in production mode 
        /// </summary>
        public bool LiveMode {
            get => _live_mode; 
            private set => _live_mode = value;
        } 
        #endregion
    }
}
