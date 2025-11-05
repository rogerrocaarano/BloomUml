using OpenDDD.Domain.Model.Base;

namespace Core.Model;

/// <summary>
/// Represents a relation between UML classes in a diagram.
/// </summary>
public class UmlClassRelation : AggregateRootBase<Guid>
{
    /// <summary>
    /// Gets the ID of the diagram this relation belongs to.
    /// </summary>
    public Guid DiagramId { get; private set; }

    /// <summary>
    /// Gets the direction of the relation.
    /// </summary>
    public UmlClassRelationDirection Direction { get; private set; }

    /// <summary>
    /// Gets the type of the relation.
    /// </summary>
    public UmlClassRelationType Type { get; private set; }

    /// <summary>
    /// Gets the multiplicity of the relation, if specified.
    /// </summary>
    public UmlMultiplicity? Multiplicity { get; private set; }

    /// <summary>
    /// Initializes a new instance of the UmlClassRelation class.
    /// </summary>
    /// <param name="id">The unique identifier for the relation.</param>
    /// <param name="diagramId">The ID of the diagram this relation belongs to.</param>
    /// <param name="direction">The direction of the relation.</param>
    /// <param name="type">The type of the relation.</param>
    /// <param name="multiplicity">The multiplicity of the relation.</param>
    private UmlClassRelation(
        Guid id,
        Guid diagramId,
        UmlClassRelationDirection direction,
        UmlClassRelationType type,
        UmlMultiplicity? multiplicity = null
    )
        : base(id)
    {
        DiagramId = diagramId;
        Direction = direction;
        Type = type;
        Multiplicity = multiplicity;
    }

    /// <summary>
    /// Creates a new UML class relation with the specified parameters.
    /// </summary>
    /// <param name="diagramId">The ID of the diagram the relation belongs to.</param>
    /// <param name="direction">The direction of the relation.</param>
    /// <param name="type">The type of the relation.</param>
    /// <param name="multiplicity">The multiplicity of the relation.</param>
    /// <returns>A new UmlClassRelation instance.</returns>
    public static UmlClassRelation Create(
        Guid diagramId,
        UmlClassRelationDirection direction,
        UmlClassRelationType type,
        UmlMultiplicity? multiplicity = null
    )
    {
        return new UmlClassRelation(Guid.NewGuid(), diagramId, direction, type, multiplicity);
    }
}
