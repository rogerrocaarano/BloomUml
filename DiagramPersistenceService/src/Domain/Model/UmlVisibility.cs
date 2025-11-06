using OpenDDD.Domain.Model;

namespace DiagramPersistenceServiceApi.Domain.Model;

/// <summary>
/// Represents the visibility of a UML element.
/// </summary>
public class UmlVisibility : IValueObject
{
    /// <summary>
    /// Gets the string representation of the visibility.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the UmlVisibility class.
    /// </summary>
    /// <param name="value">The string representation of the visibility.</param>
    private UmlVisibility(string value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new public visibility instance of the UmlVisibility class.
    /// </summary>
    public static UmlVisibility Public => new("public");

    /// <summary>
    /// Initializes a new private visibility instance of the UmlVisibility class.
    /// </summary>
    public static UmlVisibility Private => new("private");

    /// <summary>
    /// Initializes a new protected visibility instance of the UmlVisibility class.
    /// </summary>
    public static UmlVisibility Protected => new("protected");

    /// <summary>
    /// Initializes a new package visibility instance of the UmlVisibility class.
    /// </summary>
    public static UmlVisibility Package => new("package");

    /// <summary>
    /// Determines whether the specified object is equal to the current UmlVisibility.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not UmlVisibility other)
            return false;
        return Value == other.Value;
    }

    /// <summary>
    /// Returns a hash code for the current UmlVisibility.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => Value.GetHashCode();
}
