using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Passenger
    {
        #region Properties
        [StringLength(256)]
        private string _firstName;
        [StringLength(256)]
        private string _lastName;
        private Identification _identification;
        #endregion

        #region Accessors
        /// <summary>
        /// Passenger firstName
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        #region Accessors
        /// <summary>
        /// Passenger lastName
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        /// <summary>
        /// Passenger identification
        /// </summary>
        public Identification Identification
        {
            get { return _identification; }
            set { _identification = value; }
        }
        #endregion
    }
}