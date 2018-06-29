using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.MerchantOrder
{
    public struct Item
    {
        public string ID { get; set; }

        public string CategoryId { get; set; }

        [RegularExpression(@"^.{3,3}$")]
        public string CurrencyId { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string Title { get; set; }
    }
}
