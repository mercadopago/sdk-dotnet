using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Payer
    {
        #region Properties 
        [StringLength(256)]
        private string _name;
        [StringLength(256)]
        private string _surname;
        [StringLength(256)]
        private string _email;
        private Phone? _phone;
        private Identification? _identification;
        private Address? _address;
        private DateTime? _date_created;
        private string _authentication_type;
        private bool _is_prime_user;
        private bool _is_first_puchase_online;
        private DateTime? _last_purchase;
        #endregion

        #region Accessors
        /// <summary>
        /// Buyer name
        /// </summary>
        public string Name {
            get { return  _name; } 
            set { _name = value; }
        }
        /// <summary>
        /// Buyer last name
        /// </summary>
        public string Surname {
            get { return  _surname; } 
            set { _surname = value; }
        }
        /// <summary>
        /// Buyer e-mail address
        /// </summary>
        public string Email {
            get { return  _email; } 
            set { _email = value; }
        }
        /// <summary>
        /// Buyer phone
        /// </summary>
        public Phone? Phone { 
            get { return  _phone; } 
            set { _phone = value; } 
        }
        /// <summary>
        /// Personal identification
        /// </summary>
        public Identification? Identification 
        { 
            get { return  _identification; } 
            set { _identification = value; } 
        }
        /// <summary>
        /// Buyer address
        /// </summary>
        public Address? Address
        {
            get { return  _address; }
            set { _address = value; }
        }
        /// <summary>
        /// Registration date
        /// </summary>
        public DateTime? Date_created 
        { 
            get { return  _date_created; }
            set { _date_created = value; }
        }
        /// <summary>
        /// Authentication type
        /// </summary>
        public string Authentication_type
        {
            get { return _authentication_type; }
            set { _authentication_type = value; }
        }
        /// <summary>
        /// Is prime user
        /// </summary>
        public bool Is_prime_user
        {
            get { return _is_prime_user; }
            set { _is_prime_user = value; }
        }
        /// <summary>
        /// Is prime user
        /// </summary>
        public bool Is_first_purchase_online
        {
            get { return _is_first_puchase_online; }
            set { _is_first_puchase_online = value; }
        }
        /// <summary>
        /// Is prime user
        /// </summary>
        public DateTime? Last_purchase
        {
            get { return _last_purchase; }
            set { _last_purchase = value; }
        }
        #endregion
    }
}