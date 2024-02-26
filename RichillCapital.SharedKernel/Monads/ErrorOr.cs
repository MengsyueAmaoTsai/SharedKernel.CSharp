using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    private static readonly Error IsNotError = Error
        .Unexpected($"ErrorOr<{typeof(TValue)}> is not error");

    private readonly TValue _value;
    private readonly List<Error> _errors;

    private ErrorOr(Error error)
        : this(true, [error], default!)
    {
    }

    private ErrorOr(List<Error> errors)
        : this(true, errors, default!)
    {
    }

    private ErrorOr(Error[] errors)
        : this(true, [.. errors], default!)
    {
    }

    private ErrorOr(TValue value)
        : this(false, [], value)
    {
    }

    private ErrorOr(bool isError, List<Error> errors, TValue value) =>
        (IsError, _errors, _value) = (isError, errors, value);

    public bool IsError { get; private init; }

    public bool IsValue => !IsError;

    public List<Error> Errors =>
        IsError ?
            _errors :
            [IsNotError];

    public List<Error> ErrorsOrEmpty =>
        IsError ?
            _errors :
            new();

    public TValue Value => IsError ?
        throw new InvalidOperationException($"ErrorOr<{typeof(TValue)}> is not value") :
        _value;

    public TValue ValueOrDefault => IsError ?
        default! :
        _value;

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(TValue value) => new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(List<Error> errors) => new(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Is(Error[] errors) => new(errors);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ErrorOr<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            ErrorOr<TValue>.Is(error) :
            ErrorOr<TValue>.Is(value);

    public TResult Match<TResult>(
        Func<IEnumerable<Error>, TResult> onError,
        Func<TValue, TResult> onValue) =>
        IsError ?
            onError(_errors) :
            onValue(_value);

    public async Task<TResult> Match<TResult>(
        Func<IEnumerable<Error>, Task<TResult>> onError,
        Func<TValue, Task<TResult>> onValue) =>
        IsError ?
            await onError(_errors) :
            await onValue(_value);

    public ErrorOr<TValue> Ensure(
        Func<TValue, bool> ensure,
        Error error) =>
        IsError ?
            ErrorOr<TValue>.Is(_errors) :
            ensure(_value) ?
                ErrorOr<TValue>.Is(_value) :
                ErrorOr<TValue>.Is(error);

    public ErrorOr<TValue> Ensure((Func<TValue, bool> predicate, Error error) ensure) =>
        Ensure(ensure.predicate, ensure.error);

    public ErrorOr<TValue> OrElse(TValue value) =>
        IsError ?
            ErrorOr<TValue>.Is(value) :
            ErrorOr<TValue>.Is(_value);

    public ErrorOr<TResult> Map<TResult>(Func<TValue, TResult> map) =>
        IsError ?
            ErrorOr<TResult>.Is(_errors) :
            ErrorOr<TResult>.Is(map(_value));

    public async Task<ErrorOr<TResult>> Then<TResult>(Func<TValue, Task<ErrorOr<TResult>>> errorOrTask)
    {
        if (IsError)
        {
            return ErrorOr<TResult>.Is(_errors.ToArray());
        }

        var errorOrResult = await errorOrTask(Value);

        return ErrorOr<TResult>.Is(errorOrResult.Value);
    }
}