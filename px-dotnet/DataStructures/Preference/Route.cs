using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Route
    {
        /// <summary>
        /// Departure
        /// </summary>
        public string Departure { get; set; }
        /// <summary>
        /// Destination
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// Departure Date Time
        /// </summary>
        public string DepartureDateTime { get; set; }
        /// <summary>
        /// Arrival Date Time
        /// </summary>
        public string ArrivalDateTime { get; set; }
        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }
    }
}
