using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct ExcludedPaymentMethod
    {
        #region Properties

        [StringLength(256)]
        private string id;

        #endregion

        #region Accessors

        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        #endregion
    }
}
