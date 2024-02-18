namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecificationRepository<T> : ISpecificationReadOnlyRepository<T>
{
    void RemoveRange(ISpecification<T> specification);
}