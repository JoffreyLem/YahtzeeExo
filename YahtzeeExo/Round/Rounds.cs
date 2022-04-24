namespace TestProjectYahtzee;

public class Rounds
{
    private readonly IConsole console;
    public Round RoundsData;

    public Rounds(IConsole console)
    {
        this.console = console;
        RoundsData = new Round(console);
    }

    public void PlayAllRound()
    {

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine("");
            Console.WriteLine("===================================");
            console.Print($"Round {i}");
            RoundsData.PlayRound();
        }
    }
}