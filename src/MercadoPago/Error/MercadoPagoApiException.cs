namespace MercadoPago.Error
{
    using System;
    using System.Text;
    using MercadoPago.Http;

    /// <summary>
    /// Exception thrown when the API response is unsuccessful.
    /// </summary>
    public class MercadoPagoApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoApiException"/> class.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        /// <param name="response">Response from API.</param>
        public MercadoPagoApiException(string message, MercadoPagoResponse response)
            : base(message)
        {
            ApiResponse = response;
            StatusCode = response?.StatusCode;
        }

        /// <summary>
        /// Exception message.
        /// </summary>
        public override string Message
        {
            get
            {
                var messageSb = new StringBuilder();
                messageSb.Append(base.Message);
                if (StatusCode.HasValue)
                {
                    messageSb.Append($" | Status code: {StatusCode}");
                }
                if (!string.IsNullOrWhiteSpace(ApiError?.Message))
                {
                    messageSb.Append($" | API message: {ApiError.Message}");
                }
                return messageSb.ToString();
            }
        }

        /// <summary>
        /// Status code returned by the API.
        /// </summary>
        public int? StatusCode { get; }

        /// <summary>
        /// The error response from API.
        /// </summary>
        public ApiError ApiError { get; set; }

        /// <summary>
        /// Api response that caused the exception.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; }
    }
}
