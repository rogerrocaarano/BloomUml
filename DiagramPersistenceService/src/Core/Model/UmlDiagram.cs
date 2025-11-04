namespace Core.Model;

public class UmlDiagram : IAggregateRoot<Guid>
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; private set; }
    public DiagramVersion Version { get; private set; }
    public IReadOnlyCollection<UmlClass> Classes => _classes.AsReadOnly();
    public IReadOnlyCollection<UmlClassRelation> Relations => _relations.AsReadOnly();

    private readonly List<UmlClass> _classes = new();
    private readonly List<UmlClassRelation> _relations = new();

    public UmlDiagram(Guid id, string name, DiagramVersion version)
    {
        Id = id;
        Name = name;
        Version = version;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddClass(UmlClass umlClass)
    {
        _classes.Add(umlClass);
    }

    public void RemoveClass(UmlClass umlClass)
    {
        _classes.Remove(umlClass);
    }

    public void AddRelation(UmlClassRelation relation)
    {
        _relations.Add(relation);
    }

    public void RemoveRelation(UmlClassRelation relation)
    {
        _relations.Remove(relation);
    }

    public void UpdateVersion(DiagramVersion newVersion)
    {
        Version = newVersion;
    }
}