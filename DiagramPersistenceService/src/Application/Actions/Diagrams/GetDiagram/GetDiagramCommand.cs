using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagram;

public class GetDiagramCommand : ICommand
{
    public Guid DiagramId { get; set; }

    public GetDiagramCommand(Guid diagramId)
    {
        DiagramId = diagramId;
    }
}
