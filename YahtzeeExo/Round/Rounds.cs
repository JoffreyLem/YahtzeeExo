namespace TestProjectYahtzee;

public class Rounds
{
    private readonly IConsole console;
    public Round RoundsData { get; set; }
    public ScoreHandler ScoreHandler { get; set; }
  
    public List<Dice> Dices
    {
        get => RoundsData.DicesSet.Dices.Concat(RoundsData.DicesSet.Dices).ToList();
    }

    public Rounds(IConsole console)
    {
        this.console = console;
        RoundsData = new Round(console);
        ScoreHandler = new ScoreHandler();
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

        
     

        HandlePossibleScore();
        
    }

    public Dictionary<Scores,int> HandlePossibleScore()
    {
        var dataScore =  ScoreHandler.HandleDicesForScore(Dices);
        Console.WriteLine("Scores possibles\n");
        foreach (var keyValuePair in dataScore)
        {
    
            Console.WriteLine(keyValuePair.Key.ToString());
        }

        return dataScore;
    }
}