using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct FeeDetail
    {
        /// <summary> Fee detail </summary>
        public FeeType? Type { get; private set; }

        /// <summary> Who absorbs the cost </summary>
        public FeePayerType? FeePayer { get; private set; }

        /// <summary> Fee amount </summary>
        public decimal? Amount { get; private set; }
    }
}
