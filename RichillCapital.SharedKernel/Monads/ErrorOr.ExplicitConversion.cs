namespace RichillCapital.SharedKernel.Monads;

public static partial class MaybeExtensions
{
    public static ErrorOr<TValue> ToErrorOr<TValue>(this TValue value) => ErrorOr<TValue>.Is(value);

    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error error) => ErrorOr<TValue>.Is(error);

    public static ErrorOr<TValue> ToErrorOr<TValue>(this List<Error> errors) => ErrorOr<TValue>.Is(errors);

    public static ErrorOr<TValue> ToErrorOr<TValue>(this Error[] errors) => ErrorOr<TValue>.Is(errors);
}