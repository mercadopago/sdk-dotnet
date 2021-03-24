namespace MercadoPago.Client.MerchantOrder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Shipment information.
    /// </summary>
    public class MerchantOrderShipmentRequest
    {
        /// <summary>
        /// Shipping ID.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Shipping type.
        /// </summary>
        public string ShippingType { get; set; }

        /// <summary>
        /// Shipping mode.
        /// </summary>
        public string ShippingMode { get; set; }

        /// <summary>
        /// Shipping picking type.
        /// </summary>
        public string PickingType { get; set; }

        /// <summary>
        /// Shipping status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Shipping substatus.
        /// </summary>
        public string ShippingSubstatus { get; set; }

        /// <summary>
        /// Shipping items.
        /// </summary>
        public IList<IDictionary<string, object>> Items { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// First printed date.
        /// </summary>
        public DateTime? DateFirstPrinted { get; set; }

        /// <summary>
        /// Shipping service ID.
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// Sender ID.
        /// </summary>
        public long? SenderId { get; set; }

        /// <summary>
        /// Receiver ID.
        /// </summary>
        public long? ReceiverId { get; set; }

        /// <summary>
        /// Shipping address.
        /// </summary>
        public MerchantOrderReceiverAddressRequest ReceiverAddress { get; set; }

        /// <summary>
        /// Shipping options.
        /// </summary>
        public MerchantOrderShippingOptionRequest ShippingOption { get; set; }
    }
}
