namespace MercadoPago.Resource.Order
{
    using System.Collections.Generic;

    /// <summary>
    /// OrderChargeback class.
    /// </summary>
    public class OrderChargeback
    {
        /// <summary>
        /// Chargeback ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Transaction ID.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Case ID.
        /// </summary>
        public string CaseId { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// References.
        /// </summary>
        public IList<string> References { get; set; }
    }
}
