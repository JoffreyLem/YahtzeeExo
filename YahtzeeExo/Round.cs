namespace TestProjectYahtzee;

public class Round
{
    private readonly IConsole console;
    public Dice[] Dices = new Dice[5];

    public Round(IConsole console)
    {
        this.console = console;
        Array.Fill(Dices,new Dice());
    }

    public void PlayAllRound()
    {
        for (int i = 1; i <= 3; i++)
        {
            console.Print($"Round {i}");
            foreach (var dice in Dices)
            {
                dice.Lancer();
            }
        }
    }
}