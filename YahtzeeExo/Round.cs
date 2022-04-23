namespace TestProjectYahtzee;

public class Round
{
    private readonly IConsole console;

    public Round(IConsole console)
    {
        this.console = console;
    }

    public void PlayAllRound()
    {
        for (int i = 1; i <= 3; i++)
        {
            console.Print($"Round {i}");
        }
    }
}