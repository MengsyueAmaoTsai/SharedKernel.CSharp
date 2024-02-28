using RichillCapital.SharedKernel;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

public abstract class MonadTests
{
    protected readonly static int Value = 5;

    protected readonly static Error UnexpectedError = Error.Unexpected("Unexpected error");

    protected static readonly string ValidEmail = "mengsyue.tsai@oultook.com";
    protected static readonly string InvalidEmail = "invalid-email";

    protected static readonly (Func<string, bool> ensure, Error error)[] EmailRules = [
        (email => !string.IsNullOrWhiteSpace(email), Error.Invalid("Email can not be empty ")),
        (email => email.Length < Email.MaxLength, Error.Invalid("Email is too long.")),
        (email => email.Contains('@'), Error.Invalid("Email does not contain '@'.")),
    ];
}