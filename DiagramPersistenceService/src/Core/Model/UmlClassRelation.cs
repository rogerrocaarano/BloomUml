namespace Core.Model;

public class UmlClassRelation : IAggregateRoot<Guid>
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string DiagramId { get; private set; }
    public UmlClassRelationDirection Direction { get; private set; }
    public UmlClassRelationType Type { get; private set; }
    public UmlMultiplicity? Multiplicity { get; private set; }

    public UmlClassRelation(Guid id, string diagramId, UmlClassRelationDirection direction, UmlClassRelationType type, UmlMultiplicity? multiplicity = null)
    {
        Id = id;
        DiagramId = diagramId;
        Direction = direction;
        Type = type;
        Multiplicity = multiplicity;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateMultiplicity(UmlMultiplicity? newMultiplicity)
    {
        Multiplicity = newMultiplicity;
    }
}