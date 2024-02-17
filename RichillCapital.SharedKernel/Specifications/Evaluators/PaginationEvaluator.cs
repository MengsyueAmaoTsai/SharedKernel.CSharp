namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public class PaginationEvaluator : IEvaluator, IInMemoryEvaluator
{
    private PaginationEvaluator()
    {
    }

    public static PaginationEvaluator Instance { get; } = new PaginationEvaluator();

    public bool IsCriteriaEvaluator { get; } = false;

    public IQueryable<T> GetQuery<T>(
        IQueryable<T> query,
        ISpecification<T> specification)
        where T : class
    {
        if (specification.Skip is not null && specification.Skip != 0)
        {
            query = query.Skip(specification.Skip.Value);
        }

        if (specification.Take is not null)
        {
            query = query.Take(specification.Take.Value);
        }

        return query;
    }

    public IEnumerable<T> Evaluate<T>(
        IEnumerable<T> query,
        ISpecification<T> specification)
    {
        if (specification.Skip is not null && specification.Skip != 0)
        {
            query = query.Skip(specification.Skip.Value);
        }

        if (specification.Take is not null)
        {
            query = query.Take(specification.Take.Value);
        }

        return query;
    }
}