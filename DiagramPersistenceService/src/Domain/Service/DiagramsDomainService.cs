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

    public async Task<UmlMethod> AddMethodToClassAsync(
        Guid classId,
        UmlVisibility visibility,
        string name,
        string returnType,
        ICollection<UmlMethodParameter>? parameters = null,
        CancellationToken ct = default
    )
    {
        var umlClass = await _classesRepository.GetAsync(classId, ct);

        // Check if a method with the same name already exists in the class
        if (umlClass.Methods.Any(m => m.Name == name))
        {
            throw new InvalidOperationException(
                $"A method with the name '{name}' already exists in the class."
            );
        }

        var method = UmlMethod.Create(visibility, name, returnType, parameters);
        umlClass.AddMethod(method);
        await _classesRepository.SaveAsync(umlClass, ct);

        return method;
    }

    public async Task<UmlClassRelation> CreateClassRelationAsync(
        Guid diagramId,
        Guid fromClassId,
        Guid toClassId,
        UmlClassRelationType relationType,
        bool bidirectional = false,
        string? multiplicityOrigin = null,
        string? multiplicityDestination = null,
        CancellationToken ct = default
    )
    {
        var diagram = await _diagramsRepository.GetAsync(diagramId, ct);
        var fromClass = await _classesRepository.GetAsync(fromClassId, ct);
        var toClass = await _classesRepository.GetAsync(toClassId, ct);

        await ValidateClassesExistAndBelongToDiagram(diagramId, fromClass, toClass);
        ValidateNoSelfRelation(fromClassId, toClassId);
        await ValidateNoDuplicateRelation(diagram, fromClassId, toClassId, ct);

        var direction = CreateRelationDirection(fromClassId, toClassId, bidirectional);
        var multiplicity = CreateRelationMultiplicity(multiplicityOrigin, multiplicityDestination);

        var relation = UmlClassRelation.Create(diagramId, direction, relationType, multiplicity);
        await PersistRelationAndUpdateDiagram(relation, diagram, ct);

        return relation;
    }

    private async Task ValidateClassesExistAndBelongToDiagram(
        Guid diagramId,
        UmlClass fromClass,
        UmlClass toClass
    )
    {
        if (fromClass.DiagramId != diagramId || toClass.DiagramId != diagramId)
        {
            throw new InvalidOperationException(
                "Both classes must belong to the specified diagram."
            );
        }
    }

    private void ValidateNoSelfRelation(Guid fromClassId, Guid toClassId)
    {
        if (fromClassId == toClassId)
        {
            throw new InvalidOperationException(
                "Cannot create a relation between a class and itself."
            );
        }
    }

    private async Task ValidateNoDuplicateRelation(
        UmlDiagram diagram,
        Guid fromClassId,
        Guid toClassId,
        CancellationToken ct
    )
    {
        var existingRelations = await Task.WhenAll(
            diagram.RelationsIds.Select(id => _relationsRepository.GetAsync(id, ct))
        );

        var duplicateRelation = existingRelations.FirstOrDefault(r =>
            (r.Direction.FromClassId == fromClassId && r.Direction.ToClassId == toClassId)
            || (
                r.Direction.Bidirectional
                && r.Direction.FromClassId == toClassId
                && r.Direction.ToClassId == fromClassId
            )
        );

        if (duplicateRelation != null)
        {
            throw new InvalidOperationException("A relation between these classes already exists.");
        }
    }

    private UmlClassRelationDirection CreateRelationDirection(
        Guid fromClassId,
        Guid toClassId,
        bool bidirectional
    )
    {
        return new UmlClassRelationDirection(fromClassId, toClassId, bidirectional);
    }

    private UmlMultiplicity? CreateRelationMultiplicity(
        string? multiplicityOrigin,
        string? multiplicityDestination
    )
    {
        if (
            !string.IsNullOrEmpty(multiplicityOrigin)
            && !string.IsNullOrEmpty(multiplicityDestination)
        )
        {
            return new UmlMultiplicity(multiplicityOrigin, multiplicityDestination);
        }
        return null;
    }

    private async Task PersistRelationAndUpdateDiagram(
        UmlClassRelation relation,
        UmlDiagram diagram,
        CancellationToken ct
    )
    {
        await _relationsRepository.SaveAsync(relation, ct);

        var newRelationsIds = new List<Guid>(diagram.RelationsIds) { relation.Id };
        diagram.UpdateRelations(newRelationsIds);
        await _diagramsRepository.SaveAsync(diagram, ct);
    }
}
