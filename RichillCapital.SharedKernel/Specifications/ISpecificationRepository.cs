namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecificationRepository<T> : ISpecificationReadOnlyRepository<T>
{
    Task DeleteRangeAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);
}