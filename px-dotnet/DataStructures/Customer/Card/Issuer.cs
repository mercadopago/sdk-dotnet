using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Customer.Card
{
    /// <summary>
    /// Issuer information.
    /// </summary>
    public struct Issuer
    {
        #region Properties
        private string _id;
        private string _name;
        #endregion

        #region Accessors
        /// <summary>
        /// Issuer Id
        /// </summary>
        public string Id
        {
            get { return  _id; } 
            set {  _id = value; }
        }
        /// <summary>
        /// Issuer name
        /// </summary>
        public string Name
        {
            get { return  _name; } 
            set {  _name = value; }
        }
        #endregion
    }
}
