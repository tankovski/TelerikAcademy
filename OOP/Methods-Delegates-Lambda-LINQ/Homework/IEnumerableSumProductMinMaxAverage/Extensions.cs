using System;
using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
    public static decimal Sum<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The list must have at least one element!");
        }
        decimal sum = 0;
        foreach (var item in enumeration)
        {
            sum += Convert.ToDecimal(item);
        }
        return sum;
    }
    public static decimal Average<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The list must have at least one element!");
        }
        decimal sum = 0;
        foreach (var item in enumeration)
        {
            sum += Convert.ToDecimal(item);
        }
        return sum / enumeration.Count();
    }
    public static decimal Product<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The list must have at least one element!");
        }
        decimal sum = 1;
        foreach (var item in enumeration)
        {
            sum *= Convert.ToDecimal(item);
        }
        return sum;
    }
    public static decimal Min<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The list must have at least one element!");
        }
        decimal dec = decimal.MaxValue;
        foreach (var item in enumeration)
        {
            if (Convert.ToDecimal(item) < dec)
            {
                dec = Convert.ToDecimal(item);
            }
        }
        return dec;
    }
    public static decimal Max<T>(this IEnumerable<T> enumeration)
    {
        if (enumeration.Count() == 0)
        {
            throw new ArgumentException("The list must have at least one element!");
        }
        decimal dec = decimal.MinValue;
        foreach (var item in enumeration)
        {
            if (Convert.ToDecimal(item) > dec)
            {
                dec = Convert.ToDecimal(item);
            }
        }
        return dec;
    }
}

