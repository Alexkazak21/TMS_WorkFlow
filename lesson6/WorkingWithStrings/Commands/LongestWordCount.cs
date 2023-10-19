namespace WorkingWithStrings.Commands;

internal class LongestWordCount : ResultCommandBase
{
    private readonly StringAnalyzer _stringAnalyzer;

    public LongestWordCount(StringAnalyzer stringAnalyzer, IOutputProvider outputProvider)
        : base(outputProvider)
    {
        _stringAnalyzer = stringAnalyzer;; ; ; ; ; ;
    }

    public override string Description => "Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.";

    public override string GetResult()
    {
        var temp = _stringAnalyzer.TheLongestWord();

        return $"Самое длинное слово: {temp.word} \nКоличество вхождений: {temp.num}";
    }
}
