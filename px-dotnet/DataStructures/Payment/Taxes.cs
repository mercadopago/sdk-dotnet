using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Payment
{
    public struct Taxes
    {

        #region Properties 
        private int _value;
        private string _type;
        #endregion

        #region Accesors 
        /// <summary>
        /// The amount of taxes
        /// </summary>
        public int Value
        { 
            get { return _value; }
            set { _value = value; }
        }
    
        /// <summary>
        /// The name of the type of taxes
        /// </summary>
         public string Type
        { 
            get { return _type; }
            set { _type = value; }
        }
        #endregion
    }
}
