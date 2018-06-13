using System;
namespace MercadoPago.Common
{
    public enum PaymentMethodStatus
    {
        /// <summary> Available for use </summary>
        active,
        /// <summary> Decommissioned, we don't support it anymore </summary>
        deactive,
        /// <summary> Unavailable for use, possible interruption of the service </summary>
        temporally_deactive
    }
}
