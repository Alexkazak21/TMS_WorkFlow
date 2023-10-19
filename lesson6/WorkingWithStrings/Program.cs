using System.Configuration;
using System.Collections.Specialized;
using WorkingWithStrings;


var setting = ConfigurationManager.OpenExeConfiguration("..\\..\\..\\App.config");
StringAnalyzer stringAnalyzer = new(setting.AppSettings.CurrentConfiguratio, Mode.mPath);
//var a = stringAnalyzer.WordAndCountNumbers();
//foreach (var word in a)
//{
//    Console.WriteLine($"{word.word} - {word.num}");
//}

//var a = stringAnalyzer.TheLongestWord();
//Console.WriteLine($"Саме длинное слово: [{a.word}] количество вхождений: {a.num} ");

//var a = stringAnalyzer.FindWordsWithSameStartEndLetter();
//foreach (var sentence in a)
//{
//    Console.WriteLine(sentence);
//}

Menu menu = new Menu();
menu.Start(ref stringAnalyzer);
