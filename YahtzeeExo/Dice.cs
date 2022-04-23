namespace TestProjectYahtzee;

public class Dice
{
    public int Lancer()
    {
        return new Random().Next(1,6); 
    }
}