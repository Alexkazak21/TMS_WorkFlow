using WorkingWithStrings.Commands;
using WorkingWithStrings.OutputProviders;

namespace WorkingWithStrings;

internal class Menu
{
    public void Start(ref StringAnalyzer sa)
    {
        var provider = new FileOutputProvider("d:/1.txt");

        var commands = new List<ICommand>
        {
            new ExitCommand(),
            new MaxDigitWordsCommand(sa, provider),
            new LongestWordCount(sa, provider),
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Введите операцию");

            for (var i = 0; i < commands.Count; i++)
            {
                Console.WriteLine($"{i} => {commands[i].Description}");
            }

            var isParsed = int.TryParse(Console.ReadLine(), out var commandNumber);


            if (isParsed && commandNumber < commands.Count)
            {
                var command = commands[commandNumber];

                command.Execute();
            }
            else
            {
                Console.WriteLine($"Доступны только циферки от 0 до {commands.Count - 1}, ещё раз такую дич напишешь, я тебе винду снесу! ");
                Console.ReadLine();
            }
             
        }
    }
    public void StartOld(ref StringAnalyzer sa)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("4 => Вывести на экран сначала вопросительные, а затем восклицательные предложения.");
            Console.WriteLine("5 => Вывести на экран только предложения, не содержащие запятых.");
            Console.WriteLine("6 => Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву");
            int result = 0;
            if (int.TryParse(Console.ReadLine(), out result))
            {
                switch (result)
                {
                    case 3:
                        Console.WriteLine(sa.ReplaceNumbers());
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("\nВопросительные:");
                        foreach (var i in sa.QuestionSentences())
                            Console.WriteLine(i);

                        Console.WriteLine("\nВосклицательные:");
                        foreach (var i in sa.ExclamationSentences())
                            Console.WriteLine(i);
                        Console.ReadLine();
                        break;
                    case 5:
                        foreach (var i in sa.SentencesWithoutCommas())
                            Console.WriteLine(i);
                        Console.ReadLine();
                        break;
                    case 6:
                        foreach (var i in sa.FindWordsWithSameStartEndLetter())
                            Console.WriteLine(i);
                        Console.ReadLine();
                        break;
                    case 0:
                        return;
                }
            }
            else
            {
                Console.WriteLine("Доступны только циферки от 0 до 6ти, ещё раз такую дич напишешь, я тебе винду снесу! ");
                Console.ReadLine();
            }

        }
    }
}
