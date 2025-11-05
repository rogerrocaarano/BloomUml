namespace Core.Model;

public class UmlMultiplicity : IValueObject
{
    public string Origin { get; }
    public string Destination { get; }

    public UmlMultiplicity(string origin, string destination)
    {
        Origin = origin;
        Destination = destination;
    }

    public static UmlMultiplicity OneToOne() => new("1", "1");

    public static UmlMultiplicity OneToMany() => new("1", "*");

    public static UmlMultiplicity ManyToOne() => new("*", "1");

    public static UmlMultiplicity ManyToMany() => new("*", "*");

    public override bool Equals(object? obj)
    {
        if (obj is not UmlMultiplicity other)
            return false;
        return Origin == other.Origin && Destination == other.Destination;
    }

    public override int GetHashCode() => HashCode.Combine(Origin, Destination);
}
