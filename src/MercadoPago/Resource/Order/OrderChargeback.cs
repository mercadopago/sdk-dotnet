namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a chargeback dispute within an <see cref="OrderTransaction"/>, initiated when a payer
    /// contests a charge through their financial institution.
    /// </summary>
    public class OrderChargeback
    {
        /// <summary>
        /// Unique identifier assigned to this chargeback by MercadoPago.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identifier of the original <see cref="OrderPayment"/> transaction that is being disputed.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Case identifier assigned by the financial institution or payment network for tracking the dispute.
        /// </summary>
        public string CaseId { get; set; }

        /// <summary>
        /// Current status of the chargeback dispute (e.g., "opened", "closed", "review").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// List of reference identifiers associated with this chargeback, used for cross-referencing with external systems.
        /// </summary>
        public IList<string> References { get; set; }
    }
}
