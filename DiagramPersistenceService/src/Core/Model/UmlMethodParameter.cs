namespace Core.Model;

public class UmlMethodParameter : IEntity<Guid>
{
    public Guid Id { get; private set; }
    public UmlVariable Variable { get; private set; }

    public UmlMethodParameter(Guid id, UmlVariable variable)
    {
        Id = id;
        Variable = variable;
    }
}