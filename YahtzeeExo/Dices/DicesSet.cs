namespace TestProjectYahtzee;

public class DicesSet
{
    public List<Dice> Dices;
    public List<Dice> DicesKeeped;

    public DicesSet()
    {
        Dices = new List<Dice>() {new Dice(0),new Dice(0),new Dice(0),new Dice(0),new Dice(0)};
        DicesKeeped = new List<Dice>();

    }
}