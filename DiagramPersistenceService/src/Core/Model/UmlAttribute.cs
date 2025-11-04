namespace Core.Model;

public class UmlAttribute : IEntity<Guid>
{
    public Guid Id { get; private set; }
    public UmlVisibility Visibility { get; private set; }
    public UmlVariable Variable { get; private set; }

    public UmlAttribute(Guid id, UmlVisibility visibility, UmlVariable variable)
    {
        Id = id;
        Visibility = visibility;
        Variable = variable;
    }

    // Add methods for business logic if needed
}