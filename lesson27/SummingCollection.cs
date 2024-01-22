using System.Collections;
using System.Numerics;


namespace CustomCollection;

public class SummingCollection<TSource> : IEnumerable<TSource> where TSource : INumberBase<TSource> 
{
    private List<TSource> sum = new();

    public void AddElement(TSource element)
    {
        sum.Add(element);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<TSource> GetEnumerator()
    {
        TSource currentSum = TSourse.Zero;

        foreach(TSource element in sum)
        {
            currentSum += element;
            yield return currentSum;
        }
    }
}
