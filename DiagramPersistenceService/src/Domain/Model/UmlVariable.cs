using OpenDDD.Domain.Model;

namespace DiagramPersistenceServiceApi.Domain.Model;

/// <summary>
/// Represents a variable in a UML context, such as an attribute or parameter.
/// </summary>
public class UmlVariable : IValueObject
{
    /// <summary>
    /// Gets the name of the variable.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the type of the variable.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Initializes a new instance of the UmlVariable class.
    /// </summary>
    /// <param name="name">The name of the variable.</param>
    /// <param name="type">The type of the variable.</param>
    public UmlVariable(string name, string type)
    {
        Name = name;
        Type = type;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current UmlVariable.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not UmlVariable other)
            return false;
        return Name == other.Name && Type == other.Type;
    }

    /// <summary>
    /// Returns a hash code for the current UmlVariable.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(Name, Type);
}
