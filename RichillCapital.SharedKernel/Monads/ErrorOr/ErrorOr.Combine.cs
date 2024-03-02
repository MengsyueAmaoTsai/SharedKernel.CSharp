namespace RichillCapital.SharedKernel.Monads;

public readonly partial record struct ErrorOr<TValue>
{
    public static ErrorOr<TValue> Combine(params ErrorOr<TValue>[] errorOrs)
    {
        if (errorOrs.Any(errorOr => errorOr.HasError))
        {
            return errorOrs
                .Where(errorOr => errorOr.HasError)
                .SelectMany(errorOr => errorOr.Errors)
                .Distinct()
                .ToArray()
                .ToErrorOr<TValue>();
        }

        return errorOrs.Last().Value.ToErrorOr();
    }

    public static ErrorOr<(T1, T2)> Combine<T1, T2>(ErrorOr<T1> errorOr1, ErrorOr<T2> errorOr2)
    {
        if (errorOr1.HasError)
        {
            return errorOr1.Errors.ToErrorOr<(T1, T2)>();
        }

        if (errorOr2.HasError)
        {
            return errorOr2.Errors.ToErrorOr<(T1, T2)>();
        }

        return (errorOr1.Value, errorOr2.Value).ToErrorOr();
    }

    public static ErrorOr<(T1, T2, T3)> Combine<T1, T2, T3>(ErrorOr<T1> errorOr1, ErrorOr<T2> errorOr2, ErrorOr<T3> errorOr3)
    {
        var errorOrs = ErrorOr<(T1, T2)>
            .Combine(errorOr1, errorOr2);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3)>();
        }

        if (errorOr3.HasError)
        {
            return errorOr3.Errors.ToErrorOr<(T1, T2, T3)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value).ToErrorOr();
    }

    public static ErrorOr<(T1, T2, T3, T4)> Combine<T1, T2, T3, T4>(ErrorOr<T1> errorOr1, ErrorOr<T2> errorOr2, ErrorOr<T3> errorOr3, ErrorOr<T4> errorOr4)
    {
        var errorOrs = ErrorOr<(T1, T2, T3)>
            .Combine(errorOr1, errorOr2, errorOr3);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4)>();
        }

        if (errorOr4.HasError)
        {
            return errorOr4.Errors.ToErrorOr<(T1, T2, T3, T4)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value).ToErrorOr();
    }

    public static ErrorOr<(T1, T2, T3, T4, T5)> Combine<T1, T2, T3, T4, T5>(ErrorOr<T1> errorOr1, ErrorOr<T2> errorOr2, ErrorOr<T3> errorOr3, ErrorOr<T4> errorOr4, ErrorOr<T5> errorOr5)
    {
        var errorOrs = ErrorOr<(T1, T2, T3, T4)>
            .Combine(errorOr1, errorOr2, errorOr3, errorOr4);

        if (errorOrs.HasError)
        {
            return errorOrs.Errors.ToErrorOr<(T1, T2, T3, T4, T5)>();
        }

        if (errorOr5.HasError)
        {
            return errorOr5.Errors.ToErrorOr<(T1, T2, T3, T4, T5)>();
        }

        return (errorOr1.Value, errorOr2.Value, errorOr3.Value, errorOr4.Value, errorOr5.Value).ToErrorOr();
    }
}