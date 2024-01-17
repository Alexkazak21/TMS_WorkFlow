using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic;

public class ComparablePair<T, U> : Pair<T, U>, IComparable<ComparablePair<T, U>> where T : IComparable<T>
                                                                                  where U : IComparable<U>
{                                   
    public ComparablePair(T first, U second) : base(first, second)
    {
        FirstParam = first;
        SecondParam = second;
    }

    public int CompareTo(ComparablePair<T, U>? other)
    {
        if (other == null)
        {
            return 1; // Non-null objects are considered greater than null
        }

        // Compare based on the First property
        if (FirstParam is IComparable<T> comparableT)
        {
            int firstComparison = comparableT.CompareTo(other.FirstParam);
            if (firstComparison != 0)
            {
                return firstComparison;
            }
        }
        else
        {
            throw new InvalidOperationException("Type T must implement IComparable<T> for comparison.");
        }

        // If First properties are equal, compare based on the Second property
        if (SecondParam is IComparable<U> comparableU)
        {
            return comparableU.CompareTo(other.SecondParam);
        }
        else
        {
            throw new InvalidOperationException("Type U must implement IComparable<U> for comparison.");
        }
    }
}

