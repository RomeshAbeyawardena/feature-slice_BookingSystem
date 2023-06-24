namespace BookingSystem.Extensions;

public static class BoolExtensions
{
    public static T IIf<T>(this bool condition, T trueValue, T falseValue = default!)
    {
        return condition ? trueValue : falseValue;
    }

    public static T IIf<T>(this bool condition, Func<bool, T> trueValue, Func<bool, T> falseValue = default!)
    {
        T falseVal = default!;
        if(falseValue != null)
        {
            falseVal = falseValue(false);
        }

        return IIf(condition, trueValue(true), falseVal);
    }

    public static T IIf<T>(this Func<bool> condition, Func<bool, T> trueValue, Func<bool, T> falseValue = default!)
    {
        return IIf(condition(), trueValue, falseValue);
    }
}
