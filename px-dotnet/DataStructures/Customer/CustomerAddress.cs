using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer
{
    public struct CustomerAddress
    {
        /// <summary> Address ID </summary>
        public string Id { get; set; }

        /// <summary> Address phone </summary>
        public string Phone { get; set; }

        /// <summary> Address name </summary>
        public string Name { get; set; }

        /// <summary> Floor </summary>
        public string Floor { get; set; }

        /// <summary> Apartment </summary>
        public string Apartment { get; set; }

        /// <summary> Street name </summary>
        public string StreetName { get; set; }

        /// <summary> Street number </summary>
        public string StreetNumber { get; set; }

        /// <summary> Postal code of an Address </summary>
        public string ZipCode { get; set; }

        /// <summary> City information </summary>
        public City? City { get; set; }

        /// <summary> State information </summary>
        public State? State { get; set; }

        /// <summary> Country information </summary>
        public Country? Country { get; set; }

        /// <summary> Neighborhood information </summary>
        public Neighborhood? Neighborhood { get; set; }

        /// <summary> Municipality information </summary>
        public Municipality? Municipality { get; set; }

        /// <summary> Additional information </summary>
        public string Comments { get; set; }

        /// <summary> Address date created </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary> The result of addresses validations </summary>
        public Verification Verifications { get; set; }

        /// <summary> 
        /// Whether the customers 
        /// will be in sandbox or in production mode 
        /// </summary>
        public bool LiveMode { get; set; }
    }
}
