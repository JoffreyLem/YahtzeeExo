using NSubstitute;
using NUnit.Framework;

namespace TestProjectYahtzee;

[TestFixture]
public class YahtzeeTest
{

    [Test]
    public void PlayAllRounds()
    {
        var console = Substitute.For<IConsole>();
        var game = new Yahtzee(console);
     

        game.Jouer();

       

        Received.InOrder(() =>
        {
            console.Print("Round 1");
            console.Print("Round 2");
            console.Print("Round 3");
        });
    }
    
}