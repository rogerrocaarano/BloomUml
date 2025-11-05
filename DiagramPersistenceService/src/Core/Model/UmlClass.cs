using OpenDDD.Domain.Model.Base;

namespace Core.Model;

public class UmlClass : AggregateRootBase<Guid>
{
    public Guid DiagramId { get; private set; }
    public string Name { get; private set; }
    public UmlPosition Position { get; private set; }
    public ICollection<UmlAttribute> Attributes { get; private set; }
    public ICollection<UmlMethod> Methods { get; private set; }

    private UmlClass(
        Guid id,
        Guid diagramId,
        string name,
        UmlPosition position,
        ICollection<UmlAttribute> umlAttributes,
        ICollection<UmlMethod> umlMethods
    )
        : base(id)
    {
        DiagramId = diagramId;
        Name = name;
        Position = position;
        Attributes = umlAttributes;
        Methods = umlMethods;
    }

    public static UmlClass Create(Guid diagramId, string name, UmlPosition position)
    {
        return new UmlClass(Guid.NewGuid(), diagramId, name, position, [], []);
    }
}
