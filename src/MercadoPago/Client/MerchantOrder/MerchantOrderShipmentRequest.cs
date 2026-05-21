namespace MercadoPago.Client.MerchantOrder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a shipment associated with a merchant order, including carrier details,
    /// delivery address, and shipping status.
    /// </summary>
    /// <see cref="MerchantOrderUpdateRequest"/>
    public class MerchantOrderShipmentRequest
    {
        /// <summary>
        /// Unique identifier of the shipment in MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Type of shipping service (e.g., standard, express).
        /// </summary>
        public string ShippingType { get; set; }

        /// <summary>
        /// Shipping mode indicating how the shipment is fulfilled (e.g., <c>"me1"</c>, <c>"me2"</c>, <c>"custom"</c>).
        /// </summary>
        public string ShippingMode { get; set; }

        /// <summary>
        /// Pick-up type for the shipment (e.g., drop-off, pick-up point, home collection).
        /// </summary>
        public string PickingType { get; set; }

        /// <summary>
        /// Current status of the shipment (e.g., <c>"pending"</c>, <c>"shipped"</c>, <c>"delivered"</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed substatus providing additional context about the current shipping status.
        /// </summary>
        public string ShippingSubstatus { get; set; }

        /// <summary>
        /// List of items included in this shipment, represented as key-value dictionaries.
        /// </summary>
        public IList<IDictionary<string, object>> Items { get; set; }

        /// <summary>
        /// Date and time when the shipment was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last modification to the shipment.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Date and time when the shipping label was first printed.
        /// </summary>
        public DateTime? DateFirstPrinted { get; set; }

        /// <summary>
        /// Identifier of the shipping carrier or logistics service.
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// MercadoPago user ID of the shipment sender (typically the seller).
        /// </summary>
        public long? SenderId { get; set; }

        /// <summary>
        /// MercadoPago user ID of the shipment receiver (typically the buyer).
        /// </summary>
        public long? ReceiverId { get; set; }

        /// <summary>
        /// Destination address where the shipment will be delivered.
        /// </summary>
        /// <see cref="MerchantOrderReceiverAddressRequest"/>
        public MerchantOrderReceiverAddressRequest ReceiverAddress { get; set; }

        /// <summary>
        /// Selected shipping option with cost, speed, and estimated delivery information.
        /// </summary>
        /// <see cref="MerchantOrderShippingOptionRequest"/>
        public MerchantOrderShippingOptionRequest ShippingOption { get; set; }
    }
}
