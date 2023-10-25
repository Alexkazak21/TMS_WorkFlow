using MyToDoList.Data;
namespace MyToDoList.Commands;

internal class MarkAsCompletedCommand : ICommand
{
    private readonly IToDoList _toDoList;

    public string Description => "Отметить Выполнение задачи";

    public MarkAsCompletedCommand(IToDoList toDoList)
    {
        _toDoList = toDoList;
    }

    public void Execute()
    {
        _toDoList.Exec("Выберите номер выполненной задачи:\n", 0);
    }
}
