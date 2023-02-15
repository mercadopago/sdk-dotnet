namespace MercadoPago.Resource.Payment
{
     /// <summary>
     /// 3DS
     /// </summary>
     public class PaymentThreeDSInfo
     {
          /// <summary>
          /// External Resource Url.
          /// </summary>
          public string ExternalResourceUrl { get; set; }

          /// <summary>
          /// CReq.
          /// </summary>
          public string Creq { get; set; }
     }
}