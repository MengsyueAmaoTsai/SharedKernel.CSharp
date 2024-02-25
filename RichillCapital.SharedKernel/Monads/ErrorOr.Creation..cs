using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public static ErrorOr<TValue> From(Error[] errors) => new([.. errors]);

    public static ErrorOr<TValue> From(List<Error> errors) => new(errors);

    public static ErrorOr<TValue> From(Error error) => new(error);

    public static ErrorOr<TValue> Is(TValue value) => new(value);
}

public static partial class ErrorOr
{
    public static ErrorOr<TValue> From<TValue>(Error[] errors) => ErrorOr<TValue>.From(errors);

    public static ErrorOr<TValue> From<TValue>(List<Error> errors) => ErrorOr<TValue>.From(errors);

    public static ErrorOr<TValue> From<TValue>(Error error) => ErrorOr<TValue>.From(error);

    public static ErrorOr<TValue> Is<TValue>(TValue value) => ErrorOr<TValue>.Is(value);
}