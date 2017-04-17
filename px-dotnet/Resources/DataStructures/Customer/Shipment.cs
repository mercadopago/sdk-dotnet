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
        }

        public List<Error> Errors
        {
            get { return errors; }            
        }

        public string Name
        {
            get { return name; }            
        }

        #endregion
    }
}
