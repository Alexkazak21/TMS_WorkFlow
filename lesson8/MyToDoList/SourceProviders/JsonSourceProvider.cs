using MyToDoList.Data;
using System.Text.Json;

namespace MyToDoList.SourceProviders;

internal class JsonSourceProvider : ISourceProvider
{
    private readonly string _pathToFile;

    public JsonSourceProvider(string path)
    {
        _pathToFile = path;
    }
    public ToDoList Load()
    {
        if (string.IsNullOrEmpty(_pathToFile))
        {
            return new ToDoList();
        }

        var json = File.ReadAllText(_pathToFile);

        var options = new JsonSerializerOptions
        {
            IgnoreReadOnlyFields = false,
            IncludeFields = true,
        };

        var tasks = JsonSerializer.Deserialize<ToDoList>(json, options);

        var taskList = new ToDoList(tasks);
        return taskList;
    }

    public void Save(ToDoList toDoList)
    {
        var options = new JsonSerializerOptions
        {
            IgnoreReadOnlyFields = false,
            IncludeFields = true
        };

        var JsonString = JsonSerializer.Serialize(toDoList, options);
        File.WriteAllText(_pathToFile, JsonString);
    }
}
