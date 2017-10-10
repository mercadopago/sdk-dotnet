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
        private string _type;
        [StringLength(256)]
        private string _number;

        #endregion

        #region Accessors

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string number
        {
            get { return _number; }
            set { _number = value; }
        }

        #endregion
    }
}
