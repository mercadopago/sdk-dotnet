using MercadoPago.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preapproval
{
    public struct AutoRecurring
    {
        #region Properties 

        private int frequency;
        [JsonConverter(typeof(StringEnumConverter))]
        private FrequencyType frequency_type;
        private float transaction_amount;
        [StringLength(3)]
        private CurrencyId currency_id;
        private DateTime? start_date;
        private DateTime? end_date;

        #endregion

        #region Accessors

        public FrequencyType FrequencyType
        {
            get
            {
                return frequency_type;
            }

            set
            {
                frequency_type = value;
            }
        }

        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public float TransactionAmount
        {
            get { return transaction_amount; }
            set { transaction_amount = value; }
        }

        public CurrencyId CurrencyId
        {
            get { return currency_id; }
            set { currency_id = value; }
        }

        public DateTime? Start_date
        {
            get
            {
                return start_date;
            }

            set
            {
                start_date = value;
            }
        }


        public DateTime? End_date
        {
            get
            {
                return end_date;
            }

            set
            {
                end_date = value;
            }
        }

        #endregion
    }
}
