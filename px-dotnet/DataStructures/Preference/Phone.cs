using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct Phone
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
            get { return this.areaCode; }
            set { this.areaCode = value; }
        }
        
        public string Number 
        {
            get { return this.number; }
            set { this.number = value; }
        }

        #endregion
    }
}
