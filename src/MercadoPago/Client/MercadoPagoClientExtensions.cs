namespace MercadoPago.Client
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using MercadoPago.Resource;

    /// <summary>
    /// Extension methods that add lazy auto-pagination to any searchable MercadoPago client.
    ///
    /// Usage:
    /// <code>
    /// var payment = new PaymentClient();
    /// await foreach (var p in payment.SearchAllAsync(new SearchRequest { Filters = ... }))
    /// {
    ///     Console.WriteLine(p.Id);
    /// }
    /// </code>
    /// </summary>
    public static class MercadoPagoClientExtensions
    {
        private const int DefaultPageSize = 100;

        /// <summary>
        /// Returns an <see cref="IAsyncEnumerable{TResource}"/> that lazily fetches all pages
        /// of a <see cref="ResultsResourcesPage{TResource}"/> search result.
        ///
        /// Pages are fetched on demand; iteration stops when the results list is empty or
        /// the accumulated offset reaches <see cref="ResultsPaging.Total"/>.
        /// </summary>
        /// <typeparam name="TResource">The resource type contained in each page.</typeparam>
        /// <param name="searchFn">
        /// An async function that accepts a <see cref="SearchRequest"/> and returns one page.
        /// This is typically the <c>SearchAsync</c> method of a specific client:
        /// <code>client.SearchAsync</code>.
        /// </param>
        /// <param name="baseRequest">
        /// The initial search filters. <c>Offset</c> is managed automatically; do not set it
        /// unless you want to start from a non-zero page.
        /// </param>
        /// <param name="pageSize">Items per page. Defaults to 100.</param>
        /// <param name="cancellationToken">Cancellation token propagated to every page request.</param>
        public static async IAsyncEnumerable<TResource> SearchAllAsync<TResource>(
            Func<SearchRequest, CancellationToken, Task<ResultsResourcesPage<TResource>>> searchFn,
            SearchRequest baseRequest,
            int pageSize = DefaultPageSize,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
            where TResource : IResource, new()
        {
            if (pageSize <= 0) pageSize = DefaultPageSize;

            var offset = baseRequest?.Offset ?? 0;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var request = CloneWithPagination(baseRequest, offset, pageSize);
                var page = await searchFn(request, cancellationToken).ConfigureAwait(false);

                var results = page?.Results;
                if (results == null || results.Count == 0)
                    yield break;

                foreach (var item in results)
                    yield return item;

                offset += results.Count;

                var total = page.Paging?.Total ?? 0;
                if (offset >= total)
                    yield break;
            }
        }

        private static SearchRequest CloneWithPagination(SearchRequest original, int offset, int limit)
        {
            var clone = new SearchRequest
            {
                Offset = offset,
                Limit = limit,
                Filters = original?.Filters != null
                    ? new System.Collections.Generic.Dictionary<string, object>(original.Filters)
                    : null,
            };
            return clone;
        }
    }
}
