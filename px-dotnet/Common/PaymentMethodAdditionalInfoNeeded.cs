using System;
namespace MercadoPago.Common
{
    public enum PaymentMethodAdditionalInfoNeeded
    {
        /// <summary> Identification number of the card owner </summary>
        cardholder_identification_number,
        /// <summary> Identification type of the card owner </summary>
        cardholder_identification_type,
        /// <summary> Name as seen in the card of the card owner </summary>
        cardholder_name,
        /// <summary> Id of the card issuing entity </summary>
        issuer_id
    }
}
