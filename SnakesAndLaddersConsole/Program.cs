// See https://aka.ms/new-console-template for more information

using SnakesAndLadders;

Console.WriteLine("This is Snakes and Ladders Game!");

var dice = new Dice();
var board = new Board(100);
var game = new Game(board, dice);

PlayerStatus playerStatus;
do
{
    playerStatus = game.Play();
    Console.WriteLine($"Dice roll result is {playerStatus.LastDiceRoll}. The player is in position {playerStatus.Square}");
} while (!playerStatus.HasWon);

Console.WriteLine("The player has won!");
