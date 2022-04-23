using System;
using System.IO;
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

        Round.PlayRound();

        foreach (var roundDice in Round.DicesSet.Dices)
        {
            DiceTest.DiceValueTest(roundDice.DiceValue);
        }

    }

    [Test]
    public void KeepDiceAfterRound(params int[] dicesToKeep)
    {
        var console = Substitute.For<IConsole>();
        var Round = new Round(console);
        var sr = new StringReader("1");
        Console.SetIn(sr);
        Round.PlayRound();
    
    }
}