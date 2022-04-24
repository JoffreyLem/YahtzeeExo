namespace TestProjectYahtzee;

public class Rounds
{
    private readonly IConsole console;
    public Round RoundsData;

    public List<Dice> Dices
    {
        get => RoundsData.DicesSet.Dices.Concat(RoundsData.DicesSet.DicesKeeped).ToList();
    }

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

        List<Dice> AllDices = new List<Dice>();
        AllDices.AddRange(RoundsData.DicesSet.Dices);
        AllDices.AddRange(RoundsData.DicesSet.DicesKeeped);
    }

    public List<Scores> HandlePossibleScore()
    {

        return null;

    }
}