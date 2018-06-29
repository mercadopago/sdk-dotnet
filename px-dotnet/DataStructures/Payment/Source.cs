using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct Source
    {
        /// <summary>
        /// Payment identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Payment identifier
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Payment identifier
        /// </summary>
        public RefundUserType Type { get; set; }
    }
}
