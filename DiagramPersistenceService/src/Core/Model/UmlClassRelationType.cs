namespace Core.Model;

public class UmlClassRelationType : IValueObject
{
    public string Type { get; }

    private UmlClassRelationType(string type)
    {
        Type = type;
    }

    public static UmlClassRelationType Inheritance => new("inheritance");
    public static UmlClassRelationType Composition => new("composition");
    public static UmlClassRelationType Aggregation => new("aggregation");
    public static UmlClassRelationType Association => new("association");
    public static UmlClassRelationType Dependency => new("dependency");
    public static UmlClassRelationType Realization => new("realization");

    public override bool Equals(object? obj)
    {
        if (obj is not UmlClassRelationType other) return false;
        return Type == other.Type;
    }

    public override int GetHashCode() => Type.GetHashCode();
}