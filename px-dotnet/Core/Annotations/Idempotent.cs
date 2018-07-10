using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    internal class Idempotent : Attribute
    {
        #region Variables
        public string GUID { get; set; }
        #endregion

        #region Constructors
        public Idempotent() {
            this.GUID = System.Guid.NewGuid().ToString();            
        }
        #endregion
    }
}
