using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Customer
{
    public class Shipment
    {
        #region Properties

        private bool success;
        private List<Error> errors;
        private string name;

        #endregion

        #region Accessors

        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        public List<Error> Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion
    }
}
