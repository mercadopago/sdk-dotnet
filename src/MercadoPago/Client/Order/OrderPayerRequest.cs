namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Payer class.
    /// </summary> 
    public class OrderPayerRequest
    {
        /// <summary>
        /// Payer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Payer's firt name.
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
        public OrderIdentificationRequest Identification { get; set; }

        /// <summary>
        /// Phone information.
        /// </summary>       
        public OrderPhoneRequest Phone { get; set; }

        /// <summary>
        /// Address information.
        /// </summary>       
        public OrderAddressRequest Address { get; set; }

    }

}