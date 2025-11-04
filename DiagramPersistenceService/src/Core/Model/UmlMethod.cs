namespace Core.Model;

public class UmlMethod : IEntity<Guid>
{
    public Guid Id { get; private set; }
    public UmlVisibility Visibility { get; private set; }
    public string Name { get; private set; }
    public string ReturnType { get; private set; }
    public IReadOnlyCollection<UmlMethodParameter> Parameters => _parameters.AsReadOnly();

    private readonly List<UmlMethodParameter> _parameters = new();

    public UmlMethod(Guid id, UmlVisibility visibility, string name, string returnType, IEnumerable<UmlMethodParameter>? parameters = null)
    {
        Id = id;
        Visibility = visibility;
        Name = name;
        ReturnType = returnType;
        if (parameters != null)
        {
            _parameters.AddRange(parameters);
        }
    }

    public void AddParameter(UmlMethodParameter parameter)
    {
        _parameters.Add(parameter);
    }

    public void RemoveParameter(UmlMethodParameter parameter)
    {
        _parameters.Remove(parameter);
    }
}