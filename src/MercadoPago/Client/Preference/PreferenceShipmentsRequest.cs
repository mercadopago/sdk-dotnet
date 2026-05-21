namespace MercadoPago.Client.Preference
{
    using System.Collections.Generic;

    /// <summary>
    /// Shipping configuration for a Checkout Pro preference. The available properties depend on the
    /// selected <see cref="Mode"/>: <c>"custom"</c> for seller-managed shipping or <c>"me2"</c>
    /// for MercadoEnvios-managed shipping.
    /// </summary>
    /// <seealso cref="PreferenceRequest"/>
    public class PreferenceShipmentsRequest
    {
        /// <summary>
        /// Shipment mode. Use <c>"custom"</c> for seller-managed shipping or <c>"me2"</c> for
        /// MercadoEnvios integration. Use <c>"not_specified"</c> when shipping does not apply.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// <c>true</c> to allow the buyer to pick up the shipment at your store.
        /// Only available when <see cref="Mode"/> is <c>"me2"</c>.
        /// </summary>
        public bool? LocalPickup { get; set; }

        /// <summary>
        /// Package dimensions in the format <c>"height x width x length, weight"</c>
        /// (e.g., <c>"30x30x30,500"</c> for 30cm x 30cm x 30cm and 500g).
        /// Only available when <see cref="Mode"/> is <c>"me2"</c>.
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// ID of the default shipping method pre-selected at checkout.
        /// Only available when <see cref="Mode"/> is <c>"me2"</c>.
        /// </summary>
        public string DefaultShippingMethod { get; set; }

        /// <summary>
        /// List of shipping methods offered as free shipping to the buyer.
        /// Only available when <see cref="Mode"/> is <c>"me2"</c>.
        /// </summary>
        /// <seealso cref="PreferenceFreeMethodRequest"/>
        public IList<PreferenceFreeMethodRequest> FreeMethods { get; set; }

        /// <summary>
        /// Fixed shipment cost charged to the buyer.
        /// Only available when <see cref="Mode"/> is <c>"custom"</c>.
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// <c>true</c> to offer free shipping to the buyer.
        /// Only available when <see cref="Mode"/> is <c>"custom"</c>.
        /// </summary>
        public bool? FreeShipping { get; set; }

        /// <summary>
        /// Shipping destination address where the buyer will receive the product.
        /// </summary>
        /// <seealso cref="PreferenceReceiverAddressRequest"/>
        public PreferenceReceiverAddressRequest ReceiverAddress { get; set; }

        /// <summary>
        /// <c>true</c> to enable express shipment for faster delivery.
        /// </summary>
        public bool? ExpressShipment { get; set; }
    }
}
