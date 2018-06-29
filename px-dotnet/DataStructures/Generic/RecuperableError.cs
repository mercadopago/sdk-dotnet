using System;
namespace MercadoPago.DataStructures.Generic
{
    public interface RecuperableError
    {
        string Message { get; set; }

        string Error { get; set; }
    }
}
