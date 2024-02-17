namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public interface IEvaluator
{
    bool IsCriteriaEvaluator { get; }

    IQueryable<T> GetQuery<T>(IQueryable<T> query, Specification<T> specification)
        where T : class;
}