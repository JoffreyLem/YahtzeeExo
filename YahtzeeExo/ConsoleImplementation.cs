namespace TestProjectYahtzee;

public class ConsoleImplementation : IConsole
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    public string ReadLine()
    {
        throw new NotImplementedException();
    }
}