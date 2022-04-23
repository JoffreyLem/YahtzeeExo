namespace TestProjectYahtzee;

public class Yahtzee
{

    private readonly IConsole _console;
    public Round Round { get; set; }
    public Yahtzee(IConsole console)
    {
        _console = console;
        Round = new Round(_console);
    }

    public void Jouer()
    {
       Round.PlayAllRound();
    }


 
}