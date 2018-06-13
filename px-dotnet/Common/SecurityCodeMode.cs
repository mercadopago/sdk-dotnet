using System;
namespace MercadoPago.Common
{
    public enum SecurityCodeMode
    {
        /// <summary> The security code should be given to process the payment </summary>
        mandatory,
        /// <summary> A payment could be issued without the security code </summary>
        optional
    }
}
