namespace SnakesAndLadders;

public class Game
{
    private readonly IDice _dice;
    private readonly Board _board;

    public PlayerStatus PlayerStatus { get; private set; }

    public Game(Board board, IDice dice)
    {
        _dice = dice;
        _board = board;
        PlayerStatus = new PlayerStatus(1, false,0);
    }

    public Game(Board board, IDice dice, PlayerStatus playerStatus)
    {
        _dice = dice;
        _board = board;
        PlayerStatus = playerStatus;
    }

    public PlayerStatus Play()
    {
        var diceResult = _dice.Roll();
        this.PlayerStatus =  _board.Move(PlayerStatus, diceResult);
        return PlayerStatus;
    }
}