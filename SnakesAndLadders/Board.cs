namespace SnakesAndLadders;

public record Shortcut(int Init, int End);

public class Board
{
    private readonly int _size;
    private readonly Dictionary<int, int> _shortcuts;

    public Board(int size)
    {
        _size = size;
        _shortcuts = new Dictionary<int, int>();
    }

    public Board(int size, IEnumerable<Shortcut> shortcuts) : this(size)
    {
        foreach (var shortcut in shortcuts)
        {
            _shortcuts.TryAdd(shortcut.Init, shortcut.End);
        }
    }

    public PlayerStatus Move(PlayerStatus playerStatus, int movement)
    {
        var positionCandidate = playerStatus.Square  + movement;

        var newPosition = positionCandidate <= _size ? ApplyShortcut(positionCandidate) : playerStatus.Square;

        return playerStatus with
        {
            Square = newPosition,
            HasWin = newPosition== _size
        };
    }

    private int ApplyShortcut(int position)
    {

        if (_shortcuts.ContainsKey(position))
        {
            return _shortcuts[position];
        }

        return position;
    }
}