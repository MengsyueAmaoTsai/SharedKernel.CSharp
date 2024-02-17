namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecificationRepository<T> :
    ISpecificationReadOnlyRepository<T>
    where T : class
{
    Task DeleteRange(Specification<T> specification);
}