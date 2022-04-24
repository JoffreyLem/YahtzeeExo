using System;
using System.Collections.Generic;
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

    [Test]
    [TestCase(ScoresEnum.Ones,1,1,3,4,5)]
    [TestCase(ScoresEnum.Twos, 1, 2, 2, 4, 5)]

    [TestCase(ScoresEnum.Threes, 1, 2, 3, 3, 5)]
    [TestCase(ScoresEnum.Fours, 1, 2, 3, 4, 4)]
    [TestCase(ScoresEnum.Fives, 1, 2, 3, 4, 5)]
    [TestCase(ScoresEnum.Sixes, 1, 2, 3, 6, 6)]
    [TestCase(ScoresEnum.ThreeOfAKind, 1, 2, 5, 5, 5)]
    [TestCase(ScoresEnum.FourOfAKind, 2, 5, 5, 5, 5)]
    [TestCase(ScoresEnum.FullHouse, 1, 1, 1, 6, 6)]
    [TestCase(ScoresEnum.SmallStraight, 1, 2, 3, 4, 6)]
    [TestCase(ScoresEnum.LargeStraight, 1, 2, 3, 4, 5)]
    [TestCase(ScoresEnum.Yathzee, 5, 5, 5, 5, 5)]
    public void GestionScorePossibles(ScoresEnum scoreEnum,params int[] diceValues)
    {

        var console = TestHelper.GetIconsole();

        var rounds = new Rounds(console);
        var dices = rounds.RoundsData.DicesSet.Dices;

        dices[0].DiceValue = diceValues[0];
        dices[1].DiceValue = diceValues[1];
        dices[2].DiceValue = diceValues[2];
        dices[3].DiceValue = diceValues[3];
        dices[4].DiceValue = diceValues[4];
     


        var listScoresPossible = rounds.HandlePossibleScore();

        listScoresPossible.Should().ContainKey(scoreEnum);

    }

}