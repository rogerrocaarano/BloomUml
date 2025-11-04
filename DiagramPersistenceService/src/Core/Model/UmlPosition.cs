namespace Core.Model;

public class UmlPosition : IValueObject
{
    public int X { get; }
    public int Y { get; }

    public UmlPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not UmlPosition other) return false;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y);
}
