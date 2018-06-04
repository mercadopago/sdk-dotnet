using System;
namespace MercadoPago.Common
{
    public enum PaymentMethodDeferredCapture
    {
        /// <summary> This payment method supports authorization and capture operations </summary>
        supported,
        /// <summary> Deferred capture is not available for this payment method </summary>
        unsupported,
        /// <summary> Cash payment methods don't allow deferred capture </summary>
        does_not_apply
    }
}
