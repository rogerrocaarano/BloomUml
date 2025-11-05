namespace Core.Relations;

/// <summary>
/// Represents the direction of a relation between UML classes.
/// </summary>
public class UmlClassRelationDirection : IValueObject
{
    /// <summary>
    /// Gets the ID of the class from which the relation originates.
    /// </summary>
    public Guid FromClassId { get; }

    /// <summary>
    /// Gets the ID of the class to which the relation points.
    /// </summary>
    public Guid ToClassId { get; }

    /// <summary>
    /// Gets a value indicating whether the relation is bidirectional.
    /// </summary>
    public bool Bidirectional { get; }

    /// <summary>
    /// Initializes a new instance of the UmlClassRelationDirection class.
    /// </summary>
    /// <param name="fromClassId">The ID of the from class.</param>
    /// <param name="toClassId">The ID of the to class.</param>
    /// <param name="bidirectional">Whether the relation is bidirectional.</param>
    public UmlClassRelationDirection(Guid fromClassId, Guid toClassId, bool bidirectional)
    {
        FromClassId = fromClassId;
        ToClassId = toClassId;
        Bidirectional = bidirectional;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current UmlClassRelationDirection.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not UmlClassRelationDirection other)
            return false;
        return FromClassId == other.FromClassId
            && ToClassId == other.ToClassId
            && Bidirectional == other.Bidirectional;
    }

    /// <summary>
    /// Returns a hash code for the current UmlClassRelationDirection.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(FromClassId, ToClassId, Bidirectional);
}
