using FluentAssertions;
using SnakesAndLadders;

namespace SnakesAndLaddersTest;

internal static class TestUtils
{
    internal static void ShouldBe(this PlayerStatus playerStatus, int expectedSquare, bool expectedHasWin = false)
    {
        playerStatus.Square.Should().Be(expectedSquare);
        playerStatus.HasWin.Should().Be(expectedHasWin);
    }
}