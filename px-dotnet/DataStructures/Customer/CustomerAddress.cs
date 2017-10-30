using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct Address
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
        private City _city;
        private State _state;
        private Country _country;
        private Neighborhood _neighborhood;
        private Municipality _municipality;
        private string _comments;
        private DateTime _date_created;
        private List<Verification> _verifications; 
        #endregion

        #region Accessors

        public string ID
        {
            get { return id; }
        }

        public string Phone
        {
            get { return phone; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Floor
        {
            get { return floor; }
        }

        public string Apartment
        {
            get { return apartment; }
        }

        public string StreetName
        {
            get { return street_name; }
        }

        public string StreetNumber
        {
            get { return street_number; }
        }

        public string ZipCode
        {
            get { return zip_code; }
        }

        public City City
        {
            get { return city; }
        }

        public State State
        {
            get { return state; }
        }

        public Country Country
        {
            get { return country; }
        }

        public Neighborhood Neighborhood
        {
            get { return neighborhood; }
        }

        public Municipality Municipality
        {
            get { return municipality; }
        }

        public string Comments
        {
            get { return comments; }
        }

        public DateTime DateCreated
        {
            get { return date_created; }
        }

        public List<Verification> Verifications
        {
            get { return verifications; }
        }

        #endregion
    }
}
