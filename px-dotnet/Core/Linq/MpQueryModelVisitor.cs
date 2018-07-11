using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Remotion.Linq;
using Remotion.Linq.Clauses;
using Remotion.Linq.Clauses.Expressions;
using Remotion.Linq.Clauses.ResultOperators;

namespace MercadoPago.Core.Linq
{
    internal class MpQueryModelVisitor : QueryModelVisitorBase
    {
        public Dictionary<string, string> QueryParameters { get; } = new Dictionary<string, string>();

        public static Dictionary<string, string> GetQueryParameters(QueryModel queryModel)
        {
            var visitor = new MpQueryModelVisitor();
            visitor.VisitQueryModel(queryModel);
            return visitor.QueryParameters;
        }

        public override void VisitQueryModel(QueryModel queryModel)
        {
            queryModel.SelectClause.Accept(this, queryModel);
            queryModel.MainFromClause.Accept(this, queryModel);
            VisitBodyClauses(queryModel.BodyClauses, queryModel);
            VisitResultOperators(queryModel.ResultOperators, queryModel);
        }

        public override void VisitWhereClause(WhereClause whereClause, QueryModel queryModel, int index)
        {
            MpQueryWhereExpressionVisitor.GetQueryParameters(QueryParameters, whereClause.Predicate);
        }

        public override void VisitGroupJoinClause(GroupJoinClause groupJoinClause, QueryModel queryModel, int index)
        {
            throw new NotSupportedException();
        }
    }
}