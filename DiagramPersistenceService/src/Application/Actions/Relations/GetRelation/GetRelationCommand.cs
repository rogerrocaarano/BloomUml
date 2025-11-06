using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Relations.GetRelation;

public class GetRelationCommand : ICommand
{
    public Guid RelationId { get; set; }

    public GetRelationCommand(Guid relationId)
    {
        RelationId = relationId;
    }
}
