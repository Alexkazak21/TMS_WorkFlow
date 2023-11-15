using System.Diagnostics;

namespace TasksStart;

internal class ParallelTasks
{
    int[] _amountOfParallelTasks = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };
    int[] _workArray = new int[10_000_000];

   public ParallelTasks() 
    {
        var rand = new Random();
        for (int i = 0; i <_workArray.Length; i++)
        {
            _workArray[i] = rand.Next(-10_000, 10_000);
        }
    }

    private int Sum(int[] arrayToSum)
    {
        int sum = 0;
        for (int i = 0; i < arrayToSum.Length; i++) 
        {
            sum += arrayToSum[i];
        }

        return sum;
    }


    private async Task<int> SumOfTasks(int[] workArray,int parallelism)
    {
        var blockLength = (int)Math.Ceiling(workArray.Length / (decimal)parallelism);

        var tasks = new Task<int>[parallelism];

        for (int i = 0; i < parallelism;  i++)
        {
            var startIndex = i;
            tasks[i] = /*new Task<int>*/Task.Run(() =>
            {
                var fromIndex = blockLength * startIndex;
                var toIndex = Math.Min(blockLength * (startIndex + 1), workArray.Length);
                var blockOfArray = workArray[fromIndex..toIndex];
                return Sum(blockOfArray);
            });
            //tasks[i].Start();
        }

        var sumArray = await Task.WhenAll(tasks);
        var totalSum = sumArray.Sum();

        return totalSum;
    }

    public async Task ShowParallelism()
    {
        for (int i = 0; i < _amountOfParallelTasks.Length; i++) 
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int res = await SumOfTasks(_workArray, _amountOfParallelTasks[i]);
            stopwatch.Stop();
            Console.WriteLine($"Parallelism = {_amountOfParallelTasks[i]},\nTime = {stopwatch.ElapsedMilliseconds}ms,\nSum = {res}\n\n");
        }
    }
   
}
