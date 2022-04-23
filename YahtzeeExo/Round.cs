namespace TestProjectYahtzee;

public class Round
{
    private readonly IConsole console;
    public DicesSet DicesSet { get; set; }

    public Round(IConsole console)
    {
        this.console = console;
        DicesSet = new DicesSet();

    }

    public void PlayAllRound()
    {
        for (int i = 1; i <= 3; i++)
        {
            console.Print($"Round {i}");
            foreach (var dice in DicesSet.Dices)
            {
                dice.Lancer();
            }
        }
    }
}