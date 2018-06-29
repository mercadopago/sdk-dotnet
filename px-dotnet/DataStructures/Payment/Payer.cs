using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct Payer
    {
        /// <summary>
        /// Find a payment trought an unique identifier
        /// </summary>
        public EntityType? Entity_type { get; set; }

        /// <summary>
        /// Identification type of the associated payer 
        /// (mandatory if the Payer is a Customer)
        /// </summary>
        public PayerType? Type { get; set; }

        /// <summary>
        /// Identification of the associated payer
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email of the payer
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Personal identification
        /// </summary>
        public Identification? Identification { get; set; }

        /// <summary>
        /// Phone of the associated payer
        /// </summary>
        public Phone? Phone { get; private set; }

        /// <summary>
        /// First name of the associated payer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the associated payer
        /// </summary>
        public string LastName { get; set; }

        public Address Address { get; set; }
    }
}
