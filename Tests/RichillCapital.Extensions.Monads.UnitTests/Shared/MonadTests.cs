using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public abstract class MonadTests
{
    protected readonly static int TestValue = 5;

    protected readonly static Error TestError = Error.Unexpected("Unexpected error");
    protected readonly static List<Error> TestErrors =
    [
        Error.Invalid("Error 1"),
        Error.Invalid("Error 2"),
        Error.Invalid("Error 3"),
        Error.Invalid("Error 4"),
        Error.NotFound("Error 5"),
    ];

    protected static async Task<int> GetTestValueAsync() => await Task.FromResult(TestValue);
    protected static async ValueTask<int> GetTestValueValueTaskAsync() => await new ValueTask<int>(TestValue);

    protected static async Task<ErrorOr<int>> ErrorOrTaskWithValue() => await Task.FromResult(TestValue.ToErrorOr());
    protected static async Task<ErrorOr<int>> ErrorOrTaskWithErrors() => await Task.FromResult(TestErrors.ToErrorOr<int>());

    protected static async Task<Result<int>> ResultTaskWithValue() => await Task.FromResult(TestValue.ToResult());
    protected static async Task<Result<int>> ResultTaskWithError() => await Task.FromResult(TestError.ToResult<int>());

    protected static async Task<Maybe<int>> MaybeTaskWithValue() => await Task.FromResult(TestValue.ToMaybe());
    protected static async Task<Maybe<int>> MaybeTaskWithNull() => await Task.FromResult(Maybe<int>.Null);

    protected static int OnHasValue(int value) => value * 2;
    protected static int OnSuccess(int value) => value * 2;
    protected static int OnSuccess() => 0;
    protected static int OnIsValue(int value) => value * 2;
    protected static int OnIsNull() => 0;
    protected static int OnError(IEnumerable<Error> errors) => errors.Count();
    protected static int OnFailure(Error error) => 0;
}