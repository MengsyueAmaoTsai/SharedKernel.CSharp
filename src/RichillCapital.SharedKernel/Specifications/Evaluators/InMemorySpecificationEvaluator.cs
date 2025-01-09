using RichillCapital.SharedKernel.Specifications.Exceptions;

namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public class InMemorySpecificationEvaluator : IInMemorySpecificationEvaluator
{
    public InMemorySpecificationEvaluator() =>
        Evaluators.AddRange(
        [
            WhereEvaluator.Instance,
            SearchEvaluator.Instance,
            OrderEvaluator.Instance,
            PaginationEvaluator.Instance,
        ]);

    public InMemorySpecificationEvaluator(IEnumerable<IInMemoryEvaluator> evaluators) =>
        Evaluators.AddRange(evaluators);

    public static InMemorySpecificationEvaluator Default { get; } = new();

    protected List<IInMemoryEvaluator> Evaluators { get; } = [];

    public virtual IEnumerable<TResult> Evaluate<T, TResult>(
        IEnumerable<T> source,
        ISpecification<T, TResult> specification)
    {
        if (specification.Selector is null && specification.SelectorMany is null)
        {
            throw new SelectorNotFoundException();
        }

        if (specification.Selector is not null && specification.SelectorMany is not null)
        {
            throw new ConcurrentSelectorsException();
        }

        var baseQuery = Evaluate(source, (ISpecification<T>)specification);

        var resultQuery = specification.Selector != null ?
            baseQuery.Select(specification.Selector.Compile()) :
            baseQuery.SelectMany(specification.SelectorMany!.Compile());

        return specification.PostProcessingAction == null ?
            resultQuery :
            specification.PostProcessingAction(resultQuery);
    }

    public virtual IEnumerable<T> Evaluate<T>(
        IEnumerable<T> source,
        ISpecification<T> specification)
    {
        foreach (var evaluator in Evaluators)
        {
            source = evaluator.Evaluate(source, specification);
        }

        return specification.PostProcessingAction == null ?
            source :
            specification.PostProcessingAction(source);
    }
}