using RichillCapital.SharedKernel.Specifications.Evaluators;

namespace RichillCapital.SharedKernel.Specifications.Validators;

public class SearchValidator : IValidator
{
    private SearchValidator()
    {
    }

    public static SearchValidator Instance { get; } = new SearchValidator();

    public bool IsValid<T>(T entity, ISpecification<T> specification)
    {
        foreach (var searchGroup in specification.SearchExpressions.GroupBy(x => x.SearchGroup))
        {
            if (searchGroup
                .Any(expression => expression
                    .SelectorFunc(entity)
                    .Like(expression.SearchTerm)) == false)
            {
                return false;
            }
        }

        return true;
    }
}