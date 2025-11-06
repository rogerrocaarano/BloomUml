using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Classes.GetClass;

public class GetClassCommand : ICommand
{
    public Guid ClassId { get; set; }

    public GetClassCommand(Guid classId)
    {
        ClassId = classId;
    }
}
