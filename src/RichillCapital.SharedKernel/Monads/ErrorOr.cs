using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace RichillCapital.SharedKernel.Monads
{
    /// <summary>
    /// Represents a type that can hold either a value or a collection of errors.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public readonly partial struct ErrorOr<TValue> : IEquatable<ErrorOr<TValue>>
    {
        internal const string AccessErrorsOnValueMessage = "Cannot access errors on value";
        internal const string AccessValueOnErrorsMessage = "Cannot access value on errors";
        internal const string NullErrorMessage = "Errors cannot contain Error.Null";

        private readonly bool _hasError;
        private readonly List<Error> _errors;
        private readonly TValue _value;

        private ErrorOr(bool hasError, IEnumerable<Error> errors, TValue value)
        {
            _hasError = hasError;
            _errors = new List<Error>(errors);
            _value = value;
        }

        private ErrorOr(TValue value)
            : this(false, Array.Empty<Error>(), value)
        {
        }

        private ErrorOr(IEnumerable<Error> errors)
            : this(true, errors, default!)
        {
        }

        private ErrorOr(Error error)
            : this(true, new Error[] { error }, default!)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this instance has an error.
        /// </summary>
        public bool HasError => _hasError;

        /// <summary>
        /// Gets a value indicating whether this instance has a value.
        /// </summary>
        public bool IsValue => !_hasError;

        /// <summary>
        /// Gets the collection of errors.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when attempting to access errors on a value.</exception>
        public IEnumerable<Error> Errors => _hasError
            ? new List<Error>(_errors)
            : throw new InvalidOperationException(AccessErrorsOnValueMessage);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when attempting to access value on errors.</exception>
        public TValue Value => _hasError
            ? throw new InvalidOperationException(AccessValueOnErrorsMessage)
            : _value;

        /// <summary>
        /// Creates a new <see cref="ErrorOr{TValue}"/> instance with the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A new <see cref="ErrorOr{TValue}"/> instance with the specified value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ErrorOr<TValue> WithValue(TValue value) => new ErrorOr<TValue>(value);

        /// <summary>
        /// Creates a new <see cref="ErrorOr{TValue}"/> instance with the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns>A new <see cref="ErrorOr{TValue}"/> instance with the specified error.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ErrorOr<TValue> WithError(Error error)
        {
            if (error == Error.Null)
            {
                throw new ArgumentNullException(nameof(error), NullErrorMessage);
            }

            return new ErrorOr<TValue>(error);
        }

        /// <summary>
        /// Creates a new <see cref="ErrorOr{TValue}"/> instance with the specified errors.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <returns>A new <see cref="ErrorOr{TValue}"/> instance with the specified errors.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ErrorOr<TValue> WithErrors(IEnumerable<Error> errors)
        {
            if (errors.Contains(Error.Null))
            {
                throw new ArgumentNullException(nameof(errors), NullErrorMessage);
            }

            return new ErrorOr<TValue>(errors);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => _hasError
            ? _errors.GetHashCode()
            : _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is ErrorOr<TValue> other)
            {
                if (IsValue && other.IsValue)
                {
                    return EqualityComparer<TValue>.Default.Equals(Value, other.Value);
                }

                if (HasError && other.HasError)
                {
                    return Errors.SequenceEqual(other.Errors);
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(ErrorOr<TValue> other) => Equals((object)other);

        /// <summary>
        /// Determines whether two <see cref="ErrorOr{TValue}"/> instances are equal.
        /// </summary>
        /// <param name="left">The first <see cref="ErrorOr{TValue}"/> instance.</param>
        /// <param name="right">The second <see cref="ErrorOr{TValue}"/> instance.</param>
        /// <returns><c>true</c> if the instances are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ErrorOr<TValue> left, ErrorOr<TValue> right) =>
            left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="ErrorOr{TValue}"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first <see cref="ErrorOr{TValue}"/> instance.</param>
        /// <param name="right">The second <see cref="ErrorOr{TValue}"/> instance.</param>
        /// <returns><c>true</c> if the instances are not equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ErrorOr<TValue> left, ErrorOr<TValue> right) =>
            !(left == right);
    }
}
