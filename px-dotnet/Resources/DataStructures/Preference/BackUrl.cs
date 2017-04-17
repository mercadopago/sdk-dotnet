using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.Resources.DataStructures.Preference
{
    public class BackUrl
    {
        #region Properties

        [StringLength(600)]
        private string success;

        [StringLength(600)]
        private string pending;

        [StringLength(600)]
        private string failure;

        #endregion

        #region Accessors

        public string Success
        {
            get { return this.success; }
            set { this.success = value; }
        }

        public string Pending
        {
            get { return this.pending; }
            set { this.pending = value; }
        }

        public string Failure
        {
            get { return this.failure; }
            set { this.failure = value; }
        }

        #endregion

    }
}
