using Core.Classes;
using Core.Relations;
using OpenDDD.Domain.Service;

namespace Core.Diagrams;

public class DiagramsDomainService : IDomainService
{
    private readonly IRepository<UmlDiagram, Guid> _diagramsRepository;
    private readonly IRepository<UmlClass, Guid> _classesRepository;
    private readonly IRepository<UmlClassRelation, Guid> _relationsRepository;

    public DiagramsDomainService(
        IRepository<UmlDiagram, Guid> diagramsRepository,
        IRepository<UmlClass, Guid> classesRepository,
        IRepository<UmlClassRelation, Guid> relationsRepository
    )
    {
        _diagramsRepository = diagramsRepository;
        _classesRepository = classesRepository;
        _relationsRepository = relationsRepository;
    }
}
