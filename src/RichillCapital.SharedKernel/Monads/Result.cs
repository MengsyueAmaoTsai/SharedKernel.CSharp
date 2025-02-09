using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct Result
{
    private readonly bool _isSuccess;
    private readonly Error _error;

    internal const string AccessErrorOnSuccessMessage = "Can not access error on a successful result";
    internal const string NullErrorMessage = "Error cannot be Error.Null";

    private Result(bool isSuccess, Error error) => (_isSuccess, _error) = (isSuccess, error);

    [Pure]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result Success() => new(true, Error.Null);

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

    public bool IsSuccess => _isSuccess;
    public bool IsFailure => !IsSuccess;
    public Error Error => IsFailure ? _error : throw new InvalidOperationException(AccessErrorOnSuccessMessage);
}
