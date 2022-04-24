using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace TestProjectYahtzee;

[TestFixture]
public class RoundTest
{

    [Test]
    public void EachDiceForRoundShouldHaveValue()
    {
        var console = Substitute.For<IConsole>();
        var Round = new Round(console);
        Console.SetIn(new StringReader(""));
        Round.PlayRound();

        foreach (var roundDice in Round.DicesSet.Dices)
        {
            DiceTest.DiceValueTest(roundDice.DiceValue);
        }

    }

    [Test]
    [TestCase()]
    [TestCase(1)]
    [TestCase(1,2)]
    [TestCase(1, 2,3)]
    [TestCase(1, 2, 3,4)]
    [TestCase(1, 2, 3, 4,5)]
    [TestCase(1,3,4)]
    [TestCase(1, 3, 5)]
    [TestCase(2,4)]
    public void KeepDiceAfterRound(params int[] dicesToKeep)
    {
        var console = Substitute.For<IConsole>();
        
        var Round = new Round(console);
        int remaning = dicesToKeep.Length;
        StringReader sr;

        if (dicesToKeep.Length <= 0)
        {
            sr = new StringReader("");
        }
        else
        {
            var ArrayStr = dicesToKeep.Select(x => (x).ToString());
            var strConverted = string.Join(",", ArrayStr);
            sr = new StringReader(strConverted);
        }

 
        Console.SetIn(sr);
        Round.PlayRound();

        Round.DicesSet.DicesKeeped.Count.Should().Be(remaning);
        Round.DicesSet.Dices.Count.Should().Be(5-remaning);
    }
}