﻿namespace TestProjectYahtzee;

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
        Console.WriteLine("\n");
        Console.WriteLine("Dès retenues :\n");
        DicesSet.DicesKeeped.ForEach(x=>{Console.Write($"{x.DiceValue} ");});
        Console.WriteLine("");
        Console.WriteLine("Dès lancées");
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
        Console.WriteLine("\n");
        Console.WriteLine("Dès à garder pour prochain round, entrer une liste de INT avec virgule");
        
        var str = Console.ReadLine();
        str = str == "" ? null : str;

        var indexs = str?.Split(",").Select(x=>int.Parse(x)-1).ToList();
        Console.WriteLine("");
        indexs?.ForEach(x => Console.WriteLine($"Dès à garder {DicesSet.Dices[x].DiceValue}"));

        List<Dice> SelectedToRemove = new List<Dice>();



        if (indexs != null)
        {
            for (var i = 0; i < indexs.Count; i++)
            {
                SelectedToRemove.Add(DicesSet.Dices.Where((x,ind)=>ind==indexs[i]).First());
            }

            foreach (var dice in SelectedToRemove)
            {
                DicesSet.DicesKeeped.Add(new Dice(dice.DiceValue));
                DicesSet.Dices.Remove(dice);
            }
        }
    }
}