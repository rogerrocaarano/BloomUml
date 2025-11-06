using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Relations.CreateClassRelation;

public class CreateClassRelationCommand : ICommand
{
    public Guid DiagramId { get; set; }
    public Guid FromClassId { get; set; }
    public Guid ToClassId { get; set; }
    public string RelationType { get; set; }
    public bool Bidirectional { get; set; }
    public string? MultiplicityOrigin { get; set; }
    public string? MultiplicityDestination { get; set; }

    public CreateClassRelationCommand(
        Guid diagramId,
        Guid fromClassId,
        Guid toClassId,
        string relationType,
        bool bidirectional,
        string? multiplicityOrigin,
        string? multiplicityDestination
    )
    {
        DiagramId = diagramId;
        FromClassId = fromClassId;
        ToClassId = toClassId;
        RelationType = relationType;
        Bidirectional = bidirectional;
        MultiplicityOrigin = multiplicityOrigin;
        MultiplicityDestination = multiplicityDestination;
    }
}
