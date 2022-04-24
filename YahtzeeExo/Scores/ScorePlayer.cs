namespace TestProjectYahtzee;

public class ScorePlayer
{

    public Dictionary<ScoresEnum, int> ScoresData { get; set; }

    public int GlobalScore
    {
        get => ScoresData.Sum(x => x.Value);
    }

    public ScorePlayer()
    {
        ScoresData = new Dictionary<ScoresEnum, int>();
    }

    public void PrintScore()
    {
        Console.WriteLine($"Score global : {GlobalScore}");
        foreach (var keyValuePair in ScoresData)
        {
            Console.WriteLine(keyValuePair.Key.ToString());
        }
        Console.WriteLine("");
    }
}