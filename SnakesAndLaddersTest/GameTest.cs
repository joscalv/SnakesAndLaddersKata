using FluentAssertions;
using Moq;
using SnakesAndLadders;
using Xunit;

namespace SnakesAndLaddersTest;

public class GameTest
{
    private readonly Board _board;
    public GameTest()
    {
        _board = new(100);
    }

    [Fact]
    public void TheGameMustStartAt1()
    {
        var expectedStartSquare = 1;

        var dice = new Dice();
        var game = new Game(_board, dice);

        game.PlayerStatus.Square.Should().Be(expectedStartSquare);
    }

    [Fact]
    public void TokenAt1Move3SpacesMustEndAt4()
    {
        var expectedEndSquare = 4;

        var diceMock = new Mock<IDice>();
        diceMock.Setup(m => m.Roll()).Returns(3);
        var game = new Game(_board, diceMock.Object);

        PlayerStatus newStatus = game.Play();

        newStatus.ShouldBe(expectedEndSquare);
    }

    [Fact]
    public void TokenAt1Move3AndThen4SpacesMustEndAt8()
    {
        var expectedEndSquare = 8;

        var diceMock = new Mock<IDice>();
        diceMock
            .SetupSequence(m => m.Roll())
            .Returns(3)
            .Returns(4);
        var game = new Game(_board, diceMock.Object);

        game.Play();
        PlayerStatus newStatus = game.Play();

        newStatus.ShouldBe(expectedEndSquare);
    }

    [Fact]
    public void PlayerMustWinsIfIsAt97AndMove3()
    {
        var expectedEndSquare = 100;
        var expectedHasWon = true;

        var diceMock = new Mock<IDice>();
        diceMock.Setup(m => m.Roll()).Returns(3);
        var game = new Game(_board, diceMock.Object, new PlayerStatus(97, false, 0));

        PlayerStatus newStatus = game.Play();

        newStatus.ShouldBe(expectedEndSquare, expectedHasWon);
    }

    [Fact]
    public void MustNotMoveIfMoveGreaterThanSpace()
    {
        var expectedEndSquare = 97;

        var diceMock = new Mock<IDice>();
        diceMock.Setup(m => m.Roll()).Returns(4);
        var game = new Game(_board, diceMock.Object, new PlayerStatus(97, false, 0));

        PlayerStatus newStatus = game.Play();

        newStatus.ShouldBe(expectedEndSquare);
    }


}