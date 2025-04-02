namespace MercadoPago.Error
{
    using System.Collections.Generic;

    /// <summary>
    /// Response from API when returns an unseccessful HTTP status code.
    /// </summary>
    /// <remarks>
    /// To view possibles errors, access APIs documentation
    /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
    /// You can change site language.
    /// </remarks>
    public class ApiError
    {
        /// <summary>
        /// HTTP status code.
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Error identification.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Errors identification.
        /// </summary>
        public IList<ApiErrorCause> Errors { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error causes.
        /// </summary>
        public IList<ApiErrorCause> Cause { get; set; }
    }
}
