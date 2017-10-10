using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class Identification
    {
        #region Properties

        [StringLength(256)]
        private string type;

        [StringLength(256)]
        private string number;

        #endregion 

        #region Accessors

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        #endregion
    }
}
