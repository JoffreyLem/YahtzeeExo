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
        for (var i = 0; i < DicesSet.Dices.Count; i++)
        {
            var dice = DicesSet.Dices[i];
            dice.Lancer();
            Console.WriteLine($"Valeur des {i} : {dice.DiceValue}");
           
        }
        KeepDice();
    }

    public void KeepDice()
    {
        Console.WriteLine("Dès à garder pour prochain round, entrer une liste de INT avec virgule");
        var str= Console.ReadLine();
        var indexs = str?.Split(",").Select(int.Parse).ToList();
        indexs?.ForEach(x=>Console.WriteLine($"Dès à garder {x}"));
        if (indexs != null)
            foreach (var i in indexs)
            {
                DicesSet.DicesKeeped.Add(DicesSet.Dices[i]);
                DicesSet.Dices.RemoveAt(i);
            }
    }
}