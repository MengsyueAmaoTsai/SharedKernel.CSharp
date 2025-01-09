namespace RichillCapital.SharedKernel.Specifications.Validators;

public class SpecificationValidator : ISpecificationValidator
{
    private readonly List<IValidator> _validators = [];

    public SpecificationValidator() => _validators.AddRange(
    [
        WhereExpressionValidator.Instance,
        SearchValidator.Instance,
    ]);

    public SpecificationValidator(IEnumerable<IValidator> validators) =>
        _validators.AddRange(validators);

    public static SpecificationValidator Default { get; } = new();

    public virtual bool IsValid<TEntity>(
        TEntity entity,
        ISpecification<TEntity> specification)
    {
        foreach (var partialValidator in _validators)
        {
            if (partialValidator.IsValid(entity, specification) == false)
            {
                return false;
            }
        }

        return true;
    }
}