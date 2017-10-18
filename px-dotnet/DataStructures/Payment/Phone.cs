using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Payment
{
    public struct Phone
    {
        #region Properties

        [StringLength(256)]
        private string areaCode;
        [StringLength(256)]
        private string number;
        private string _extension;

        #endregion

        #region Accessors

        /// <summary>
        /// Phone area code
        /// </summary>
        public string AreaCode
        {
            get { return areaCode; }
            set { areaCode = value; }
        }        

        /// <summary>
        /// Phone number
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        /// <summary>
        /// Phone number's extension
        /// </summary>
        public string Extension
        {
            get { return _extension; }
            private set { _extension = value; }
        }

        #endregion
    }
}
