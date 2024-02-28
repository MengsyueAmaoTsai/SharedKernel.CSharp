using RichillCapital.SharedKernel;
using RichillCapital.SharedKernel.Monads;

namespace RichillCapital.Extensions.Monads.UnitTests.Shared;

internal sealed class Email : SingleValueObject<string>
{
    internal const int MaxLength = 100;

    private Email(string value) :
        base(value)
    {
    }

    public static Result<Email> Create(string value) =>
        Result<string>
            .Ensure(value, [
                (email => !string.IsNullOrWhiteSpace(email), Error.Invalid("Email cannot be empty")),
                (email => email.Length < MaxLength, Error.Invalid($"Email cannot be longer than {MaxLength} characters")),
                (email => email.Contains('@'), Error.Invalid("Email should contain @ symbol")),
            ])
            .Then(value => new Email(value));
}

public static class Ext
{
    public static Result<TResult> Then<TValue, TResult>(this Result<TValue> result, Func<TValue, TResult> valueFactory)
    {
        if (result.IsFailure)
        {
            return result.Error.ToResult<TResult>();
        }

        return valueFactory(result.Value).ToResult();
    }
}