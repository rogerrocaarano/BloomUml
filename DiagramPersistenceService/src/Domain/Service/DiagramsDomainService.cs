using DiagramPersistenceServiceApi.Domain.Model;
using OpenDDD.Domain.Service;

namespace DiagramPersistenceServiceApi.Domain.Service;

public class DiagramsDomainService : IDiagramsDomainService
{
    private readonly IUmlDiagramsRepository _diagramsRepository;
    private readonly IUmlClassesRepository _classesRepository;
    private readonly IUmlClassRelationsRepository _relationsRepository;

    public DiagramsDomainService(
        IUmlDiagramsRepository diagramsRepository,
        IUmlClassesRepository classesRepository,
        IUmlClassRelationsRepository relationsRepository
    )
    {
        _diagramsRepository = diagramsRepository;
        _classesRepository = classesRepository;
        _relationsRepository = relationsRepository;
    }

    public async Task<UmlDiagram> CreateDiagramAsync(
        Guid ownerId,
        string name,
        CancellationToken ct = default
    )
    {
        // Check if a diagram with the same name and owner already exists
        var existingDiagrams = await _diagramsRepository.FindWithAsync(
            d => d.Name == name && d.OwnerId == ownerId,
            ct
        );
        if (existingDiagrams.Any())
        {
            throw new InvalidOperationException(
                $"A diagram with the name '{name}' already exists for the owner."
            );
        }

        var diagram = UmlDiagram.Create(ownerId, name);
        await _diagramsRepository.SaveAsync(diagram, ct);
        return diagram;
    }

    public async Task<UmlClass> CreateClassAsync(
        Guid diagramId,
        string name,
        UmlPosition position,
        CancellationToken ct = default
    )
    {
        var diagram = await _diagramsRepository.GetAsync(diagramId, ct);

        // Check if a class with the same name already exists in the diagram
        var existingClasses = await Task.WhenAll(
            diagram.ClassesIds.Select(id => _classesRepository.GetAsync(id, ct))
        );
        if (existingClasses.Any(c => c.Name == name))
        {
            throw new InvalidOperationException(
                $"A class with the name '{name}' already exists in the diagram."
            );
        }

        var umlClass = UmlClass.Create(diagramId, name, position);
        await _classesRepository.SaveAsync(umlClass, ct);

        // Update the diagram with the new class ID
        var newClassesIds = new List<Guid>(diagram.ClassesIds) { umlClass.Id };
        diagram.UpdateClasses(newClassesIds);
        await _diagramsRepository.SaveAsync(diagram, ct);

        return umlClass;
    }

    public async Task<UmlAttribute> AddAttributeToClassAsync(
        Guid classId,
        UmlVisibility visibility,
        string name,
        string type,
        CancellationToken ct = default
    )
    {
        var umlClass = await _classesRepository.GetAsync(classId, ct);

        // Check if an attribute with the same name already exists in the class
        if (umlClass.Attributes.Any(a => a.Variable.Name == name))
        {
            throw new InvalidOperationException(
                $"An attribute with the name '{name}' already exists in the class."
            );
        }

        var variable = new UmlVariable(name, type);
        var attribute = UmlAttribute.Create(visibility, variable);
        umlClass.AddAttribute(attribute);
        await _classesRepository.SaveAsync(umlClass, ct);

        return attribute;
    }
}
