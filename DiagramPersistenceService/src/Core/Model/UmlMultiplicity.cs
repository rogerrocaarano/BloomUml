namespace Core.Model;

public class UmlMultiplicity : IValueObject
{
    public int Origin { get; }
    public int Destination { get; }

    public UmlMultiplicity(int origin, int destination)
    {
        Origin = origin;
        Destination = destination;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not UmlMultiplicity other) return false;
        return Origin == other.Origin && Destination == other.Destination;
    }

    public override int GetHashCode() => HashCode.Combine(Origin, Destination);
}