using System.Collections.Generic;

namespace MercadoPago.Error
{
    /// <summary>
    /// Represents a single cause within an <see cref="ApiError"/>, describing one specific
    /// reason why an API request failed.
    /// </summary>
    /// <remarks>
    /// MercadoPago APIs are not fully consistent in which fields they populate. Some endpoints
    /// return the human-readable text in <see cref="Description"/>, others in <see cref="Message"/>,
    /// and some provide additional detail strings in <see cref="Details"/>. Consumers should
    /// check all three when building user-facing error messages.
    /// </remarks>
    public class ApiErrorCause
    {
        /// <summary>
        /// Gets or sets the machine-readable error code for this specific cause (e.g., "invalid_field").
        /// </summary>
        /// <remarks>
        /// For a complete list of possible codes, see the
        /// <a href="https://www.mercadopago.com/developers/en/reference">API reference</a>
        /// (language can be changed on-site).
        /// </remarks>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the human-readable error description for this cause.
        /// </summary>
        /// <remarks>
        /// Some API endpoints populate <see cref="Description"/> while others use
        /// <see cref="Message"/>. Check both when presenting error details.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the human-readable error message for this cause.
        /// </summary>
        /// <remarks>
        /// Some API endpoints populate <see cref="Message"/> while others use
        /// <see cref="Description"/>. Check both when presenting error details.
        /// </remarks>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets additional detail strings that provide further context about this cause.
        /// </summary>
        /// <remarks>
        /// Typically populated by validation-style errors where each entry describes
        /// a specific field-level problem (e.g., "field X must be a positive integer").
        /// </remarks>
        public List<string> Details { get; set; }
    }
}
