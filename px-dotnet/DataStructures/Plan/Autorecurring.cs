using System;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.Plan
{
    public struct AutoRecurring
    {
        #region Properties

        private int frequency;
        private string frequencyType;
        private float transactionAmount;
        private CurrencyId currencyId;
        private int repetitions;
        private int debitDate;
        private FreeTrial freeTrial;
 
        #endregion

        #region Accessors
        public int Frequency
        {
            get
            {
                return frequency;
            }

            set
            {
                frequency = value;
            }
        }

        public string FrequencyType
        {
            get
            {
                return frequencyType;
            }

            set
            {
                frequencyType = value;
            }
        }

        public float TransactionAmount
        {
            get
            {
                return transactionAmount;
            }

            set
            {
                transactionAmount = value;
            }
        }

        public CurrencyId CurrencyId
        {
            get
            {
                return currencyId;
            }

            set
            {
                currencyId = value;
            }
        }

        public int Repetitions
        {
            get
            {
                return repetitions;
            }

            set
            {
                repetitions = value;
            }
        }

        public int DebitDate
        {
            get
            {
                return debitDate;
            }

            set
            {
                debitDate = value;
            }
        }

        public FreeTrial FreeTrial
        {
            get
            {
                return freeTrial;
            }

            set
            {
                freeTrial = value;
            }
        }

        #endregion

    }
}
