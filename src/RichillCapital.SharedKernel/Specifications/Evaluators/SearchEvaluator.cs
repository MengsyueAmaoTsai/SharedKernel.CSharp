namespace RichillCapital.SharedKernel.Specifications.Evaluators;

public class SearchEvaluator : IInMemoryEvaluator
{
    private SearchEvaluator()
    {
    }

    public static SearchEvaluator Instance { get; } = new SearchEvaluator();

    public IEnumerable<T> Evaluate<T>(
        IEnumerable<T> query,
        ISpecification<T> specification)
    {
        foreach (var searchGroup in specification.SearchExpressions
            .GroupBy(expression => expression.SearchGroup))
        {
            query = query
                .Where(x => searchGroup
                    .Any(expression => expression.SelectorFunc(x)
                        .Like(expression.SearchTerm)));
        }

        return query;
    }
}