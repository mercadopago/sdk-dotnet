using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Clauses;

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
            
            return Query(queryModel).Cast<T>();
        }

        private IEnumerable<TResource> Query(QueryModel queryModel)
        {
            var queryParameters = new Dictionary<string, string>();

            void ParseExpression(BinaryExpression binary)
            {
                if (binary.NodeType != ExpressionType.Equal)
                    throw new InvalidOperationException();

                if (!(binary.Left is MemberExpression left))
                    throw new InvalidOperationException();

                if (!(binary.Right is ConstantExpression right))
                    throw new InvalidOperationException();

                var key = left.Member.Name.ToSnakeCase();
                var value = right.Value?.ToString();

                if (!string.IsNullOrEmpty(value))
                    queryParameters.Add(key, value);
            }

            var wheres = 
                queryModel.BodyClauses
                          .OfType<WhereClause>()
                          .ToList();

            foreach (var where in wheres)
            {
                if (!(where.Predicate is BinaryExpression binary))
                    throw new InvalidOperationException();

                ParseExpression(binary);
            }

            return Resource<TResource>.GetList(_apiPath, _useCache, queryParameters);
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