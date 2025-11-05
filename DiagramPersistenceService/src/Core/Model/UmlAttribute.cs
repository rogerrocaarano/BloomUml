using OpenDDD.Domain.Model.Base;

namespace Core.Model;

public class UmlAttribute : EntityBase<Guid>
{
    public UmlVisibility Visibility { get; private set; }
    public UmlVariable Variable { get; private set; }

    private UmlAttribute(Guid id, UmlVisibility visibility, UmlVariable variable)
        : base(id)
    {
        Visibility = visibility;
        Variable = variable;
    }

    public static UmlAttribute Create(UmlVisibility visibility, UmlVariable variable)
    {
        return new UmlAttribute(Guid.NewGuid(), visibility, variable);
    }
}
