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

    public int DiceValue { get; set; } = 0;
    public void Lancer()
    {
     
        DiceValue= new Random().Next(1,6); 
    }
}