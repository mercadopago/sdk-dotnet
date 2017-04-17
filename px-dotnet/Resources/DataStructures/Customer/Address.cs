using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer
{
    public class Address
    {
        #region Properties

        private string id;
        private string phone;
        private string name;
        private string floor;
        private string apartment;
        private string streetName;
        private string streetNumber;
        private string zipCode;
        private City city;
        private State state;
        private Country country;
        private Neighborhood neighborhood;
        private Municipality municipality;
        private string comments;
        private DateTime dateCreated;
        private List<Verification> verifications;        

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
            get { return streetName; }            
        }

        public string StreetNumber
        {
            get { return streetNumber; }            
        }

        public string ZipCode
        {
            get { return zipCode; }            
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
            get { return dateCreated; }            
        }

        public List<Verification> Verifications
        {
            get { return verifications; }            
        }

        #endregion
    }
}
