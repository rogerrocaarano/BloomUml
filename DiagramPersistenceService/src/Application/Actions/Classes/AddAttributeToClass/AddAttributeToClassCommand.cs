using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Classes.AddAttributeToClass;

public class AddAttributeToClassCommand : ICommand
{
    public Guid ClassId { get; set; }
    public string Visibility { get; set; }
    public string AttributeName { get; set; }
    public string AttributeType { get; set; }

    public AddAttributeToClassCommand(
        Guid classId,
        string visibility,
        string attributeName,
        string attributeType
    )
    {
        ClassId = classId;
        Visibility = visibility;
        AttributeName = attributeName;
        AttributeType = attributeType;
    }
}
