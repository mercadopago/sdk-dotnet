namespace MercadoPago.Client
{
    using System.Collections.Generic;

    /// <summary>
    /// Search APIs parameters.
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// Limit param name.
        /// </summary>
        public const string LimitParam = "limit";

        /// <summary>
        /// Offset param name.
        /// </summary>
        public const string OffsetParam = "offset";

        /// <summary>
        /// Limit of items per page.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Position where starts the search.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Search filter parameters.
        /// </summary>
        public IDictionary<string, object> Filters { get; set; }

        /// <summary>
        /// Create the search params from properties.
        /// </summary>
        /// <returns>The search params.</returns>
        public virtual IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters;
            if (Filters != null)
            {
                parameters = new Dictionary<string, object>(Filters);
            }
            else
            {
                parameters = new Dictionary<string, object>();
            }

            if (!parameters.ContainsKey(LimitParam))
            {
                parameters.Add(LimitParam, Limit);
            }
            if (!parameters.ContainsKey(OffsetParam))
            {
                parameters.Add(OffsetParam, Offset);
            }

            return parameters;
        }
    }
}
