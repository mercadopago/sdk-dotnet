namespace MercadoPago.Resource.CardToken
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Card Token resource.
    /// </summary>
    public class CardToken : IResource
    {
        /// <summary>
        /// Card token.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Card ID.
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Last updated date.
        /// </summary>
        public DateTime? DateLastUpdated { get; set; }

        /// <summary>
        /// Due date
        /// </summary>
        public DateTime? DateDue { get; set; }

        /// <summary>
        /// If has luhn validation.
        /// </summary>
        public bool? LuhnValidation { get; set; }

        /// <summary>
        /// Live mode.
        /// </summary>
        public bool? LiveMode { get; set; }

        /// <summary>
        /// Require esc.
        /// </summary>
        public bool? RequireEsc { get; set; }

        /// <summary>
        /// Length security code.
        /// </summary>
        public int? SecurityCodeLength { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
