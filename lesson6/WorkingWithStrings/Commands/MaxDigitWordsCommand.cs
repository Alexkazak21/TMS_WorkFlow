using System.Text;

namespace WorkingWithStrings.Commands;

internal class MaxDigitWordsCommand : ResultCommandBase
{
    private readonly StringAnalyzer _stringAnalyzer;

    public MaxDigitWordsCommand(StringAnalyzer stringAnalyzer, IOutputProvider outputProvider)
        : base(outputProvider)
    {
        _stringAnalyzer = stringAnalyzer;
    }

    public override string Description => "Найти слова, содержащие максимальное количество цифр.";

    public override string GetResult()
    {
        var builder = new StringBuilder();

        foreach (var i in _stringAnalyzer.WordAndCountNumbers())
        {
            builder.AppendLine($"{i.word} - {i.num}");
        }

        return builder.ToString();
    }
}
