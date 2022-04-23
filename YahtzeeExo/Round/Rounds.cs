namespace TestProjectYahtzee;

public class Rounds
{
    private readonly IConsole console;
    public Round[] RoundsData = new Round[3];

    public Rounds(IConsole console)
    {
        this.console = console;
        Array.Fill(RoundsData,new Round(console));
    }

    public void PlayAllRound()
    {
      

        for (int i = 1; i <= 3; i++)
        {
            console.Print($"Round {i}");
            RoundsData[i].PlayRound();
        }
    }
}