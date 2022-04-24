namespace TestProjectYahtzee;

public class Yahtzee
{

    private readonly IConsole _console;
    public Rounds Rounds { get; set; }
    public Yahtzee(IConsole console)
    {
        _console = console;
        Rounds = new Rounds(_console);
    }

    public void Jouer()
    {

        do
        {
            Rounds.PlayAllRound();
        } while (HandleScorePartit(Rounds.ScorePlayer.ScoresData));


    }

    public bool HandleScorePartit(Dictionary<ScoresEnum, int> scorePlayerScoresData)
    {
        var enumValue = Enum.GetValues(typeof(ScoresEnum));
        foreach (var o in enumValue)
        {
            if (!scorePlayerScoresData.ContainsKey((ScoresEnum)o))
            {
                return true;
            }

           
        }
        return false;
    }


 
}