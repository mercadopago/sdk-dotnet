using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
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
            get { return type; }
            set { type = value; }
        }
       
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        #endregion
    }
}
