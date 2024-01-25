using System;

namespace CustomExeption;

internal class WrongPassworgException : Exception
{
    public WrongPassworgException() 
    {
        Console.WriteLine("Wrong password, try again");
    }

    public WrongPassworgException(string exeption) : base(exeption) { }
}
