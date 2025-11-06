using OpenDDD.Domain.Model;

namespace DiagramPersistenceServiceApi.Domain.Model;

/// <summary>
/// Represents the type of a relation between UML classes.
/// </summary>
public class UmlClassRelationType : IValueObject
{
    /// <summary>
    /// Gets the string representation of the relation type.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Initializes a new instance of the UmlClassRelationType class.
    /// </summary>
    /// <param name="type">The string representation of the relation type.</param>
    private UmlClassRelationType(string type)
    {
        Type = type;
    }

    /// <summary>
    /// Initializes a new inheritance instance of the UmlClassRelationType class.
    /// </summary>
    public static UmlClassRelationType Inheritance => new("inheritance");

    /// <summary>
    /// Initializes a new composition instance of the UmlClassRelationType class.
    /// </summary>
    public static UmlClassRelationType Composition => new("composition");

    /// <summary>
    /// Initializes a new aggregation instance of the UmlClassRelationType class.
    /// </summary>
    public static UmlClassRelationType Aggregation => new("aggregation");

    /// <summary>
    /// Initializes a new association instance of the UmlClassRelationType class.
    /// </summary>
    public static UmlClassRelationType Association => new("association");

    /// <summary>
    /// Initializes a new dependency instance of the UmlClassRelationType class.
    /// </summary>
    public static UmlClassRelationType Dependency => new("dependency");

    /// <summary>
    /// Initializes a new realization instance of the UmlClassRelationType class.
    /// </summary>
    public static UmlClassRelationType Realization => new("realization");

    /// <summary>
    /// Determines whether the specified object is equal to the current UmlClassRelationType.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not UmlClassRelationType other)
            return false;
        return Type == other.Type;
    }

    /// <summary>
    /// Returns a hash code for the current UmlClassRelationType.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => Type.GetHashCode();
}
