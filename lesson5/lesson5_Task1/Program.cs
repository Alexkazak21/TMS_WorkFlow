using System.Text;
using System.Text.RegularExpressions;

namespace lesson5_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = FileReadToWords();
            List<string> listOfSentences = FileReadToSentence();
            MainLife(list,listOfSentences);
        }

        static List<string> FileReadToWords()
        {
            List<string> stringArray = new List<string>();
            using (FileStream fstream = File.OpenRead("..\\..\\..\\strings.txt"))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                stringArray.AddRange(textFromFile.Split(new string[] { "\r\n", " ", ",","." }, StringSplitOptions.RemoveEmptyEntries)) ;
                GC.Collect();
                return new List<string> (stringArray);
            }
        }

        static List<string> FileReadToSentence()
        {
            List<string> stringArray = new List<string>();
            using (FileStream fstream = File.OpenRead("..\\..\\..\\strings.txt"))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                stringArray.AddRange(Regex.Split(textFromFile, @"(?<=[\.!\?])\s+"));
                GC.Collect();
                return new List<string>(stringArray);
            }
        }

        static bool MainLife(List<string> strArray,List<string> sentenceList)
        {
            bool trigger = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Список доступных действий:\n\n" +
                    "1. Найти слова, содержащие максимальное количество цифр.\r\n" +
                    "2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.\r\n" +
                    "3. Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять».\r\n" +
                    "4. Вывести на экран сначала вопросительные, а затем восклицательные предложения.\r\n" +
                    "5. Вывести на экран только предложения, не содержащие запятых.\r\n" +
                    "6. Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.\r\n" +
                    "7. Завершить работу\n\n");
                Console.Write("Введите нужный пункт > ");

                if (int.TryParse(Console.ReadLine(), out int choise) && choise > 0 && choise < 8)
                {
                    switch (choise)
                    {
                        case 1:
                            {
                                MaxNumber(strArray);
                            }
                            break;
                        case 2:
                            {
                                MaxLengthOfWord(strArray);
                            }
                            break;
                        case 3:
                            {
                                WriteNumbersInWords(strArray);
                            }
                            break;
                        case 4:
                            {
                                EmotionalSentences(sentenceList);
                            }
                            break;
                        case 5:
                            {
                                SentencesWithout(sentenceList, ',');
                            }
                            break;
                        case 6:
                            {
                                SimillarChars(strArray);
                            }
                            break;
                        default:
                            {
                                trigger = false;
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы допустили ошибку при выботе значения, поворите ввод");
                    Thread.Sleep(1500);
                    trigger = MainLife(strArray,sentenceList);
                }
            } while (trigger);

            return false;
        }

        static void UserWait()
        {
            Console.WriteLine("Для продолжения нажмите любую кнопку.....");
            Console.ReadKey();
        }
        static void MaxNumber(List<string> strArray)
        {
            int max = 0;
            int res = 0;
            for(int i = 0; i < strArray.Count; i++)
            {
                int count = 0;
                for(int j = 0; j < strArray[i].Length; j++)
                {
                    if (char.IsDigit(strArray[i][j]))
                    {
                        count++;
                    }
                }    

                if (count > max)
                {
                    max = count;
                    res = i;
                }
            }

            Dictionary<int, string> output = new Dictionary<int, string>();
            
            max = strArray[res].Where(char.IsDigit).Count();
            for (int i = 0;i < strArray.Count;i++) 
            {
                if ( max == strArray[i].Where(char.IsDigit).Count())
                {
                    output.Add(i + 1,strArray[i]);
                }
            }
            Console.Clear();
            Console.WriteLine($"Строка с максимальным колличеством цифр:\n");
            foreach (var str in output) 
            {

                Console.WriteLine($"{str.Key}. {str.Value}");
            }
            
            UserWait();
        }
        static void MaxLengthOfWord(List<string> strArray)
        {
            int? maxLength = strArray.Max(x=>x.Length);
            int count = 0;
            foreach(var str in strArray)
            { 
                if (str.Length == maxLength)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                Console.WriteLine($"Слово {strArray.Select(x => x).Where(x => x.Length == maxLength).First()} встретилось всего раз.");
                UserWait();
            }
            else
            {
                Console.Clear();
                var allMaxStrings = strArray.Select(x => x).Where(x => x.Length == maxLength);
                foreach (var str in allMaxStrings)
                {
                    Console.WriteLine($"Слово {str} встретилось всего {strArray.Where(x=>x == str).Count()} раз.");                   
                }
                UserWait();
            }
        }
        static void EmotionalSentences(List<string> sentenceArray)
        {
            Console.Clear();
            List<string> emotionalSent = new List<string>(sentenceArray.Where(x => x[^1] == '?'));
            emotionalSent.AddRange(sentenceArray.Where(x => x[^1] == '!'));
            if (emotionalSent.Count > 0)
            {
                foreach (var sent in emotionalSent)
                {
                    Console.WriteLine(sent);
                }
            }
            else
            {
                Console.WriteLine("В тексте отсутствуют вопросительные и восклицательные предложения!!!");
            }
            UserWait();
        }
        static void WriteNumbersInWords(List<string> strArray)
        {
            Dictionary<int, string> replaceNumbers = new Dictionary<int, string> { {0,"ноль"}, { 1, "один" }, { 2, "два" },
                                                                                   { 3, "три" }, { 4, "четыре" }, { 5, "пять" },
                                                                                   { 6, "шесть" }, { 7, "семь" }, {8,"восемь"},{9,"девять"}};

            List<string> resArray = new List<string>(strArray);

            List<string> FinalArray = new List<string>();
            var numberList = new List<string>();

            for (int i = 0; i < resArray.Count; i++)
            {
                for (int j = 0; j < resArray[i].Length; j++) 
                {

                    if (j == 0 && char.IsDigit(resArray[i][j]))
                    {
                        resArray[i] = replaceNumbers.Where(x => x.Key == int.Parse(resArray[i][j].ToString())).First().Value + resArray[i].Substring(j + 1, resArray[i].Length - 1);
                    }
                    else if (char.IsDigit(resArray[i][j]))
                    {
                        string number = replaceNumbers.Where(x => x.Key == int.Parse(resArray[i][j].ToString())).First().Value;
                        resArray[i] = resArray[i].Substring(0, j) + number + resArray[i].Substring(j + 1, resArray[i].Length - 1 - j);
                    }
                }

                if (strArray[i].Any(char.IsDigit))
                {
                    numberList.Add(resArray[i]);
                }

            }

            Console.Clear();
            Console.WriteLine("Изменённые слова имеют вид:\n");
            foreach (var item in numberList)
            {
                Console.WriteLine(item + "\n");
            }
            UserWait();
        }
        static void SentencesWithout(List<string> sentenceArray, char symbol)
        {
            Console.Clear();
            Console.WriteLine("Предложения без запятых:\n");
            foreach (var item in sentenceArray)
            {
                if (!item.Contains(symbol))
                {
                    Console.WriteLine(item + "\n");
                }
            }
            UserWait();
        }
        static void SimillarChars(List<string> strArray)
        {
            Console.Clear();
            Console.WriteLine("Слова с одиноковыми первым и последним символом:\n");
            foreach (var item in strArray)
            {
                if (item.Length != 1 && item[0] == item[^1] )
                {
                    Console.WriteLine(item + "\n");
                }
            }
            UserWait();
        }
    }
}