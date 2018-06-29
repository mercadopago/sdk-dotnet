using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Payer
    {
        /// <summary>
        /// Buyer name
        /// </summary>
        [StringLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// Buyer last name
        /// </summary>
        [StringLength(256)]
        public string Surname { get; set; }

        /// <summary>
        /// Buyer e-mail address
        /// </summary>
        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Buyer phone
        /// </summary>
        public Phone? Phone { get; set; }

        /// <summary>
        /// Personal identification
        /// </summary>
        public Identification? Identification { get; set; }

        /// <summary>
        /// Buyer address
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Registration date
        /// </summary>
        public DateTime? Date_created { get; set; }
    }
}
