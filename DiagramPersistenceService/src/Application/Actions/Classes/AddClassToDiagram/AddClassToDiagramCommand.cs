using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Classes.AddClassToDiagram;

public class AddClassToDiagramCommand : ICommand
{
    public Guid DiagramId { get; set; }
    public string ClassName { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public AddClassToDiagramCommand(Guid diagramId, string className, int positionX, int positionY)
    {
        DiagramId = diagramId;
        ClassName = className;
        PositionX = positionX;
        PositionY = positionY;
    }
}
