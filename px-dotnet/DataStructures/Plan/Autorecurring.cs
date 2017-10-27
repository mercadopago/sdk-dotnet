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

        public int Frequency { get => frequency; set => frequency = value; }
        public string FrequencyType { get => frequencyType; set => frequencyType = value; }
        public float TransactionAmount { get => transactionAmount; set => transactionAmount = value; }
        public CurrencyId CurrencyId { get => currencyId; }
        public int Repetitions { get => repetitions; set => repetitions = value; }
        public int DebitDate { get => debitDate; set => debitDate = value; }
        public FreeTrial FreeTrial { get => freeTrial; set => freeTrial = value; }

        #endregion

    }
}
