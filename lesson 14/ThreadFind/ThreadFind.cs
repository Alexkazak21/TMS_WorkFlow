namespace ThreadFind;

internal class ThreadFind
{
    int[] _workArray = new int[10_000];

    Action<int,int> _onfoundAction = (int number, int index) =>
    {
        Console.WriteLine($"TreadId: {Thread.CurrentThread.ManagedThreadId}\t Item: {number}\t At index: {index}");
    };

    Func<int, bool> _predicate = (int number) => number > 9990;
    public ThreadFind()
    {


        var rand = new Random();
        for (int i = 0; i < _workArray.Length; i++)
        {
            _workArray[i] = rand.Next(-10_000, 10_000);
        }
    }

    public async Task Show()
    {
        await FindByPredicateAsync(_workArray.ToList(), _predicate, _onfoundAction, 5);
    }
    private async Task FindByPredicateAsync(IList<int> list, Func<int, bool> predicate, Action<int,int> onFind, int parallelism)
    {
        var blockLength = (int)Math.Ceiling(list.Count / (decimal)parallelism);

        var tasks = new Task[parallelism];

        for (int i = 0; i < parallelism; i++)
        {
            var startIndex = i;
            tasks[i] = Task.Run(() =>
            {
                var fromIndex = blockLength * startIndex;
                var toIndex = Math.Min(blockLength * (startIndex + 1), list.Count - 1);
                var blockOfArray = list.ToArray()[fromIndex..toIndex];
                FindInThread(blockOfArray, fromIndex, predicate, onFind);
            });
            //tasks[i].Start();
        }
        await Task.WhenAll(tasks);

    }

    private void FindInThread(int[] list, int startIndex, Func<int, bool> predicate, Action<int,int> onFoundAction)
    {
        for (int i = 0; i < list.Length; i++)
        {
            if (predicate(list[i]))
            {
                onFoundAction.Invoke(list[i],i + startIndex);
            }
        }
    }
}
