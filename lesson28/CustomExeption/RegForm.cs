namespace CustomExeption;

public class RegForm
{
    public static bool CheckInputData(string login, string password, string ConfirmPassword)
    {
        try 
        {
            if (login.Contains(' ') || login.Length > 20)
            {
                throw new WrongLoginException();
            }

            if (password.Length > 20 || password.Contains(' ') || !password.ToCharArray().Any(c => char.IsDigit(c)) || password != ConfirmPassword)
            {
                throw new WrongPassworgException();
            }
        }
        catch 
        { 
            return false;   
        }

        return true;

    }
}
