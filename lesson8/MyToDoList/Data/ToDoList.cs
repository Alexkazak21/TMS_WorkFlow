using System.Text.Json.Serialization;
namespace MyToDoList.Data;

[Serializable]
public class ToDoList : IToDoList
{
    [JsonInclude]
    public List<string> _todoTasks = new List<string>();
    [JsonInclude]
    public List<string> _doneTasks = new List<string>();

    public ToDoList()
    {

    }
    public ToDoList(ToDoList list)
    {
        this._todoTasks.Clear();
        _doneTasks.Clear();
        this._todoTasks = new List<string>(list.ToDoItems());
        this._doneTasks = new List<string>(list.DoneItems());
    }
    public enum Action { MarkAsCompletedCommand, DeleteCommand }
    public void Add(string task)
    {
        _todoTasks.Add(DateTime.Now + " ---> " + task);
    }

    public void Delete(int id)
    {
        _todoTasks.RemoveAt(id);
    }

    public void MarkAsCompleted(int id)
    {
        var task = _todoTasks[id][19..];
        _todoTasks.RemoveAt(id);
        _doneTasks.Add(DateTime.Now + task);
    }

    public string[] ToDoItems()
    {
        return _todoTasks.ToArray();
    }

    public string[] DoneItems()
    {
        return _doneTasks.ToArray();
    }
    public void Exec(string str, int id)
    {
        do
        {
            if (_todoTasks.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Нет текущих задач");
                Thread.Sleep(1500);
                break;
            }

            Console.Clear();
            Console.WriteLine(str +
                "№ задачи -> описание");
            for (int i = 0; i < _todoTasks.Count; i++)
            {
                Console.WriteLine(i + " -> " + _todoTasks[i]);
            }
            Console.WriteLine("Введите значение");

            int.TryParse(Console.ReadLine(), out var id_task);


            if (id_task >= 0 && id_task < _todoTasks.Count)
            {
                if (id == (int)Action.MarkAsCompletedCommand)
                {
                    MarkAsCompleted(id_task);
                }
                else
                {
                    Delete(id_task);
                }

                break;
            }
            else
            {
                Console.WriteLine("Вы ввели неверное значение, повторите ввод");
                Thread.Sleep(1500);
            }

        } while (true);
    }

}
