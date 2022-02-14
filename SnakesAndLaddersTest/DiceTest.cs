using FluentAssertions;
using SnakesAndLadders;
using System.Linq;
using Xunit;

namespace SnakesAndLaddersTest;

public class DiceTest
{
    [Fact]
    public void DiceRollShouldBeBetween1And6()
    {
        var dice = new Dice();
        //There is a little probability to get a random fail in this test if not al numbers are generated in 10000 attempts
        Enumerable.Repeat(0, 10000) 
            .Select(_ => dice.Roll()).ToList()
            .Should()
            .AllSatisfy(rollResult => rollResult.Should().BeInRange(1, 6))
            .And.Contain(new[] { 1, 2, 3, 4, 5, 6 });
    }
}