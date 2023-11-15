using TasksStart;

namespace TasksPractice;

internal class Program
{
    async static Task Main(string[] args)
    {
        ParallelTasks tasks = new ParallelTasks();
        await tasks.ShowParallelismAsync();
    }
}