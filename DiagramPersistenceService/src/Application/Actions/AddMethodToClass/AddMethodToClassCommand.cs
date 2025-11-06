using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.AddMethodToClass;

public class AddMethodToClassCommand : ICommand
{
    public Guid ClassId { get; set; }
    public string Visibility { get; set; }
    public string MethodName { get; set; }
    public string ReturnType { get; set; }

    public AddMethodToClassCommand(
        Guid classId,
        string visibility,
        string methodName,
        string returnType
    )
    {
        ClassId = classId;
        Visibility = visibility;
        MethodName = methodName;
        ReturnType = returnType;
    }
}
