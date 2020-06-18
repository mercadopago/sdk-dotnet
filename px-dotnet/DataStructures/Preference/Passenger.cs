using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Passenger
    {
        /// <summary>
        /// Passenger firstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Passenger lastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Passenger identification
        /// </summary>
        public Identification Identification { get; set; }
    }
}
