using FluentAssertions;
using SnakesAndLadders;

namespace SnakesAndLaddersTest;

internal static class TestUtils
{
    internal static void ShouldBe(this PlayerStatus playerStatus, int expectedSquare, bool expectedHasWon = false)
    {
        playerStatus.Square.Should().Be(expectedSquare);
        playerStatus.HasWon.Should().Be(expectedHasWon);
    }
}