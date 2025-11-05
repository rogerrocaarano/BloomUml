using OpenDDD.Domain.Model.Base;

namespace Core.Model;

public class UmlMethod : EntityBase<Guid>
{
    public UmlVisibility Visibility { get; private set; }
    public string Name { get; private set; }
    public string ReturnType { get; private set; }
    public ICollection<UmlMethodParameter> Parameters { get; private set; }

    private UmlMethod(
        Guid id,
        UmlVisibility visibility,
        string name,
        string returnType,
        ICollection<UmlMethodParameter>? parameters = null
    )
        : base(id)
    {
        Visibility = visibility;
        Name = name;
        ReturnType = returnType;
        Parameters = parameters ?? [];
    }

    public static UmlMethod Create(
        UmlVisibility visibility,
        string name,
        string returnType,
        ICollection<UmlMethodParameter>? parameters = null
    )
    {
        return new UmlMethod(Guid.NewGuid(), visibility, name, returnType, parameters);
    }
}
