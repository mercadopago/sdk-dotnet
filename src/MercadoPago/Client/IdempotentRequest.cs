namespace MercadoPago.Client
{
    using System;

    /// <summary>
    /// Abstract base class for API request DTOs that require idempotency protection.
    /// When a subclass of this type is sent through <see cref="MercadoPagoClient{TResource}"/>,
    /// the client automatically generates and attaches an <c>X-Idempotency-Key</c> header
    /// to POST and PUT requests, preventing duplicate operations if the same request is retried.
    /// </summary>
    public abstract class IdempotentRequest
    {
        /// <summary>
        /// Generates a new, unique idempotency key as a GUID string.
        /// Called internally by <see cref="MercadoPagoClient{TResource}"/> before sending
        /// POST or PUT requests that do not already carry an idempotency header.
        /// </summary>
        /// <returns>A new GUID string suitable for use as the <c>X-Idempotency-Key</c> header value.</returns>
        public string CreateIdempotencyKey() => Guid.NewGuid().ToString();
    }
}
