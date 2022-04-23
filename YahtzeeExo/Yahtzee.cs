namespace TestProjectYahtzee;

public class Yahtzee
{

    private readonly IConsole _console;
    public Rounds Rounds { get; set; }
    public Yahtzee(IConsole console)
    {
        _console = console;
        Rounds = new Rounds(_console);
    }

    public void Jouer()
    {
       Rounds.PlayAllRound();
    }


 
}