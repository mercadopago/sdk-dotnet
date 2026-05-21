namespace MercadoPago.Resource.Payment
{
     /// <summary>
     /// 3D Secure (3DS) authentication information for card payments
     /// that require additional cardholder verification to reduce fraud.
     /// Present when the payment triggers a 3DS challenge flow.
     /// </summary>
     public class PaymentThreeDSInfo
     {
          /// <summary>
          /// URL of the external resource (ACS page) where the cardholder
          /// must complete the 3DS authentication challenge.
          /// </summary>
          public string ExternalResourceUrl { get; set; }

          /// <summary>
          /// Challenge Request (CReq) message used in the EMV 3DS protocol.
          /// This Base64-encoded value must be sent to the ACS (Access Control Server)
          /// to initiate the cardholder authentication challenge.
          /// </summary>
          public string Creq { get; set; }
     }
}