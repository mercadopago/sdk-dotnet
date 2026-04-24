namespace MercadoPago.Client
{
    using System.Collections.Generic;

    /// <summary>
    /// Base search request containing pagination and arbitrary filter parameters
    /// for MercadoPago Search API endpoints.
    /// For sorting and date-range support, use the derived <see cref="AdvancedSearchRequest"/>.
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// Query-string parameter name for the page size limit (<c>limit</c>).
        /// </summary>
        public const string LimitParam = "limit";

        /// <summary>
        /// Query-string parameter name for the result offset (<c>offset</c>).
        /// </summary>
        public const string OffsetParam = "offset";

        /// <summary>
        /// Maximum number of results to return per page.
        /// When <c>null</c>, the API default page size is used.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Zero-based index of the first result to return, used for cursor-style pagination.
        /// When <c>null</c>, results start from the beginning.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Arbitrary key-value filter parameters appended to the search query string.
        /// Keys correspond to API-defined filterable fields (e.g., <c>"status"</c>, <c>"external_reference"</c>).
        /// Entries in this dictionary take precedence over <see cref="Limit"/> and <see cref="Offset"/>
        /// if the same key is present.
        /// </summary>
        public IDictionary<string, object> Filters { get; set; }

        /// <summary>
        /// Builds a dictionary of query-string parameters by merging <see cref="Filters"/>
        /// with the <see cref="Limit"/> and <see cref="Offset"/> values.
        /// Filter entries are not overwritten by the pagination properties.
        /// </summary>
        /// <returns>A dictionary of parameter names to values ready to be serialized as query-string arguments.</returns>
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
