using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

/// <summary>
/// Represents a result that can either be a success or a failure.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public readonly partial record struct Result<TValue>
{
    internal const string AccessErrorOnSuccessMessage = "Cannot access error on success result";
    internal const string AccessValueOnFailureMessage = "Cannot access value on failure result";

    private readonly bool _isSuccess;
    private readonly Error _error;
    private readonly TValue _value;

    private Result(bool isSuccess, Error error, TValue value)
    {
        _isSuccess = isSuccess;
        _error = error;
        _value = value;
    }

    private Result(Error error)
        : this(false, error, default!)
    {
    }

    private Result(TValue value)
        : this(true, Error.Null, value)
    {
    }

    /// <summary>
    /// Gets a value indicating whether the result is a success.
    /// </summary>
    public bool IsSuccess => _isSuccess;

    /// <summary>
    /// Gets a value indicating whether the result is a failure.
    /// </summary>
    public bool IsFailure => !_isSuccess;

    /// <summary>
    /// Gets the error associated with the failure result.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when trying to access the error on a success result.</exception>
    public Error Error => !_isSuccess ?
        _error :
        throw new InvalidOperationException(AccessErrorOnSuccessMessage);

    /// <summary>
    /// Gets the value associated with the success result.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when trying to access the value on a failure result.</exception>
    public TValue Value =>
        _isSuccess ?
            _value :
            throw new InvalidOperationException(AccessValueOnFailureMessage);

    /// <summary>
    /// Creates a success result with the specified value.
    /// </summary>
    /// <param name="value">The value of the success result.</param>
    /// <returns>A success result with the specified value.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Success(TValue value) =>
        new(value);

    /// <summary>
    /// Creates a failure result with the specified error.
    /// </summary>
    /// <param name="error">The error of the failure result.</param>
    /// <returns>A failure result with the specified error.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TValue> Failure(Error error) => new(error);
}
