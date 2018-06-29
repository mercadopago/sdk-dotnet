using System;
namespace MercadoPago.DataStructures.Generic
{
    public interface RecuperableErrorCause
    {
        string Code { get; set; }

        string Description { get; set; }
    }
}
