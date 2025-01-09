namespace RichillCapital.SharedKernel.Specifications.Validators;

public class WhereExpressionValidator : IValidator
{
    private WhereExpressionValidator()
    {
    }

    public static WhereExpressionValidator Instance { get; } = new();

    public bool IsValid<T>(T entity, ISpecification<T> specification)
    {
        foreach (var info in specification.WhereExpressions)
        {
            if (info.FilterFunc(entity) == false)
            {
                return false;
            }
        }

        return true;
    }
}