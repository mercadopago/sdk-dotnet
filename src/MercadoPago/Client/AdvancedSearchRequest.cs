namespace MercadoPago.Client
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Extended search request that adds sorting, ordering criteria, and date-range filtering
    /// on top of the basic pagination provided by <see cref="SearchRequest"/>.
    /// Used by client methods such as
    /// <see cref="AuthorizedPayment.AuthorizedPaymentClient.SearchAsync"/>
    /// and <see cref="Customer.CustomerClient.SearchAsync"/> to query the MercadoPago Search API.
    /// </summary>
    public class AdvancedSearchRequest : SearchRequest
    {
        /// <summary>
        /// Query-string parameter name for the sort field (<c>sort</c>).
        /// </summary>
        public const string SortParam = "sort";

        /// <summary>
        /// Query-string parameter name for the ordering criteria (<c>criteria</c>).
        /// </summary>
        public const string CriteriaParam = "criteria";

        /// <summary>
        /// Query-string parameter name for the range field (<c>range</c>).
        /// </summary>
        public const string RangeParam = "range";

        /// <summary>
        /// Query-string parameter name for the range start date (<c>begin_date</c>).
        /// </summary>
        public const string BeginDateParam = "begin_date";

        /// <summary>
        /// Query-string parameter name for the range end date (<c>end_date</c>).
        /// </summary>
        public const string EndDateParam = "end_date";

        /// <summary>
        /// Name of the resource property to sort results by (e.g., <c>"date_created"</c>).
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Sort direction. Accepted values are <c>"desc"</c> (descending) or <c>"asc"</c> (ascending).
        /// </summary>
        public string Criteria { get; set; }

        /// <summary>
        /// Name of the resource property on which to apply the date range filter
        /// defined by <see cref="BeginDate"/> and <see cref="EndDate"/>
        /// (e.g., <c>"date_created"</c>, <c>"date_last_updated"</c>).
        /// </summary>
        public string Range { get; set; }

        /// <summary>
        /// Inclusive start date for the range filter specified by <see cref="Range"/>.
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// Inclusive end date for the range filter specified by <see cref="Range"/>.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Builds a dictionary of query-string parameters by merging the base pagination
        /// parameters from <see cref="SearchRequest.GetParameters"/> with sorting and
        /// date-range parameters. Parameters already present in <see cref="SearchRequest.Filters"/>
        /// are not overwritten.
        /// </summary>
        /// <returns>A dictionary of parameter names to values ready to be serialized as query-string arguments.</returns>
        public override IDictionary<string, object> GetParameters()
        {
            IDictionary<string, object> parameters = base.GetParameters();

            if (!parameters.ContainsKey(SortParam))
            {
                parameters.Add(SortParam, Sort);
            }
            if (!parameters.ContainsKey(CriteriaParam))
            {
                parameters.Add(CriteriaParam, Criteria);
            }
            if (!parameters.ContainsKey(RangeParam))
            {
                parameters.Add(RangeParam, Range);
            }
            if (!parameters.ContainsKey(BeginDateParam))
            {
                parameters.Add(BeginDateParam, BeginDate);
            }
            if (!parameters.ContainsKey(EndDateParam))
            {
                parameters.Add(EndDateParam, EndDate);
            }

            return parameters;
        }
    }
}
