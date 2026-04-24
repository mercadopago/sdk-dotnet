namespace MercadoPago.Resource.MerchantOrder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a shipment associated with a <see cref="MerchantOrder"/>.
    /// Contains delivery tracking information, shipping method details, sender/receiver data,
    /// and the destination address.
    /// </summary>
    public class MerchantOrderShipment
    {
        /// <summary>
        /// Unique identifier of the shipment, assigned by MercadoPago.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Type of shipping service used (e.g., standard, express).
        /// </summary>
        public string ShippingType { get; set; }

        /// <summary>
        /// Shipping mode that determines how the shipment is handled
        /// (e.g., <c>me2</c> for MercadoEnvios, <c>custom</c> for seller-managed shipping).
        /// </summary>
        public string ShippingMode { get; set; }

        /// <summary>
        /// Indicates how the package is picked up (e.g., drop-off, carrier pick-up).
        /// </summary>
        public string PickingType { get; set; }

        /// <summary>
        /// Current status of the shipment (e.g., <c>ready_to_ship</c>, <c>shipped</c>, <c>delivered</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Detailed substatus providing additional context about the current shipping status.
        /// </summary>
        public string ShippingSubstatus { get; set; }

        /// <summary>
        /// List of items included in this shipment. Each entry is a dictionary of item attributes.
        /// </summary>
        public IList<IDictionary<string, object>> Items { get; set; }

        /// <summary>
        /// Date and time when the shipment record was created.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last modification to this shipment record.
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Date and time when the shipping label was first printed by the seller.
        /// </summary>
        public DateTime? DateFirstPrinted { get; set; }

        /// <summary>
        /// Identifier of the shipping service or carrier handling this shipment.
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// MercadoPago user ID of the sender (seller) who ships the package.
        /// </summary>
        public long? SenderId { get; set; }

        /// <summary>
        /// MercadoPago user ID of the receiver (buyer) who will receive the package.
        /// </summary>
        public long? ReceiverId { get; set; }

        /// <summary>
        /// Destination address where the shipment will be delivered.
        /// </summary>
        public MerchantOrderReceiverAddress ReceiverAddress { get; set; }

        /// <summary>
        /// Selected shipping option containing cost, estimated delivery, and speed details.
        /// </summary>
        public MerchantOrderShippingOption ShippingOption { get; set; }
    }
}
