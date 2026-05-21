namespace MercadoPago.Error
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MercadoPago.Http;

    /// <summary>
    /// Exception thrown when a MercadoPago API request returns a non-success HTTP status code.
    /// </summary>
    /// <remarks>
    /// Carries the full <see cref="MercadoPagoResponse"/> and, when available, a deserialized
    /// <see cref="Error.ApiError"/> with structured error details. The <see cref="Message"/>
    /// property is built dynamically by concatenating the status code, API message, and any
    /// nested error details for convenient logging.
    /// </remarks>
    public class MercadoPagoApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MercadoPagoApiException"/> class.
        /// </summary>
        /// <param name="message">A summary message describing the failure context.</param>
        /// <param name="response">
        /// The raw <see cref="MercadoPagoResponse"/> received from the API, or <c>null</c>
        /// if no response was received.
        /// </param>
        public MercadoPagoApiException(string message, MercadoPagoResponse response)
            : base(message)
        {
            ApiResponse = response;
            StatusCode = response?.StatusCode;
        }

        /// <summary>
        /// Gets a composite message that includes the base message, HTTP status code,
        /// API error message, and any nested error details or messages.
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

                if (ApiError?.Errors != null && ApiError.Errors.Count > 0)
                {
                    var messageDetails = new List<string>();
                    var message = new List<string>();
                    foreach (var error in ApiError.Errors)
                    {
                        if (error.Details != null && error.Details.Count > 0)
                        {
                            foreach (var detail in error.Details)
                            {
                                messageDetails.Add(detail);
                            }
                        }

                        if (error.Message != null) {
                            var errorMessage = string.Join("| ", error.Message);
                            messageSb.Append($" | API message error: {errorMessage}");
                        }
                    }

                    if (messageDetails.Count > 0)
                    {
                        var detailsString = string.Join("| ", messageDetails);
                        messageSb.Append($" | API message details: {detailsString}");
                    }
                }

                return messageSb.ToString();
            }
        }

        /// <summary>
        /// Gets the HTTP status code returned by the API (e.g., 400, 401, 404, 500), or <c>null</c> if no response was received.
        /// </summary>
        public int? StatusCode { get; }

        /// <summary>
        /// Gets or sets the deserialized <see cref="Error.ApiError"/> containing structured error
        /// details such as error codes, causes, and messages from the API response body.
        /// </summary>
        public ApiError ApiError { get; set; }

        /// <summary>
        /// Gets the raw <see cref="MercadoPagoResponse"/> that triggered this exception, including
        /// the full response body, headers, and status code.
        /// </summary>
        public MercadoPagoResponse ApiResponse { get; }
    }
}
