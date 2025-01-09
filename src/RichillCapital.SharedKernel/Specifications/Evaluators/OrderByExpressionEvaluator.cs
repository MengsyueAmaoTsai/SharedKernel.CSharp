using RichillCapital.SharedKernel.Specifications.Exceptions;
using RichillCapital.SharedKernel.Specifications.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public class OrderEvaluator : IEvaluator, IInMemoryEvaluator
{
    private OrderEvaluator()
    {
    }

    public static OrderEvaluator Instance { get; } = new OrderEvaluator();

    public bool IsCriteriaEvaluator { get; } = false;

    public IQueryable<T> GetQuery<T>(
        IQueryable<T> query,
        ISpecification<T> specification)
        where T : class
    {
        if (specification.OrderExpressions != null)
        {
            if (specification.OrderExpressions
                .Count(
                    x => x.OrderType == OrderByExpressionType.OrderBy ||
                    x.OrderType == OrderByExpressionType.OrderByDescending) > 1)
            {
                throw new DuplicateOrderChainException();
            }

            IOrderedQueryable<T>? orderedQuery = null;

            foreach (var orderExpression in specification.OrderExpressions)
            {
                if (orderExpression.OrderType == OrderByExpressionType.OrderBy)
                {
                    orderedQuery = query.OrderBy(orderExpression.KeySelector);
                }
                else if (orderExpression.OrderType == OrderByExpressionType.OrderByDescending)
                {
                    orderedQuery = query.OrderByDescending(orderExpression.KeySelector);
                }
                else if (orderExpression.OrderType == OrderByExpressionType.ThenBy)
                {
                    orderedQuery = orderedQuery!.ThenBy(orderExpression.KeySelector);
                }
                else if (orderExpression.OrderType == OrderByExpressionType.ThenByDescending)
                {
                    orderedQuery = orderedQuery!.ThenByDescending(orderExpression.KeySelector);
                }
            }

            if (orderedQuery != null)
            {
                query = orderedQuery;
            }
        }

        return query;
    }

    public IEnumerable<T> Evaluate<T>(
        IEnumerable<T> query,
        ISpecification<T> specification)
    {
        if (specification.OrderExpressions is not null)
        {
            if (specification.OrderExpressions
                .Count(
                    x => x.OrderType == OrderByExpressionType.OrderBy ||
                    x.OrderType == OrderByExpressionType.OrderByDescending) > 1)
            {
                throw new DuplicateOrderChainException();
            }

            IOrderedEnumerable<T>? orderedQuery = null;

            foreach (var orderExpression in specification.OrderExpressions)
            {
                if (orderExpression.OrderType == OrderByExpressionType.OrderBy)
                {
                    orderedQuery = query.OrderBy(orderExpression.KeySelectorFunc);
                }
                else if (orderExpression.OrderType == OrderByExpressionType.OrderByDescending)
                {
                    orderedQuery = query.OrderByDescending(orderExpression.KeySelectorFunc);
                }
                else if (orderExpression.OrderType == OrderByExpressionType.ThenBy)
                {
                    orderedQuery = orderedQuery!.ThenBy(orderExpression.KeySelectorFunc);
                }
                else if (orderExpression.OrderType == OrderByExpressionType.ThenByDescending)
                {
                    orderedQuery = orderedQuery!.ThenByDescending(orderExpression.KeySelectorFunc);
                }
            }

            if (orderedQuery != null)
            {
                query = orderedQuery;
            }
        }

        return query;
    }
}