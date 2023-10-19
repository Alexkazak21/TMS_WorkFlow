

namespace task1
{
    internal class Phone
    {
        private string? _number;
        private string? _model;
        private string? _weight;

        public string Number { get => _number ?? "Не указан"; }
        public string Model { get => _model ?? "Не указан"; }
        public string Weight { get => _weight ?? "Не указан"; }

        public Phone(string number, string model, string weight) : this(number, model)
        {    
            this._weight = weight;
        }
        public Phone(string number, string model)
        {
            this._number = number;
            this._model = model;
        }
        public Phone() { }

        public void ReciveCall(string name)
        {
            Console.WriteLine($"Звонит {name}");
        }
        public void ReciveCall(string name, string number)
        {
            Console.WriteLine($"Звонит {name}  с номера {number}");
        }

        public void SendMessage(string[] numbers)
        {
            foreach (string  number in numbers) 
            {
                Console.WriteLine(number);
            }
        }
        public string GetNumber() => Number;
    }
}
