namespace MercadoPago.Resource.Order
{
    /// <summary>
    /// Payer class.
    /// </summary>
    public class OrderPayer
    {
        /// <summary>
        /// Payer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Payer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer ID.
        /// </summary>
        public string CustomerId { get; set; }
    
        /// <summary>
        /// Identification information.
        /// </summary>
        public OrderIdentification Identification { get; set; }

        /// <summary>
        /// Phone information.
        /// </summary>
        public OrderPhone Phone { get; set; }

        /// <summary>
        /// Address information.
        /// </summary>
        public OrderAddress Address { get; set; }
    }
}