using System;
namespace MercadoPago.Common
{
    public enum CardNumberValidation
    {
        /// <summary> The card number should validate Luhn's algorithm </summary>
        standard,
        /// <summary> There is no algorithm to validate the checksum </summary>
        none
    }
}
