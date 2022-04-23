namespace TestProjectYahtzee;

public class Yahtzee
{

    private readonly IConsole _console;

    public Yahtzee(IConsole console)
    {
        _console = console;
    }

    public void Jouer()
    {
        _console.Print("Round 1");
        _console.Print("Round 2");
        _console.Print("Round 3");
    }


 
}