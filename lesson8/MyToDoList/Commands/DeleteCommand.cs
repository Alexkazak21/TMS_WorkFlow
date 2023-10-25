using MyToDoList.Data;
namespace MyToDoList.Commands;

internal class DeleteCommand : ICommand
{
    private readonly IToDoList _toDoList;

    public string Description => "Удалить задачу";

    public DeleteCommand(IToDoList toDoList)
    {
        _toDoList = toDoList;
    }

    public void Execute()
    {
        _toDoList.Exec("Выберите номер задачи для удаления :\n", 1);
    }
}
