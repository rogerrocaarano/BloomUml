using OpenDDD.Domain.Model.Base;

namespace DiagramPersistenceServiceApi.Domain.Model;

/// <summary>
/// Represents a UML class in a diagram.
/// </summary>
public class UmlClass : AggregateRootBase<Guid>
{
    /// <summary>
    /// Gets the ID of the diagram this class belongs to.
    /// </summary>
    public Guid DiagramId { get; private set; }

    /// <summary>
    /// Gets the name of the UML class.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the position of the class in the diagram.
    /// </summary>
    public UmlPosition Position { get; private set; }

    /// <summary>
    /// Gets the collection of attributes for this class.
    /// </summary>
    public ICollection<UmlAttribute> Attributes { get; private set; }

    /// <summary>
    /// Gets the collection of methods for this class.
    /// </summary>
    public ICollection<UmlMethod> Methods { get; private set; }

    /// <summary>
    /// Initializes a new instance of the UmlClass class.
    /// </summary>
    /// <param name="id">The unique identifier for the class.</param>
    /// <param name="diagramId">The ID of the diagram this class belongs to.</param>
    /// <param name="name">The name of the class.</param>
    /// <param name="position">The position of the class in the diagram.</param>
    /// <param name="umlAttributes">The collection of attributes.</param>
    /// <param name="umlMethods">The collection of methods.</param>
    private UmlClass(
        Guid id,
        Guid diagramId,
        string name,
        UmlPosition position,
        ICollection<UmlAttribute> umlAttributes,
        ICollection<UmlMethod> umlMethods
    )
        : base(id)
    {
        DiagramId = diagramId;
        Name = name;
        Position = position;
        Attributes = umlAttributes;
        Methods = umlMethods;
    }

    /// <summary>
    /// Creates a new UML class with the specified parameters.
    /// </summary>
    /// <param name="diagramId">The ID of the diagram the class belongs to.</param>
    /// <param name="name">The name of the class.</param>
    /// <param name="position">The position of the class in the diagram.</param>
    /// <returns>A new UmlClass instance.</returns>
    public static UmlClass Create(Guid diagramId, string name, UmlPosition position)
    {
        return new UmlClass(Guid.NewGuid(), diagramId, name, position, [], []);
    }

    /// <summary>
    /// Adds an attribute to the class.
    /// </summary>
    /// <param name="attribute">The attribute to add.</param>
    public void AddAttribute(UmlAttribute attribute)
    {
        var newAttributes = new List<UmlAttribute>(Attributes) { attribute };
        Attributes = newAttributes;
    }
}
