namespace MercadoPago.Error
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the structured error body returned by MercadoPago APIs when a request
    /// results in an unsuccessful HTTP status code.
    /// </summary>
    /// <remarks>
    /// This class is deserialized from the JSON response body and attached to
    /// <see cref="MercadoPagoApiException.ApiError"/>. Different API endpoints may populate
    /// either <see cref="Cause"/> or <see cref="Errors"/> (or both) depending on the
    /// endpoint version. For a full catalog of possible error codes, see the
    /// <a href="https://www.mercadopago.com/developers/en/reference">API reference</a>
    /// (language can be changed on-site).
    /// </remarks>
    public class ApiError
    {
        /// <summary>
        /// Gets or sets the HTTP status code echoed in the error response body (e.g., 400, 404, 500).
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Gets or sets the machine-readable error identifier (e.g., "invalid_token", "not_found").
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the detailed list of individual error causes returned by newer API endpoints.
        /// </summary>
        /// <remarks>
        /// Some API versions use <see cref="Errors"/> while others use <see cref="Cause"/>
        /// to report individual failure reasons. Check both when inspecting errors.
        /// </remarks>
        public IList<ApiErrorCause> Errors { get; set; }

        /// <summary>
        /// Gets or sets a human-readable description of the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the list of individual error causes returned by legacy API endpoints.
        /// </summary>
        /// <remarks>
        /// Some API versions use <see cref="Cause"/> while others use <see cref="Errors"/>
        /// to report individual failure reasons. Check both when inspecting errors.
        /// </remarks>
        public IList<ApiErrorCause> Cause { get; set; }
    }
}
