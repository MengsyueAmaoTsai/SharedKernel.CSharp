using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

/// <summary>
/// Represents the result of an operation that can either be successful or a failure.
/// </summary>
public readonly partial record struct Result
{
    private readonly bool _isSuccess;
    private readonly Error _error;

    internal const string AccessErrorOnSuccessMessage = "Can not access error on a successful result";
    internal const string NullErrorMessage = "Error cannot be Error.Null";

    private Result(bool isSuccess, Error error) => (_isSuccess, _error) = (isSuccess, error);

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>A successful result.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Success() => new(true, Error.Null);

    /// <summary>
    /// Creates a failed result with the specified error.
    /// </summary>
    /// <param name="error">The error associated with the failed result.</param>
    /// <returns>A failed result with the specified error.</returns>
    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Failure(Error error)
    {
        if (error == Error.Null)
        {
            throw new ArgumentNullException(nameof(error), NullErrorMessage);
        }

        return new(false, error);
    }

    /// <summary>
    /// Gets a value indicating whether the result is successful.
    /// </summary>
    public bool IsSuccess => _isSuccess;

    /// <summary>
    /// Gets a value indicating whether the result is a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error associated with the result.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when attempting to access the error on a successful result.</exception>
    public Error Error => IsFailure ? _error : throw new InvalidOperationException(AccessErrorOnSuccessMessage);
}
