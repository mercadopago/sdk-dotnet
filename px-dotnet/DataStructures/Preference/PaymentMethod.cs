using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public class PaymentMethod
    {
        #region Properties

        private ExcludedPaymentMethod excludedPaymentMethod;
        private ExcludedPaymentType excludedPaymentType;

        [StringLength(256)]
        private string defaultPaymentMethodId;
        private int installment;
        private int defaultInstallment;

        #endregion

        #region Accessors

        public ExcludedPaymentMethod ExcludePaymentMethod
        {
            get { return this.excludedPaymentMethod; }
            set { this.excludedPaymentMethod = value; }
        }

        public ExcludedPaymentType ExcludePaymentType
        {
            get { return this.excludedPaymentType; }
            set { this.excludedPaymentType = value; }
        }

        public string DefaultPaymentMethodId
        {
            get { return this.defaultPaymentMethodId; }
            set { this.defaultPaymentMethodId = value; }
        }

        public int Installment
        {
            get { return this.installment; }
            set { this.installment = value; }
        }

        public int DefaultInstallment
        {
            get { return this.defaultInstallment; }
            set { this.defaultInstallment = value; }
        }

        #endregion

    }
}
