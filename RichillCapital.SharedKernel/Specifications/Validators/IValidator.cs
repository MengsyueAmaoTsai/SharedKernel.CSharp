namespace RichillCapital.SharedKernel.Specifications.Validators;

public interface IValidator
{
    bool IsValid<T>(T entity, ISpecification<T> specification);
}
