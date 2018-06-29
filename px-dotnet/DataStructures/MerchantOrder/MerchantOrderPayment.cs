using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using MercadoPago.Common;

namespace MercadoPago.DataStructures.MerchantOrder
{
    public struct MerchantOrderPayment
    {
        public enum OperationType
        {
            RegularPayment,
            PaymentAddition
        }

        public string ID { get; private set; }

        public decimal TransactionAmount { get; private set; }

        public decimal TotalPaidAmount { get; private set; }

        public decimal ShippingCost { get; private set; }

        public CurrencyId PaymentCurrencyId { get; private set; }

        public string Status { get; private set; }

        public string StatusDetail { get; private set; }

        public OperationType PaymentOperationType { get; private set; }

        public DateTime DateApproved { get; private set; }

        public DateTime DateCreated { get; private set; }

        public DateTime LastModified { get; private set; }

        public decimal AmountRefunded { get; private set; }
    }
}
