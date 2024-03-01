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

    protected int OnNull() => 0;
    protected int OnValue(int value) => value * 2;
}