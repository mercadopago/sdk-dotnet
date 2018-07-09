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

        public override void VisitResultOperator(ResultOperatorBase resultOperator, QueryModel queryModel, int index)
        {
            if (resultOperator is FirstResultOperator)
            {
                // TODO
                return;
            }

            if (resultOperator is CountResultOperator || resultOperator is LongCountResultOperator)
            {
                // TODO
                return;
            }

            if (resultOperator is TakeResultOperator take)
            {
                if (take.Count.NodeType == ExpressionType.Constant)
                {
                    // TODO
                }
                else
                {
                    throw new NotSupportedException("Currently not supporting methods or variables in the Skip or Take clause.");
                }

                return;
            }

            if (resultOperator is SkipResultOperator skip)
            {
                var exp = skip.Count;

                if (exp.NodeType == ExpressionType.Constant)
                {
                    // TODO
                }
                else
                {
                    throw new NotSupportedException("Currently not supporting methods or variables in the Skip or Take clause.");
                }

                return;
            }

            base.VisitResultOperator(resultOperator, queryModel, index);
        }

        public override void VisitMainFromClause(MainFromClause fromClause, QueryModel queryModel)
        {
            // TODO

            base.VisitMainFromClause(fromClause, queryModel);

            if (fromClause.FromExpression == null)
                return;

            if (!(fromClause.FromExpression is SubQueryExpression subQueryExpression))
                return;

            VisitQueryModel(subQueryExpression.QueryModel);
        }

        public override void VisitWhereClause(WhereClause whereClause, QueryModel queryModel, int index)
        {
            MpQueryWhereExpressionVisitor.GetQueryParameters(QueryParameters, whereClause.Predicate);
        }

        public override void VisitOrderByClause(OrderByClause orderByClause, QueryModel queryModel, int index)
        {
            if (orderByClause.Orderings.Any())
            {
                // TODO
            }

            base.VisitOrderByClause(orderByClause, queryModel, index);
        }

        public override void VisitGroupJoinClause(GroupJoinClause groupJoinClause, QueryModel queryModel, int index)
        {
            throw new NotSupportedException();
        }
    }
}