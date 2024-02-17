

using RichillCapital.SharedKernel.Specifications.Exceptions;
using RichillCapital.SharedKernel.Specifications.Expressions;

namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public sealed class OrderByEvaluator : IEvaluator, IInMemoryEvaluator
{
    private OrderByEvaluator()
    {
    }

    public static OrderByEvaluator Instance => new();

    public bool IsCriteriaEvaluator => false;

    public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, Specification<T> specification)
    {
        if (specification.OrderByExpressions is null)
        {
            return query;
        }

        if (specification.OrderByExpressions
            .Count(
                x => x.OrderByType == OrderByType.OrderBy ||
                x.OrderByType == OrderByType.OrderByDescending) > 1)
        {
            throw new DuplicateOrderChainException();
        }

        IOrderedEnumerable<T>? orderedQuery = null;

        foreach (var expression in specification.OrderByExpressions)
        {
            if (expression.OrderByType == OrderByType.OrderBy)
            {
                orderedQuery = query.OrderBy(expression.KeySelectorFunc);
            }
            else if (expression.OrderByType == OrderByType.OrderByDescending)
            {
                orderedQuery = query.OrderByDescending(expression.KeySelectorFunc);
            }
            else if (expression.OrderByType == OrderByType.ThenBy)
            {
                orderedQuery = orderedQuery!.ThenBy(expression.KeySelectorFunc);
            }
            else if (expression.OrderByType == OrderByType.ThenByDescending)
            {
                orderedQuery = orderedQuery!.ThenByDescending(expression.KeySelectorFunc);
            }
        }

        if (orderedQuery is not null)
        {
            query = orderedQuery;
        }

        return query;
    }

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, Specification<T> specification)
        where T : class
    {
        if (specification.OrderByExpressions is null)
        {
            return query;
        }

        if (specification.OrderByExpressions
            .Count(
                x => x.OrderByType == OrderByType.OrderBy ||
                x.OrderByType == OrderByType.OrderByDescending) > 1)
        {
            throw new DuplicateOrderChainException();
        }

        IOrderedQueryable<T>? orderedQuery = null;

        foreach (var orderExpression in specification.OrderByExpressions)
        {
            if (orderExpression.OrderByType == OrderByType.OrderBy)
            {
                orderedQuery = query.OrderBy(orderExpression.KeySelector);
            }
            else if (orderExpression.OrderByType == OrderByType.OrderByDescending)
            {
                orderedQuery = query.OrderByDescending(orderExpression.KeySelector);
            }
            else if (orderExpression.OrderByType == OrderByType.ThenBy)
            {
                orderedQuery = orderedQuery!.ThenBy(orderExpression.KeySelector);
            }
            else if (orderExpression.OrderByType == OrderByType.ThenByDescending)
            {
                orderedQuery = orderedQuery!.ThenByDescending(orderExpression.KeySelector);
            }
        }

        if (orderedQuery is not null)
        {
            query = orderedQuery;
        }

        return query;
    }
}