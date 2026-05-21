namespace MercadoPago.Resource.Customer
{
    /// <summary>
    /// Card issuer (bank or financial institution) associated with a
    /// <see cref="CustomerCard"/>.
    /// </summary>
    public class CustomerCardIssuer
    {
        /// <summary>
        /// MercadoPago internal identifier for the card issuer.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Display name of the card issuer (e.g. "Banco Nacion", "Itau").
        /// </summary>
        public string Name { get; set; }
    }
}
