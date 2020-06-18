using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Route
    {
        #region Properties
        [StringLength(256)]
        private string _departure;
        [StringLength(256)]
        private string _destination;
        private DateTime _departureDateTime;
        private DateTime _arrivalDateTime;
        [StringLength(256)]
        private string _company;
        #endregion

        #region Accessors
        /// <summary>
        /// Route departure
        /// </summary>
        public string Departure
        {
            get { return _departure; }
            set { _departure = value; }
        }
        #region Accessors
        /// <summary>
        /// Route destination
        /// </summary>
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        #endregion
    }
}