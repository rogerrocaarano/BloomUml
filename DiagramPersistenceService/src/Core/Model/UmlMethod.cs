using OpenDDD.Domain.Model.Base;

namespace Core.Model;

/// <summary>
/// Represents a method of a UML class.
/// </summary>
public class UmlMethod : EntityBase<Guid>
{
    /// <summary>
    /// Gets the visibility of the method.
    /// </summary>
    public UmlVisibility Visibility { get; private set; }

    /// <summary>
    /// Gets the name of the method.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the return type of the method.
    /// </summary>
    public string ReturnType { get; private set; }

    /// <summary>
    /// Gets the collection of parameters for the method.
    /// </summary>
    public ICollection<UmlMethodParameter> Parameters { get; private set; }

    /// <summary>
    /// Initializes a new instance of the UmlMethod class.
    /// </summary>
    /// <param name="id">The unique identifier for the method.</param>
    /// <param name="visibility">The visibility of the method.</param>
    /// <param name="name">The name of the method.</param>
    /// <param name="returnType">The return type of the method.</param>
    /// <param name="parameters">The parameters of the method.</param>
    private UmlMethod(
        Guid id,
        UmlVisibility visibility,
        string name,
        string returnType,
        ICollection<UmlMethodParameter>? parameters = null
    )
        : base(id)
    {
        Visibility = visibility;
        Name = name;
        ReturnType = returnType;
        Parameters = parameters ?? [];
    }

    /// <summary>
    /// Creates a new UML method with the specified parameters.
    /// </summary>
    /// <param name="visibility">The visibility of the method.</param>
    /// <param name="name">The name of the method.</param>
    /// <param name="returnType">The return type of the method.</param>
    /// <param name="parameters">The parameters of the method.</param>
    /// <returns>A new UmlMethod instance.</returns>
    public static UmlMethod Create(
        UmlVisibility visibility,
        string name,
        string returnType,
        ICollection<UmlMethodParameter>? parameters = null
    )
    {
        return new UmlMethod(Guid.NewGuid(), visibility, name, returnType, parameters);
    }
}
