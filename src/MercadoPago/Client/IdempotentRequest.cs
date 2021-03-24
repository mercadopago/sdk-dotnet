namespace MercadoPago.Client
{
    using System;

    /// <summary>
    /// Class that creates a idempotent key.
    /// </summary>
    public abstract class IdempotentRequest
    {
        /// <summary>
        /// Create a idempotent key.
        /// </summary>
        /// <returns>The idempotent key.</returns>
        public string CreateIdempotencyKey() => Guid.NewGuid().ToString();
    }
}
