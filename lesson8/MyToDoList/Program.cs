using Microsoft.Extensions.Configuration;
using MyToDoList.SourceProviders;
using MyToDoList;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var todolistSection = config.GetRequiredSection("TasksIOOptions");

ISourceProvider sourceProvider = todolistSection["TasksSourceType"] switch
{
    "json" => new JsonSourceProvider(todolistSection["TasksSource"]),
    _ => throw new ArgumentException()
};

var autoSave = bool.TryParse(todolistSection["Autosave"], out var @string) && @string;
new Menu(sourceProvider,autoSave).Start();
