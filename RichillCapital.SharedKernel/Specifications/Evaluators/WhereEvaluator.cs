

namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public sealed class WhereEvaluator : IEvaluator, IInMemoryEvaluator
{
    private WhereEvaluator()
    {
    }

    public static WhereEvaluator Instance => new();

    public bool IsCriteriaEvaluator => true;

    public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, Specification<T> specification)
    {
        foreach (var expression in specification.WhereExpressions)
        {
            query = query.Where(expression.PredicateFunc);
        }

        return query;
    }

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, Specification<T> specification)
        where T : class
    {
        foreach (var expression in specification.WhereExpressions)
        {
            query = query.Where(expression.Predicate);
        }

        return query;
    }
}