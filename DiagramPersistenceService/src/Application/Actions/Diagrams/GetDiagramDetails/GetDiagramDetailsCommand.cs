using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagramDetails;

public class GetDiagramDetailsCommand : ICommand
{
    public Guid DiagramId { get; set; }

    public GetDiagramDetailsCommand(Guid diagramId)
    {
        DiagramId = diagramId;
    }
}
