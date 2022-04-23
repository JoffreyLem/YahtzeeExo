namespace TestProjectYahtzee;

public class DicesSet
{
    public List<Dice> Dices;
    public List<Dice> DicesKeeped;

    public DicesSet()
    {
        Dices  = new List<Dice>(Enumerable.Repeat(new Dice(), 5).ToList());
        DicesKeeped = new List<Dice>();

    }
}