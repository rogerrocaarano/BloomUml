namespace Core.Model;

public class UmlVisibility : IValueObject
{
    public string Value { get; }

    private UmlVisibility(string value)
    {
        Value = value;
    }

    public static UmlVisibility Public => new("public");
    public static UmlVisibility Private => new("private");
    public static UmlVisibility Protected => new("protected");
    public static UmlVisibility Package => new("package");

    public override bool Equals(object? obj)
    {
        if (obj is not UmlVisibility other) return false;
        return Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}
