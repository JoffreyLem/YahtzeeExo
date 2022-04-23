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
            Console.WriteLine($"Valeur des {i+1} : {dice.DiceValue}");
           
        }
        KeepDice();
    }

    public void KeepDice()
    {
        Console.WriteLine("Dès à garder pour prochain round, entrer une liste de INT avec virgule");
        var str = Console.ReadLine();
        var indexs = str?.Split(",").Select(int.Parse).ToList();
        indexs?.ForEach(x => Console.WriteLine($"Dès à garder {x+1}"));

        List<Dice> SelectedToRemove = new List<Dice>();



        if (indexs != null)
        {
            for (var i = 0; i < indexs.Count; i++)
            {
                SelectedToRemove.Add(DicesSet.Dices.Where((x,ind)=>ind==i).First());
            }

            foreach (var dice in SelectedToRemove)
            {
                DicesSet.DicesKeeped.Add(dice);
                DicesSet.Dices.Remove(dice);
            }
        }
    }
}