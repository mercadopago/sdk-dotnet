namespace MercadoPago.Resource.Chargeback
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Represents a chargeback dispute record returned by the MercadoPago API.
    /// Chargebacks are initiated by cardholders through their issuing bank when
    /// they dispute a payment. Use <see cref="Client.Chargeback.ChargebackClient"/>
    /// to retrieve and search chargebacks.
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com.br/developers/en/reference/chargebacks/">here</a>.
    /// </remarks>
    public class Chargeback : IResource
    {
        /// <summary>
        /// Unique identifier of this chargeback.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifier of the payment that originated the chargeback dispute.
        /// </summary>
        public long? PaymentId { get; set; }

        /// <summary>
        /// Current status of the chargeback (e.g. <c>new</c>, <c>in_review</c>,
        /// <c>won</c>, <c>lost</c>).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Amount disputed by the cardholder.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// ISO 4217 currency code of the disputed amount.
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Reason code provided by the card network for the dispute.
        /// </summary>
        public string ReasonId { get; set; }

        /// <summary>
        /// Textual description of the dispute reason.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Date and time when this chargeback was created (UTC).
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Date and time of the last modification to this chargeback (UTC).
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Raw HTTP response returned by the MercadoPago API for the request
        /// that produced this resource.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
