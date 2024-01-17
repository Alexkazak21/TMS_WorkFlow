namespace Generic;

public class Pair<S, T>
{
    public S FirstParam { get; set; }
    public T SecondParam { get; set; }

    public Pair(S first, T second)
    {
        FirstParam = first;
        SecondParam = second;
    }
}
