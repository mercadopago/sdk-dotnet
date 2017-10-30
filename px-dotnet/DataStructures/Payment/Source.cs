using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct Source
    {
        #region Properties 
        private string _id;
        private string _name;
        private RefundUserType _type;
        #endregion

        #region Accessors
        /// <summary>
        /// Payment identifier
        /// </summary>
        public string Id { 
            get => _id; 
            set => _id = value; 
        }
        /// <summary>
        /// Payment identifier
        /// </summary>
        public string Name { 
            get => _name; 
            set => _name = value; 
        }
        /// <summary>
        /// Payment identifier
        /// </summary>
        public RefundUserType Type {
            get => _type; 
            set => _type = value; 
        } 
        #endregion
    }
}
