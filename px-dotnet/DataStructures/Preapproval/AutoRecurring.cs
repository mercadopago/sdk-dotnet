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
        [JsonConverter(typeof(StringEnumConverter))]
        public FrequencyType FrequencyType { get; set; }

        public int Frequency { get; set; }

        public decimal TransactionAmount { get; set; }

        public CurrencyId CurrencyId { get; set; }

        public DateTime? Start_date { get; set; }

        public DateTime? End_date { get; set; }
    }
}
