namespace RichillCapital.SharedKernel.UnitTests.Monads;

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
}