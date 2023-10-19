namespace WorkingWithStrings.Commands;

internal class ExitCommand : ICommand
{
    public string Description => "Выйти";

    public void Execute()
    {
        Environment.Exit(0);
    }
}
