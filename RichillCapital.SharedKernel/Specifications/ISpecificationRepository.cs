namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecificationRepository<T>
{
    Task DeleteRangeAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
}