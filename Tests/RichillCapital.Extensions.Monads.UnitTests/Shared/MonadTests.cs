using RichillCapital.SharedKernel;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public abstract class MonadTests
{
    protected readonly static int Value = 5;

    protected readonly static Error UnexpectedError = Error.Unexpected("Unexpected error");
    protected readonly static Error NotFoundError = Error.NotFound("Not found");

    protected readonly static List<Error> Errors = new()
    {
        Error.Invalid("Error 1"),
        Error.Invalid("Error 2"),
        Error.Invalid("Error 3"),
        Error.Invalid("Error 4"),
        Error.NotFound("Error 5"),
    };
}