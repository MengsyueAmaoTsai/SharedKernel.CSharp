using RichillCapital.SharedKernel.Monads;
using RichillCapital.SharedKernel.UnitTests.Monads.Common.Objects;

namespace RichillCapital.SharedKernel.UnitTests.Monads.Common;

public abstract class MonadTests
{
    protected static readonly int IntValue = 10;
    protected static readonly Error NotFoundError = Error.NotFound("Not found");
    protected static readonly Error[] ValidationErrors =
    [
        Error.Invalid("Invalid"),
        Error.Invalid("Invalid 2"),
        Error.Invalid("Invalid 3"),
        Error.Invalid("Invalid 4"),
        Error.Invalid("Invalid 5"),
    ];

    protected static int OnError(IEnumerable<Error> _) => 0;

    protected static int OnValue(int value) => value += 10;

    protected static async Task<int> OnErrorAsync(IEnumerable<Error> _) => await Task.FromResult(0);

    protected static async Task<int> OnValueAsync(int value) => await Task.FromResult(value + 10);

    protected static int OnFailure(Error _) => 0;

    protected static int OnSuccess(int value) => value += 10;

    protected static async Task<int> OnFailureAsync(Error _) => await Task.FromResult(0);

    protected static async Task<int> OnSuccessAsync(int value) => await Task.FromResult(value + 10);

    protected static int OnHasValue(int value) => value += 10;

    protected static int OnNoValue() => 0;

    protected static async Task<int> OnHasValueAsync(int value) => await Task.FromResult(value + 10);

    protected static async Task<int> OnNoValueAsync() => await Task.FromResult(0);
}