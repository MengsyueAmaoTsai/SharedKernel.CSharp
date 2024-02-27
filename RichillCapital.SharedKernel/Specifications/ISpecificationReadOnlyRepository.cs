using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecificationReadOnlyRepository<T>
{
    Task<Maybe<T>> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<Maybe<TResult>> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default);

    Task<Maybe<T>> SingleOrDefaultAsync(ISingleResultSpecification<T> specification, CancellationToken cancellationToken = default);

    Task<Maybe<TResult>> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<T, TResult> specification, CancellationToken cancellationToken = default);

    Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    IAsyncEnumerable<T> AsAsyncEnumerable(ISpecification<T> specification);
}
