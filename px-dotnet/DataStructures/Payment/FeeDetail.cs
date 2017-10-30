using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct FeeDetail
    {
        #region Properties 
        private FeeType? _type; 
        private FeePayerType? _fee_payer;
        private float? _amount;
        #endregion

        #region Accessors
        /// <summary> Fee detail </summary>
        public FeeType? Type { 
            get => _type; 
            private set => _type = value; 
        }
        /// <summary> Who absorbs the cost </summary>
        public FeePayerType? FeePayer { 
            get => _fee_payer; 
            private set => _fee_payer = value; 
        }
        /// <summary> Fee amount </summary>
        public float? Amount { 
            get => _amount; 
            private set => _amount = value; 
        } 
        #endregion
    }
}
