using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoPago.DataStructures.Preference
{
    public struct PaymentType
    {
        /// <summary>
        /// Payment method data_type ID
        /// </summary>
        [StringLength(256)]
        public string Id { get; set; }
    }
}
