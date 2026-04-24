using MercadoPago.Client.Common;

namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Type-specific wrapper for payer phone data in payment requests.
    /// Inherits area code and number properties from <see cref="PhoneRequest"/>.
    /// Used by <see cref="PaymentPayerRequest.Phone"/> to represent the payer's
    /// phone contact information within a payment creation flow.
    /// </summary>
    public class PaymentPayerPhoneRequest : PhoneRequest
    {
    }
}