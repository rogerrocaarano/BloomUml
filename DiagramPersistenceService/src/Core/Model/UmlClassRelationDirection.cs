namespace Core.Model;

public class UmlClassRelationDirection : IValueObject
{
    public Guid FromClassId { get; }
    public Guid ToClassId { get; }
    public bool Bidirectional { get; }

    public UmlClassRelationDirection(Guid fromClassId, Guid toClassId, bool bidirectional)
    {
        FromClassId = fromClassId;
        ToClassId = toClassId;
        Bidirectional = bidirectional;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not UmlClassRelationDirection other)
            return false;
        return FromClassId == other.FromClassId
            && ToClassId == other.ToClassId
            && Bidirectional == other.Bidirectional;
    }

    public override int GetHashCode() => HashCode.Combine(FromClassId, ToClassId, Bidirectional);
}
