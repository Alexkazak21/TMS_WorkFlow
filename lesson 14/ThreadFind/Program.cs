namespace ThreadFind
{
    internal class Program
    {

        async static Task Main(string[] args)
        {
            ThreadFind threadFind = new ThreadFind();


           await threadFind.Show();

        }
    }
}
