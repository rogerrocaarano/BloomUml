using OpenDDD.Domain.Model.Base;

namespace Core.Diagrams;

/// <summary>
/// Represents a UML diagram as an aggregate root in the domain model.
/// A UML diagram contains classes and their relationships, with versioning support.
/// </summary>
public class UmlDiagram : AggregateRootBase<Guid>
{
    /// <summary>
    /// Gets the name of the UML diagram.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the current version of the diagram.
    /// The version is automatically incremented when the diagram is modified.
    /// </summary>
    public DiagramVersion Version { get; private set; }

    /// <summary>
    /// Gets the collection of class IDs that belong to this diagram.
    /// </summary>
    public ICollection<Guid> ClassesIds { get; private set; }

    /// <summary>
    /// Gets the collection of relationship IDs that belong to this diagram.
    /// </summary>
    public ICollection<Guid> RelationsIds { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UmlDiagram"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the diagram.</param>
    /// <param name="name">The name of the diagram.</param>
    /// <param name="version">The version of the diagram.</param>
    /// <param name="classesIds">The collection of class IDs.</param>
    /// <param name="relationsIds">The collection of relationship IDs.</param>
    private UmlDiagram(
        Guid id,
        string name,
        DiagramVersion version,
        ICollection<Guid> classesIds,
        ICollection<Guid> relationsIds
    )
        : base(id)
    {
        Name = name;
        Version = version;
        ClassesIds = classesIds;
        RelationsIds = relationsIds;
    }

    /// <summary>
    /// Creates a new UML diagram with the specified name.
    /// The diagram will have an initial version and empty collections of classes and relations.
    /// </summary>
    /// <param name="name">The name of the new diagram.</param>
    /// <returns>A new instance of <see cref="UmlDiagram"/>.</returns>
    public static UmlDiagram Create(string name)
    {
        return new UmlDiagram(
            Guid.NewGuid(),
            name,
            DiagramVersion.Initial(),
            new List<Guid>(),
            new List<Guid>()
        );
    }

    /// <summary>
    /// Changes the name of the diagram and increments its version.
    /// </summary>
    /// <param name="newName">The new name for the diagram.</param>
    public void ChangeName(string newName)
    {
        Name = newName;
        Version = DiagramVersion.Increment(Version);
    }

    /// <summary>
    /// Updates the collection of class IDs and increments the diagram version.
    /// </summary>
    /// <param name="newClassesIds">The new collection of class IDs.</param>
    public void UpdateClasses(ICollection<Guid> newClassesIds)
    {
        ClassesIds = newClassesIds;
        Version = DiagramVersion.Increment(Version);
    }

    /// <summary>
    /// Updates the collection of relationship IDs and increments the diagram version.
    /// </summary>
    /// <param name="newRelationsIds">The new collection of relationship IDs.</param>
    public void UpdateRelations(ICollection<Guid> newRelationsIds)
    {
        RelationsIds = newRelationsIds;
        Version = DiagramVersion.Increment(Version);
    }
}
