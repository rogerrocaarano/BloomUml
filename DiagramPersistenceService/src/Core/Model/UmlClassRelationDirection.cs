namespace Core.Model;

public class UmlClassRelationDirection : IValueObject
{
    public string FromClassId { get; }
    public string ToClassId { get; }
    public bool Bidirectional { get; }

    public UmlClassRelationDirection(string fromClassId, string toClassId, bool bidirectional)
    {
        FromClassId = fromClassId;
        ToClassId = toClassId;
        Bidirectional = bidirectional;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not UmlClassRelationDirection other) return false;
        return FromClassId == other.FromClassId &&
               ToClassId == other.ToClassId &&
               Bidirectional == other.Bidirectional;
    }

    public override int GetHashCode() => HashCode.Combine(FromClassId, ToClassId, Bidirectional);
}