using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoPago.DataStructures.Preference
{
    public struct PaymentType
    {
        #region Properties 
        [StringLength(256)]
        private string _id;
        #endregion

        #region Accessors
        /// <summary>
        /// Payment method data_type ID
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        #endregion
    }
}
