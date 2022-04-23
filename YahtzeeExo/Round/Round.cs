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

    public void PlayRound()
    {
        for (var i = 0; i < DicesSet.Dices.Length; i++)
        {
            var dice = DicesSet.Dices[i];
            dice.Lancer();
            Console.WriteLine($"Valeur des {i} : {dice.DiceValue}");
        }

    }
}