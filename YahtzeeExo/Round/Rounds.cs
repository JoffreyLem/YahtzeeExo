namespace TestProjectYahtzee;

public class Rounds
{
    private readonly IConsole console;
    public Round RoundsData { get; set; }
    public ScoreHandler ScoreHandler { get; set; }

    public ScorePlayer ScorePlayer { get; set; }
  
    public List<Dice> Dices
    {
        get => RoundsData.DicesSet.Dices.Concat(RoundsData.DicesSet.DicesKeeped).ToList();
    }

    public Rounds(IConsole console)
    {
        this.console = console;
        RoundsData = new Round(console);
        ScoreHandler = new ScoreHandler();
        ScorePlayer = new ScorePlayer();
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
        Console.WriteLine("");

        Console.WriteLine("Dès gardées:");
        Dices.ForEach(x=>Console.Write($"{x.DiceValue} "));
        Console.WriteLine("");


        HandlePossibleScore();
        
        
    }

    public Dictionary<ScoresEnum,int> HandlePossibleScore()
    {
        var dataScore =  ScoreHandler.HandleDicesForScore(Dices);

        Console.WriteLine("Scores actuel de l'utilisateur");
        Console.WriteLine($"Score global : {ScorePlayer.GlobalScore}");
        foreach (var keyValuePair in ScorePlayer.ScoresData)
        {
            Console.WriteLine(keyValuePair.Key.ToString());
        }
        Console.WriteLine("");

        var choosableData = dataScore.Where(x => ScorePlayer.ScoresData.All(y => y.Key != x.Key)).ToDictionary(x=>x.Key,x=>x.Value);

        Console.WriteLine("Scores possibles\n");
        Console.WriteLine("");

     

        for (var i = 0; i < choosableData.Count; i++)
        {
       
            Console.WriteLine($"{i+1}. {choosableData.ElementAt(i)}");
        }

        var str = Console.ReadLine();

        var indexSelected = int.Parse(str) - 1;

        var selectedToAdd = choosableData.ElementAt(indexSelected);

        ScorePlayer.ScoresData.Add(selectedToAdd.Key,selectedToAdd.Value);

    

        return dataScore;
    }
}