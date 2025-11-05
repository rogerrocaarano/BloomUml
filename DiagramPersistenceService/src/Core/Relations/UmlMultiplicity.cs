namespace Core.Relations;

/// <summary>
/// Represents the multiplicity of a UML relation.
/// </summary>
public class UmlMultiplicity : IValueObject
{
    /// <summary>
    /// Gets the multiplicity at the origin end of the relation.
    /// </summary>
    public string Origin { get; }

    /// <summary>
    /// Gets the multiplicity at the destination end of the relation.
    /// </summary>
    public string Destination { get; }

    /// <summary>
    /// Initializes a new instance of the UmlMultiplicity class.
    /// </summary>
    /// <param name="origin">The multiplicity at the origin end.</param>
    /// <param name="destination">The multiplicity at the destination end.</param>
    public UmlMultiplicity(string origin, string destination)
    {
        Origin = origin;
        Destination = destination;
    }

    /// <summary>
    /// Creates a one-to-one multiplicity.
    /// </summary>
    /// <returns>A UmlMultiplicity representing one-to-one.</returns>
    public static UmlMultiplicity OneToOne() => new("1", "1");

    /// <summary>
    /// Creates a one-to-many multiplicity.
    /// </summary>
    /// <returns>A UmlMultiplicity representing one-to-many.</returns>
    public static UmlMultiplicity OneToMany() => new("1", "*");

    /// <summary>
    /// Creates a many-to-one multiplicity.
    /// </summary>
    /// <returns>A UmlMultiplicity representing many-to-one.</returns>
    public static UmlMultiplicity ManyToOne() => new("*", "1");

    /// <summary>
    /// Creates a many-to-many multiplicity.
    /// </summary>
    /// <returns>A UmlMultiplicity representing many-to-many.</returns>
    public static UmlMultiplicity ManyToMany() => new("*", "*");

    /// <summary>
    /// Determines whether the specified object is equal to the current UmlMultiplicity.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not UmlMultiplicity other)
            return false;
        return Origin == other.Origin && Destination == other.Destination;
    }

    /// <summary>
    /// Returns a hash code for the current UmlMultiplicity.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(Origin, Destination);
}
