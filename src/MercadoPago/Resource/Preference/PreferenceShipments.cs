namespace MercadoPago.Resource.Preference
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the shipping configuration for a <see cref="Preference"/>,
    /// including the shipping mode, cost, free shipping methods, and the delivery address.
    /// </summary>
    public class PreferenceShipments
    {
        /// <summary>
        /// Shipping mode that determines how shipping is handled.
        /// Use <c>me2</c> for MercadoEnvios (managed shipping), <c>custom</c> for seller-managed shipping,
        /// or <c>not_specified</c> when shipping is not applicable.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Whether the buyer has the option to pick up the shipment at the seller's store.
        /// Only applicable when <see cref="Mode"/> is <c>me2</c>.
        /// </summary>
        public bool? LocalPickup { get; set; }

        /// <summary>
        /// Package dimensions in the format "width x height x length, weight"
        /// (e.g., "30x30x30,500" for 30cm x 30cm x 30cm, 500g).
        /// Only applicable when <see cref="Mode"/> is <c>me2</c>.
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// Identifier of the default shipping method pre-selected in the checkout.
        /// Only applicable when <see cref="Mode"/> is <c>me2</c>.
        /// </summary>
        public string DefaultShippingMethod { get; set; }

        /// <summary>
        /// List of shipping methods offered as free shipping to the buyer.
        /// Only applicable when <see cref="Mode"/> is <c>me2</c>.
        /// </summary>
        public IList<PreferenceFreeMethod> FreeMethods { get; set; }

        /// <summary>
        /// Fixed shipping cost defined by the seller, in the preference currency.
        /// Only applicable when <see cref="Mode"/> is <c>custom</c>.
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// Indicates whether shipping is free for the buyer.
        /// Only applicable when <see cref="Mode"/> is <c>custom</c>.
        /// </summary>
        public bool? FreeShipping { get; set; }

        /// <summary>
        /// Address where the purchased items will be delivered.
        /// </summary>
        public PreferenceReceiverAddress ReceiverAddress { get; set; }

        /// <summary>
        /// Indicates whether express (expedited) shipping should be used for this preference.
        /// </summary>
        public bool? ExpressShipment { get; set; }
    }
}
