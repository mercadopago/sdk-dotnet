using System;
using System.Collections.Generic;
using System.Linq;
using Remotion.Linq;

namespace MercadoPago.Core.Linq
{
    internal class MpQueryExecutor<TResource> : IQueryExecutor where TResource: ResourceBase, new()
    {
        private readonly string _apiPath;
        private readonly bool _useCache;

        public MpQueryExecutor(string apiPath, bool useCache = false)
        {
            _apiPath = apiPath;
            _useCache = useCache;
        }

        public IEnumerable<T> ExecuteCollection<T>(QueryModel queryModel)
        {
            if (typeof(T) != typeof(TResource))
                throw new InvalidOperationException();

            var queryParameters = MpQueryModelVisitor.GetQueryParameters(queryModel);

            return 
                Resource<TResource>.GetList(_apiPath, _useCache, queryParameters)
                                   .Cast<T>();
        }

        public T ExecuteSingle<T>(QueryModel queryModel, bool returnDefaultWhenEmpty)
        {
            var sequence = ExecuteCollection<T>(queryModel);

            return returnDefaultWhenEmpty ? sequence.SingleOrDefault() : sequence.Single();
        }

        public T ExecuteScalar<T>(QueryModel queryModel)
        {
            throw new NotImplementedException();
        }
    }
}