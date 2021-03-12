namespace MercadoPago.Client
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Class with more advanced search parameters.
    /// </summary>
    public class AdvancedSearchRequest : SearchRequest
    {
        /// <summary>
        /// Sort param name.
        /// </summary>
        public const string SortParam = "sort";

        /// <summary>
        /// Criteria param name.
        /// </summary>
        public const string CriteriaParam = "criteria";

        /// <summary>
        /// Range param name.
        /// </summary>
        public const string RangeParam = "range";

        /// <summary>
        /// Begin date param name.
        /// </summary>
        public const string BeginDateParam = "begin_date";

        /// <summary>
        /// End date param name.
        /// </summary>
        public const string EndDateParam = "end_date";

        /// <summary>
        /// Which property to order.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// Order the items <c>desc</c> or <c>asc</c>.
        /// </summary>
        public string Criteria { get; set; }

        /// <summary>
        /// Which property to apply range.
        /// </summary>
        public string Range { get; set; }

        /// <summary>
        /// Begin date of the range.
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// End date of the range.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Create the search params from properties.
        /// </summary>
        /// <returns>The search params.</returns>
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
