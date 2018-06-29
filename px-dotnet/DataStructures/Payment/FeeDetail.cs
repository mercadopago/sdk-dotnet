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
        private decimal? _amount;
        #endregion

        #region Accessors
        /// <summary> Fee detail </summary>
        public FeeType? Type { 
            get { return  _type; } 
            private set { _type = value; } 
        }
        /// <summary> Who absorbs the cost </summary>
        public FeePayerType? FeePayer { 
            get { return  _fee_payer; } 
            private set { _fee_payer = value; } 
        }
        /// <summary> Fee amount </summary>
        public decimal? Amount { 
            get { return  _amount; } 
            private set { _amount = value; } 
        } 
        #endregion
    }
}
