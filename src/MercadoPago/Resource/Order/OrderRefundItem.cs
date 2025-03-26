using System.Collections.Generic;

namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Refund class.
    /// </summary>
    public class OrderRefundItem
    {
        /// <summary>
        /// Refund ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Transaction ID.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Reference ID.
        /// </summary>
        public string ReferenceId { get; set; }

        /// <summary>
        /// Refund amount.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Refund status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Refund items.
        /// </summary>
        public IList<OrderItems> Items { get; set; }
    }
}
