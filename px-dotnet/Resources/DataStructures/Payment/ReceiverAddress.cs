using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Payment
{
    public class ReceiverAddress : Address
    {
        #region Properties

        [StringLength(256)]
        private string floor;
        [StringLength(256)]
        private string apartment;

        #endregion

        #region Accessors

        public string Floor
        {
            get { return floor; }
            set { floor = value; }
        }
        
        public string Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }

        #endregion
    }
}
