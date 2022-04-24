using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace TestProjectYahtzee;


[TestFixture]
public class ScoreTest
{

    [Test]
    public void GetPossibleScoreAfterAllRounds()
    {

        var console = TestHelper.GetIconsole();
       
        var rounds = new Rounds(console);

        foreach (var dicesSetDice in rounds.RoundsData.DicesSet.Dices)
        {
            dicesSetDice.DiceValue = new Random().Next(1, 6);
        }
        

       var listScoresPossible=  rounds.HandlePossibleScore();

       listScoresPossible.Should().HaveCountGreaterOrEqualTo(1);

    }
    
}