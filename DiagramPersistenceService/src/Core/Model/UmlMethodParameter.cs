using OpenDDD.Domain.Model.Base;

namespace Core.Model;

public class UmlMethodParameter : EntityBase<Guid>
{
    public UmlVariable Variable { get; private set; }

    private UmlMethodParameter(Guid id, UmlVariable variable)
        : base(id)
    {
        Variable = variable;
    }

    public static UmlMethodParameter Create(UmlVariable variable)
    {
        return new UmlMethodParameter(Guid.NewGuid(), variable);
    }
}
