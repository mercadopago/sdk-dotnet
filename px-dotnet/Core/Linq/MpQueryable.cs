using System.Linq;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Parsing.Structure;

namespace MercadoPago.Core.Linq
{
    internal class MpQueryable<T> : QueryableBase<T> where T: ResourceBase, new()
    {
        
        public MpQueryable(string apiPath, bool useCache = false): base(QueryParser.CreateDefault(), new MpQueryExecutor<T>(apiPath, useCache))
        {
        }

        // No quitar constructores. Los necesita ReLinq.
        public MpQueryable(IQueryParser queryParser, IQueryExecutor executor)
            : base(new DefaultQueryProvider(typeof(MpQueryable<>), queryParser, executor))
        {
        }

        public MpQueryable(IQueryProvider provider, Expression expression)
            : base(provider, expression)
        {
        }
    }
}