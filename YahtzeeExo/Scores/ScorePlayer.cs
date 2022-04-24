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
}