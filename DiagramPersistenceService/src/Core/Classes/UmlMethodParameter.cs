using OpenDDD.Domain.Model.Base;

namespace Core.Classes;

/// <summary>
/// Represents a parameter of a UML method.
/// </summary>
public class UmlMethodParameter : EntityBase<Guid>
{
    /// <summary>
    /// Gets the variable representing the parameter.
    /// </summary>
    public UmlVariable Variable { get; private set; }

    /// <summary>
    /// Initializes a new instance of the UmlMethodParameter class.
    /// </summary>
    /// <param name="id">The unique identifier for the parameter.</param>
    /// <param name="variable">The variable of the parameter.</param>
    private UmlMethodParameter(Guid id, UmlVariable variable)
        : base(id)
    {
        Variable = variable;
    }

    /// <summary>
    /// Creates a new UML method parameter with the specified variable.
    /// </summary>
    /// <param name="variable">The variable of the parameter.</param>
    /// <returns>A new UmlMethodParameter instance.</returns>
    public static UmlMethodParameter Create(UmlVariable variable)
    {
        return new UmlMethodParameter(Guid.NewGuid(), variable);
    }
}
