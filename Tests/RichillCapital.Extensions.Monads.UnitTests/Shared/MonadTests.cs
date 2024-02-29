using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public abstract class MonadTests
{
    protected readonly static int Value = 5;

    protected readonly static Error UnexpectedError = Error.Unexpected("Unexpected error");
    protected readonly static Error NotFoundError = Error.NotFound("Not found");
    protected readonly static List<Error> Errors =
    [
        Error.Invalid("Error 1"),
        Error.Invalid("Error 2"),
        Error.Invalid("Error 3"),
        Error.Invalid("Error 4"),
        Error.NotFound("Error 5"),
    ];

    protected static Error ErrorFactory(int value) => Error.Invalid($"Error {value}");

    protected static int OnError(IEnumerable<Error> _) => 0;
    protected static int OnFailure(Error _) => 0;
    protected static int OnNull() => 0;
    protected static int OnValue(int value) => value * 2;
    protected static int OnSuccess(int value) => value * 2;
    protected static int OnHasValue(int value) => value * 2;

    protected static async Task<Maybe<int>> MaybeFactoryTask(int value) =>
        await Task.FromResult(value.ToMaybe()).ConfigureAwait(false);

    protected static async Task<ErrorOr<int>> ErrorOrFactoryTask(int value) =>
        await Task.FromResult(value.ToErrorOr()).ConfigureAwait(false);

    protected static async Task<Result<int>> ResultFactoryTask(int value) =>
        await Task.FromResult(value.ToResult()).ConfigureAwait(false);
}