namespace TestProjectYahtzee;

public class Dice
{
    public Dice(int diceValue)
    {
        DiceValue = diceValue;
    }

    public Dice()
    {
        DiceValue = 0;
    }

    public int DiceValue { get; set; } 
    public void Lancer()
    {
        Random r = new Random();
        DiceValue= r.Next(1,6); 
    }
}