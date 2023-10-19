namespace WorkingWithStrings;

internal interface ICommand
{
    string Description { get; }

    void Execute();
}
