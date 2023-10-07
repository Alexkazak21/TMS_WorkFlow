namespace TimeOfYear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца");

        monthMark:
            if (!int.TryParse(Console.ReadLine(), out int month))
            {
                Console.WriteLine("Необходимо ввести число, пожалуста повторите попытку");
                Thread.Sleep(1000);
                goto monthMark;
            }

            Console.WriteLine($"Сейчас {WeatherCheckSwitch(month)}");
            Console.WriteLine($"Сейчас {WeatherCheckIF(month)}");
            Console.WriteLine("Введите температуру");
        tempMark:
            if (!int.TryParse(Console.ReadLine(), out int temperature))
            {
                Console.WriteLine("Необходимо ввести число, пожалуста повторите попытку");
                Thread.Sleep(1000);
                goto tempMark;
            }
            Console.WriteLine($"Сейчас {TemperatureCheck(temperature)}");
            Console.WriteLine("Для продолжения нажмите любую кнопку......");
            Console.ReadKey();
        }

        static string TemperatureCheck(int temperature) =>
            temperature switch
            {
                > -5 => "Тепло",
                <-5 and >-20 => "Нормально",               
                _ => "Холодно."
            };

        static string WeatherCheckSwitch(int month) =>
            month switch
            {
                1 or 2 or 12 => "winter",
                3 or 4 or 5 => "spring",
                6 or 7 or 8 => "summer",
                9 or 10 or 11 => "autumn",
                _ => "Не удалось определить месяц."
            };

        static string WeatherCheckIF(int month) 
            {            
            if ( month == 1 || month == 2 || month == 12) { return "winter"; }
            else if ( month == 3 || month == 4 || month == 5) { return "spring"; }
            else if (month == 6 || month == 7 || month == 8) { return "summer"; }
            else if (month == 9 || month == 10 || month == 11) { return "autumn"; }
            else { return "Не удалось определить месяц."; }
            }
    }
}