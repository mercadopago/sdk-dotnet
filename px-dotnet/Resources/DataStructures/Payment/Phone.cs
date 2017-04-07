using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class Phone
    {
        #region Properties

        [StringLength(256)]
        private string areaCode;
        [StringLength(256)]
        private string number;

        #endregion

        #region Accessors

        public string AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }        

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        #endregion
    }
}
