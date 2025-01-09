namespace RichillCapital.SharedKernel.Specifications.Validators;

public interface ISpecificationValidator
{
    bool IsValid<TEntity>(TEntity entity, ISpecification<TEntity> specification);
}