using OpenDDD.Domain.Model.Base;

namespace Core.Model;

public class UmlClassRelation : AggregateRootBase<Guid>
{
    public Guid DiagramId { get; private set; }
    public UmlClassRelationDirection Direction { get; private set; }
    public UmlClassRelationType Type { get; private set; }
    public UmlMultiplicity? Multiplicity { get; private set; }

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
