namespace WorkingWithStrings.OutputProviders;

internal class ConsoleOutputProvider : IOutputProvider
{
    public void WriteResult(string result)
    {
        Console.WriteLine(result);
        Console.ReadLine();
    }
}
