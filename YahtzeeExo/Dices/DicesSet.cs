namespace TestProjectYahtzee;

public class DicesSet
{
    public Dice[] Dices = new Dice[5];

    public DicesSet()
    {
        Array.Fill(Dices,new Dice());
    }
}