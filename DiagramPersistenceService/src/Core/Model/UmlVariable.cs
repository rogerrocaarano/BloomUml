namespace Core.Model;

public class UmlVariable : IValueObject
{
    public string Name { get; }
    public string Type { get; }

    public UmlVariable(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not UmlVariable other) return false;
        return Name == other.Name && Type == other.Type;
    }

    public override int GetHashCode() => HashCode.Combine(Name, Type);
}