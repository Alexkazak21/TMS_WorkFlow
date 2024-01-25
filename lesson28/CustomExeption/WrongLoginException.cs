using System;

namespace CustomExeption;

internal class WrongLoginException : Exception
{
    public WrongLoginException()
    {
        Console.WriteLine("Something wrong with you login. Check requests for login");
    }

    public WrongLoginException(string message):base(message) { }
}
