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
        StringReader sr = new StringReader("");

         rounds.PlayAllRound();

       var listScoresPossible=  rounds.HandlePossibleScore();

       listScoresPossible.Should().HaveCountGreaterOrEqualTo(1);

    }
    
}