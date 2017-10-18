using System;
namespace MercadoPago.Common
{ 
    public enum PaymentStatus
    {
        pending,
        approved,
        authorized,
        in_process,
        in_mediation,
        rejected,
        cancelled,
        refunded,
        charged_back
    }
    
}
