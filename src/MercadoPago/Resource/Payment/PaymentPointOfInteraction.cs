namespace MercadoPago.Resource.Payment
{
    /// <summary>
    /// Information about where and how the payment interaction occurred,
    /// including the channel type, the originating application, and
    /// transaction-specific data such as QR codes or ticket URLs.
    /// </summary>
    public class PaymentPointOfInteraction
    {
        /// <summary>
        /// Type of point of interaction. Possible values include "PSP" (online checkout),
        /// "IVR", "OPENPLATFORM", "CHECKOUT", among others.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Sub-type providing further detail about the interaction channel
        /// (e.g., specific POS terminal type or checkout variant).
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// Identifier of the entity or resource that this point of interaction
        /// is linked to (e.g., a specific store or application).
        /// </summary>
        public string LinkedTo { get; set; }

        /// <summary>
        /// Information about the application that initiated this payment
        /// interaction, including its name and version.
        /// </summary>
        /// <seealso cref="PaymentApplicationData"/>
        public PaymentApplicationData ApplicationData { get; set; }

        /// <summary>
        /// Transaction-specific data generated at the point of interaction,
        /// including QR codes, ticket URLs, bank info, and subscription details.
        /// </summary>
        /// <seealso cref="PaymentTransactionData"/>
        public PaymentTransactionData TransactionData { get; set; }
    }
}
