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
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Scores actuel de l'utilisateur");
        ScorePlayer.PrintScore();
        Console.WriteLine("");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("");


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


       var dataScorePossible =  HandlePossibleScore();
        CalculateScore(dataScorePossible);
        
    }

    public Dictionary<ScoresEnum,int> HandlePossibleScore()
    {
        var dataScore =  ScoreHandler.HandleDicesForScore(Dices);

    

    

        return dataScore;
    }

    public void CalculateScore(Dictionary<ScoresEnum, int> possibleScore)
    {
        Console.WriteLine("Scores actuel de l'utilisateur");
        ScorePlayer.PrintScore();

        var choosableData = possibleScore.Where(x => ScorePlayer.ScoresData.All(y => y.Key != x.Key)).ToDictionary(x => x.Key, x => x.Value);

        Console.WriteLine("Scores possibles\n");
        Console.WriteLine("");



        for (var i = 0; i < choosableData.Count; i++)
        {

            Console.WriteLine($"{i + 1}. {choosableData.ElementAt(i).Key}");
        }

        var str = Console.ReadLine();

        if (str == null)
        {
            str = "1";
        }


        var indexSelected = int.Parse(str) - 1;

        var selectedToAdd = choosableData.ElementAt(indexSelected);

        ScorePlayer.ScoresData.Add(selectedToAdd.Key, selectedToAdd.Value);

        Console.WriteLine("");
        Console.WriteLine("Nouveau score utilisateur");
        ScorePlayer.PrintScore();
    }
}