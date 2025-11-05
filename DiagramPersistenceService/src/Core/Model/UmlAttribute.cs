using OpenDDD.Domain.Model.Base;

namespace Core.Model;

/// <summary>
/// Represents an attribute of a UML class.
/// </summary>
public class UmlAttribute : EntityBase<Guid>
{
    /// <summary>
    /// Gets the visibility of the attribute.
    /// </summary>
    public UmlVisibility Visibility { get; private set; }

    /// <summary>
    /// Gets the variable representing the attribute.
    /// </summary>
    public UmlVariable Variable { get; private set; }

    /// <summary>
    /// Initializes a new instance of the UmlAttribute class.
    /// </summary>
    /// <param name="id">The unique identifier for the attribute.</param>
    /// <param name="visibility">The visibility of the attribute.</param>
    /// <param name="variable">The variable of the attribute.</param>
    private UmlAttribute(Guid id, UmlVisibility visibility, UmlVariable variable)
        : base(id)
    {
        Visibility = visibility;
        Variable = variable;
    }

    /// <summary>
    /// Creates a new UML attribute with the specified visibility and variable.
    /// </summary>
    /// <param name="visibility">The visibility of the attribute.</param>
    /// <param name="variable">The variable of the attribute.</param>
    /// <returns>A new UmlAttribute instance.</returns>
    public static UmlAttribute Create(UmlVisibility visibility, UmlVariable variable)
    {
        return new UmlAttribute(Guid.NewGuid(), visibility, variable);
    }
}
