using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    private readonly TValue _value;
    private readonly Error _error;

    private Result(Error error)
        : this(false, error, default!)
    {
    }

    private Result(TValue value)
        : this(true, Error.Null, value)
    {
    }

    private Result(bool isSuccess, Error error, TValue value) =>
        (IsSuccess, _error, _value) = (isSuccess, error, value);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error => IsSuccess ? Error.Null : _error;

    public TValue Value => IsFailure ?
        throw new InvalidOperationException("Cannot access the value of a failed result.") :
        _value;

    public TValue ValueOrDefault => IsFailure ? default! : _value;

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success(TValue value) => new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Failure(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Ensure(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            Result<TValue>.Failure(error) :
            Result<TValue>.Success(value);

    public TResult Match<TResult>(
        Func<TValue, TResult> onSuccess,
        Func<Error, TResult> onFailure) =>
        IsSuccess ?
            onSuccess(_value) :
            onFailure(_error);

    public async Task<TResult> Match<TResult>(
        Func<TValue, Task<TResult>> onSuccess,
        Func<Error, Task<TResult>> onFailure) =>
        IsSuccess ?
            await onSuccess(_value) :
            await onFailure(_error);

    public Result<TValue> Ensure(
        Func<TValue, bool> ensure,
        Error error) =>
        IsFailure ?
            Result<TValue>.Failure(_error) :
            ensure(_value) ?
                Result<TValue>.Success(_value) :
                Result<TValue>.Failure(error);

    public Result<TValue> Ensure((Func<TValue, bool> predicate, Error error) ensure) =>
        Ensure(ensure.predicate, ensure.error);

    public Result<TValue> OrElse(TValue value) =>
        IsFailure ?
            Result<TValue>.Success(value) :
            Result<TValue>.Success(_value);

    public Result<TResult> Map<TResult>(
        Func<TValue, TResult> map) =>
        IsFailure ?
            Result<TResult>.Failure(_error) :
            Result<TResult>.Success(map(_value));

    public async Task<Result<TResult>> Then<TResult>(Func<TValue, Task<Result<TResult>>> resultTask)
    {
        if (IsFailure)
        {
            return Result<TResult>.Failure(_error);
        }

        var result = await resultTask(Value);

        return Result<TResult>.Success(result.Value);
    }
}

public readonly partial record struct Result
{
    private Result(Error error)
        : this(false, error)
    {
    }

    private Result(bool isSuccess, Error error) =>
        (IsSuccess, Error) = (isSuccess, error);

    public bool IsSuccess { get; private init; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; private init; }

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Success() => new(true, Error.Null);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Failure(Error error) => new(error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Ensure<TValue>(
        TValue value,
        Func<TValue, bool> ensure,
        Error error) =>
        !ensure(value) ?
            Failure(error) :
            Success();
}