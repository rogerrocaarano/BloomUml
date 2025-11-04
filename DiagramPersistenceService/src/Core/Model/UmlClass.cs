namespace Core.Model;

public class UmlClass : IAggregateRoot<Guid>
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string DiagramId { get; private set; }
    public string Name { get; private set; }
    public UmlPosition Position { get; private set; }
    public IReadOnlyCollection<UmlAttribute> Attributes => _attributes.AsReadOnly();
    public IReadOnlyCollection<UmlMethod> Methods => _methods.AsReadOnly();

    private readonly List<UmlAttribute> _attributes = new();
    private readonly List<UmlMethod> _methods = new();

    public UmlClass(Guid id, string diagramId, string name, UmlPosition position)
    {
        Id = id;
        DiagramId = diagramId;
        Name = name;
        Position = position;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddAttribute(UmlAttribute attribute)
    {
        _attributes.Add(attribute);
    }

    public void RemoveAttribute(UmlAttribute attribute)
    {
        _attributes.Remove(attribute);
    }

    public void AddMethod(UmlMethod method)
    {
        _methods.Add(method);
    }

    public void RemoveMethod(UmlMethod method)
    {
        _methods.Remove(method);
    }

    public void UpdatePosition(UmlPosition newPosition)
    {
        Position = newPosition;
    }
}