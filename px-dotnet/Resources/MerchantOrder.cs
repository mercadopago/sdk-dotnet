using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MercadoPago.DataStructures.MerchantOrder;

namespace MercadoPago.Resources
{
    public sealed class MerchantOrder : Resource<MerchantOrder>
    {
        #region Actions

        public static MerchantOrder FindById(string id, bool useCache = false) => Get($"/merchant_order/{id}", useCache);

        public MerchantOrder Load(string id, bool useCache = false) => Get($"/merchant_order/{id}", useCache);

        public MerchantOrder Save() => Post("/merchant_orders");

        public MerchantOrder Update() => Put($"/merchant_orders/{Id}");

        #endregion

        #region Properties

        public string Id { get; set; }

        public string PreferenceId { get; set; }

        public DateTime? DateCreated { get; }

        public DateTime? LastUpdate { get; }

        public string ApplicationId { get; set; }

        public string Status { get; }

        public string SiteId { get; set; }

        public Payer Payer { get; set; }

        public Collector? Collector { get; set; }

        public int? SponsorId { get; set; }

        public List<MerchantOrderPayment> Payments { get; }

        public decimal? PaidAmount { get; }

        public decimal? RefundedAmount { get; }

        public decimal? ShippingCost { get; }

        public bool? Cancelled { get; set; }

        public List<Item> Items { get; set; }

        public List<Shipment> Shipments { get; set; }

        [StringLength(500)]
        public string NotificationUrl { get; set; }

        [StringLength(600)]
        public string AdditionalInfo { get; set; }

        [StringLength(256)]
        public string ExternalReference { get; set; }

        [StringLength(256)]
        public string Marketplace { get; set; }

        public decimal? TotalAmount { get; }

        #endregion

        public void AppendShipment(Shipment shipment)
        {
            if (Shipments == null)
            {
                Shipments = new List<Shipment>();
            }
            Shipments.Add(shipment);
        }

        public void AppendItem(Item item)
        {
            if (Items == null)
            {
                Items = new List<Item>();
            }
            Items.Add(item);
        }
    }
}