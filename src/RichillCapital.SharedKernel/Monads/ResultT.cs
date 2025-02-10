using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result<TValue>
{
    private readonly bool _isSuccess;
    private readonly Error _error;
    private readonly TValue _value;

    private Result(bool isSuccess, Error error, TValue value)
    {
        _isSuccess = isSuccess;
        _error = error;
        _value = value;
    }

    private Result(TValue value) =>
        (_isSuccess, _error, _value) = (true, Error.Null, value);

    private Result(Error error) =>
        (_isSuccess, _error, _value) = (false, error, default!);

    public bool IsSuccess => _isSuccess;
    public bool IsFailure => !_isSuccess;

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success(TValue value) =>
        new(value);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Failure(Error error) => new(error);
}
