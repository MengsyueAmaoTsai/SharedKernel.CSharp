namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecificationRepository<T> : ISpecificationReadOnlyRepository<T>
{
    Task RemoveRange(ISpecification<T> specification, CancellationToken cancellationToken = default);
}