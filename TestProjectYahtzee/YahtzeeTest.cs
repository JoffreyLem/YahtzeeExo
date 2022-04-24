using System;
using System.IO;
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
        StringReader sr = new StringReader("");
        Console.SetIn(sr);

        game.Rounds.PlayAllRound();

       

        Received.InOrder(() =>
        {
            console.Print("Round 1");
            console.Print("Round 2");
            console.Print("Round 3");
        });
    }
    
}