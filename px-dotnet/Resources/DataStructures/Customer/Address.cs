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
            set { id = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        public string Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }

        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        public string StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }

        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public City City
        {
            get { return city; }
            set { city = value; }
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }

        public Neighborhood Neighborhood
        {
            get { return neighborhood; }
            set { neighborhood = value; }
        }

        public Municipality Municipality
        {
            get { return municipality; }
            set { municipality = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public List<Verification> Verifications
        {
            get { return verifications; }
            set { verifications = value; }
        }

        #endregion
    }
}
