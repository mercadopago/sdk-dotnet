namespace MercadoPago.Resource.Customer
{
    using MercadoPago.Resource.Common;

    /// <summary>
    /// Extended identification for a cardholder, inheriting
    /// <see cref="Identification.Type"/> and <see cref="Identification.Number"/>
    /// from <see cref="Identification"/> and adding a <see cref="Subtype"/>
    /// for finer classification.
    /// </summary>
    public class CustomerCardCardholderIdentification : Identification
    {
        /// <summary>
        /// Optional subtype that further classifies the identification
        /// document (e.g. distinguishing natural person from legal entity).
        /// </summary>
        public string Subtype { get; set; }
    }
}
