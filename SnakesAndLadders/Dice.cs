namespace SnakesAndLadders;

public class Dice : IDice
{
    private readonly Random _numberGenerator;

    public Dice()
    {
        _numberGenerator = new Random();
    }

    public int Roll()
    {
        return _numberGenerator.Next(6) +1;
    }
}