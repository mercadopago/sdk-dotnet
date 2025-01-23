using System.Collections.Generic;

namespace MercadoPago.Error
{
    /// <summary>
    /// Cause of the the API error.
    /// </summary>
    public class ApiErrorCause
    {
        /// <summary>
        /// Cause's code.
        /// </summary>
        /// <remarks>
        /// To view possibles codes, access APIs documentation
        /// <a href="https://www.mercadopago.com/developers/en/reference">here</a>.
        /// You can change site language.
        /// </remarks>
        public string Code { get; set; }

        /// <summary>
        /// Cause description.
        /// Some APIs uses <see cref="Description"/> others <see cref="Message"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Cause message.
        /// Some APIs uses <see cref="Description"/> others <see cref="Message"/>.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Details message.
        /// Some APIs uses <see cref="Details"/> others <see cref="Details"/>.
        /// </summary>
        public List<string> Details { get; set; }
    }
}
