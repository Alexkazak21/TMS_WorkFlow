using MyToDoList.Commands;
using MyToDoList.Data;
using MyToDoList.SourceProviders;

namespace MyToDoList;
internal class Menu
{
    private ISourceProvider _sourceProvider;
    private ToDoList _todoList;
    private bool _autoSave;
    public Menu(ISourceProvider taskSourceProvider, bool autoSave)
    {
        _sourceProvider = taskSourceProvider;
        _todoList = taskSourceProvider.Load();
        _autoSave = autoSave;
    }



    public void Start()
    {
        var todoList = new ToDoList(_todoList);
        List<ICommand> commands = new()
        {
            new ExitCommand(_sourceProvider,todoList,_autoSave),
            new AddCommand(todoList),
            new DeleteCommand(todoList),
            new MarkAsCompletedCommand(todoList)
        };

        do
        {
            Console.Clear();
            if(_autoSave)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Автоматическое сохранение ВКЛЮЧЕНО\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Автоматическое сохранение ВЫКЛЮЧЕНО\n");
                Console.ResetColor();
            }
            Console.WriteLine("Задачи:");
            PrintList(todoList.ToDoItems());
            Console.WriteLine("Достижения:");
            PrintList(todoList.DoneItems());

            for (int i = 0; i < commands.Count; i++)
            {
                Console.Write(i + ") ");
                Console.WriteLine(commands[i].Description);
            }
            Console.Write("=> ");

            if (int.TryParse(Console.ReadLine(), out int commandId) && commandId >= 0 && commandId < commands.Count)
            {
                commands[commandId].Execute();
            }
            else
            {
                Console.WriteLine("Недопустимое значение");
            }
        } while (true);
    }

    public static void PrintList(string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write(i + "->  ");
            Console.WriteLine(list[i]);
        }
    }
}
