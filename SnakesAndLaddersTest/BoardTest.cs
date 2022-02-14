using SnakesAndLadders;
using System.Collections.Generic;
using Xunit;

namespace SnakesAndLaddersTest;

public class BoardTest
{
    private readonly Board _board;
    public BoardTest()
    {
        var laddersAndSnakes = new List<Shortcut>
        {
            new(5, 10),
            new(20, 15),
        };

        _board = new(100, laddersAndSnakes);
    }

    [Fact]
    public void MustMoveIfItIsInBounds()
    {
        var expectedSquare = 2;

        var playerStatus = _board.Move(new PlayerStatus(1, false), 1);

        playerStatus.ShouldBe(expectedSquare);
    }

    [Fact]
    public void MustNotMoveIfNewPositionIsOutOfBounds()
    {
        var expectedEndSquare = 97;

        var playerStatus = _board.Move(new PlayerStatus(97, false), 4);

        playerStatus.ShouldBe(expectedEndSquare);
    }

    [Fact]
    public void MustApplyLadderIfThereIsOne()
    {
        var expectedEndSquare = 10;

        var playerStatus = _board.Move(new PlayerStatus(4, false), 1);

        playerStatus.ShouldBe(expectedEndSquare);
    }

    [Fact]
    public void MustApplySnakeIfThereIsOne()
    {
        var expectedEndSquare = 15;

        var playerStatus = _board.Move(new PlayerStatus(19, false), 1);

        playerStatus.ShouldBe(expectedEndSquare);
    }

}