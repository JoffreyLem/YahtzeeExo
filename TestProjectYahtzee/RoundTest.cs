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

        Round.PlayAllRound();

        foreach (var roundDice in Round.Dices)
        {
            roundDice.DiceValue.Should().BeGreaterThan(0);
        }

    }
}