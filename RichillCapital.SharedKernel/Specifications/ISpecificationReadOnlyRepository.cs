using RichillCapital.SharedKernel.Monad;

namespace RichillCapital.SharedKernel.Specifications;

public interface ISpecificationReadOnlyRepository<T>
    where T : class
{
    Task<Maybe<T>> FirstOrDefaultAsync(Specification<T> specification, CancellationToken cancellationToken = default);

    Task<Maybe<TResult>> FirstOrDefaultAsync<TResult>(Specification<T, TResult> specification, CancellationToken cancellationToken = default);

    Task<Maybe<T>> SingleOrDefaultAsync(Specification<T> specification, CancellationToken cancellationToken = default);

    Task<Maybe<TResult>> SingleOrDefaultAsync<TResult>(Specification<T, TResult> specification, CancellationToken cancellationToken = default);

    Task<List<T>> ListAsync(Specification<T> specification, CancellationToken cancellationToken = default);

    Task<List<TResult>> ListAsync<TResult>(Specification<T, TResult> specification, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Specification<T> specification, CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(Specification<T> specification, CancellationToken cancellationToken = default);

    IAsyncEnumerable<T> AsAsyncEnumerable(Specification<T> specification, CancellationToken cancellationToken = default);
}