using System.Text;

namespace lesson5_Task1
{
    internal class Program
    {
        static void Main(string[] args)
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
                stringArray.AddRange(textFromFile.Split("\r\n"));
            }
        }
    }
}