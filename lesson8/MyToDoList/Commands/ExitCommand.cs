using MyToDoList.SourceProviders;
using MyToDoList.Data;
namespace MyToDoList.Commands;

internal class ExitCommand : ICommand
{
    private ISourceProvider _sourceProvider;
    private ToDoList _list;
    private bool _autosave;
    public string Description => "Выход";

    public ExitCommand()
    {

    }

    public ExitCommand(ISourceProvider source, ToDoList toDoList, bool autosave)
    {
        _sourceProvider = source;
        _list = toDoList;
        _autosave = autosave;
    }
    public void Execute()
    {
        SaveChanges();
        Environment.Exit(0);
    }

    private void SaveChanges()
    {
        try
        {
            _sourceProvider.Save(_list);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Can`t read source");
            Console.WriteLine(ex);
            Console.ReadKey();
        }

        if(_autosave)
        {
            Console.WriteLine("Changes saved");
            Thread.Sleep(1500);
        }

    }
}
