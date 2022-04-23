namespace TestProjectYahtzee;

public class Dice
{

    public int DiceValue { get; set; }
    public void Lancer()
    {
        DiceValue = 0;
        DiceValue= new Random().Next(1,6); 
    }
}