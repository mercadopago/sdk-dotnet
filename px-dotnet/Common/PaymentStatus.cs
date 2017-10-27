using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace MercadoPago.Common
{ 
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentStatus 
    {   
        ///<summary>The user has not yet completed the payment process</summary>
        pending,
        ///<summary>The payment has been approved and accredited</summary>
        approved,
        ///<summary>The payment has been authorized but not captured yet</summary>
        authorized,
        ///<summary>Payment is being reviewed</summary>
        in_process,
        ///<summary>Users have initiated a dispute</summary>
        in_mediation,
        ///<summary>Payment was rejected. The user may retry payment.</summary>
        rejected,
        ///<summary>Payment was cancelled by one of the parties or because time for payment has expired</summary>
        cancelled,
        ///<summary>Payment was refunded to the user</summary>
        refunded,
        ///<summary>Was made a chargeback in the buyer’s credit card</summary>
        charged_back
    }
    
}
