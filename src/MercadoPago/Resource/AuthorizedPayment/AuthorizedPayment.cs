namespace MercadoPago.Resource.AuthorizedPayment
{
    using System;
    using MercadoPago.Http;

    /// <summary>
    /// Authorized Payment resource (also known as Invoice).
    /// </summary>
    /// <remarks>
    /// For more information check the documentation
    /// <a href="https://www.mercadopago.com.br/developers/en/reference/subscriptions/resource/">here</a>
    /// </remarks>
    public class AuthorizedPayment : IResource
    {
        /// <summary>
        /// Unique invoice identifier.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Type of invoice generated based on recurrence.
        /// <list type="bullet">
        ///   <item><c>scheduled</c>: Automatically generated and scheduled by the recurrence engine</item>
        /// </list>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTimeOffset? LastModified { get; set; }

        /// <summary>
        /// Subscription ID for which the invoice was created.
        /// </summary>
        public string PreapprovalId { get; set; }

        /// <summary>
        /// It is a short description that the subscriber will see during the checkout process and in the notifications.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Reference to sync with your system. This is a free text field to help you with your integration to link the entities.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// ID of the currency used in the payment.
        /// <list type="bullet">
        ///   <item><c>ARS</c>: Argentine peso.</item>
        ///   <item><c>BRL</c>: Brazilian real.</item>
        ///   <item><c>CLP</c>: Chilean peso.</item>
        ///   <item><c>MXN</c>: Mexican peso.</item>
        ///   <item><c>COP</c>: Colombian peso.</item>
        ///   <item><c>PEN</c>: Peruvian sol.</item>
        ///   <item><c>UYU</c>: Uruguayan peso.</item>
        /// </list>
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// Amount we will charge on each invoice.
        /// </summary>
        public decimal TransactionAmount { get; set; }

        /// <summary>
        /// Date on which we will try to make the payment.
        /// </summary>
        public DateTimeOffset? DebitDate { get; set; }

        /// <summary>
        /// Status of the invoice.
        /// <list type="bullet">
        ///     <item><c>scheduled</c>: Authorized payment scheduled to collect</item>
        ///     <item><c>processed:</c>: Authorized payment collected or exceeded retries</item>
        ///     <item><c>recycling</c>: Authorized payment in attempt to collect</item>
        ///     <item><c>cancelled</c>: Authorized payment canceled</item>
        /// </list>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// How many times we try to collect the invoice.
        /// </summary>
        public int? RetryAttempt { get; set; }

        /// <summary>
        /// Summarization status of the invoice result in the subscription.
        /// <list type="bullet">
        ///   <item><c>pending</c>: Pending summary in the subscription.</item>
        ///   <item><c>done</c>: Summarized result in the subscription</item>
        /// </list>
        /// </summary>
        public string Summarized { get; set; }

        /// <summary>
        /// Summarization status of the invoice result in the subscription.
        /// <list type="bullet">
        ///   <item><c>pending</c>: Pending summary in the subscription.</item>
        ///   <item><c>done</c>: Summarized result in the subscription</item>
        /// </list>
        /// </summary>
        public AuthorizedPaymentStatus Payment { get; set; }

        /// <summary>
        /// Response from API.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; set; }
    }
}
