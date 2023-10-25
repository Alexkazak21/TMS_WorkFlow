using MyToDoList.Data;
namespace MyToDoList.SourceProviders;

internal interface ISourceProvider
{
    ToDoList Load();

    void Save(ToDoList toDoList);
}
