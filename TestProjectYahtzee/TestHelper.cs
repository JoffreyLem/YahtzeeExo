using NSubstitute;

namespace TestProjectYahtzee;

public static class TestHelper
{
    public static IConsole GetIconsole()
    {
        return Substitute.For<IConsole>();
    }
}