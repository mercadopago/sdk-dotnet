namespace MercadoPago.Client.Order
{
    /// <summary>
    /// Phone class.
    /// </summary>       
    public class OrderPhoneRequest
    {
        /// <summary>
        /// Area Code.
        /// </summary>       
        public string AreaCode { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>       
        public string Number { get; set; }
    }

}