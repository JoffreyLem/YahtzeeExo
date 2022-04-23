using FluentAssertions;
using NUnit.Framework;
using FluentAssertions.Execution;
using NSubstitute;

namespace TestProjectYahtzee;

[TestFixture]
public class DiceTest
{
    [Test]
    public void LancerDice()
    {
        var dice = Substitute.For<Dice>();
        dice.Lancer();
        var desValeur = dice.DiceValue;
        desValeur.Should().BeGreaterOrEqualTo(1);
        desValeur.Should().BeLessOrEqualTo(6);


    }
}