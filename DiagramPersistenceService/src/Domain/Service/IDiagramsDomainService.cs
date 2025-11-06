using System;
using DiagramPersistenceServiceApi.Domain.Model;
using OpenDDD.Domain.Service;

namespace DiagramPersistenceServiceApi.Domain.Service;

public interface IDiagramsDomainService : IDomainService
{
    // <summary>
    /// Creates a new UML diagram with the specified name.
    /// </summary>
    /// <param name="ownerId">The ID of the owner of the diagram.</param>
    /// <param name="name">The name of the new diagram.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The created UML diagram.</returns>
    /// <exception cref="InvalidOperationException">Thrown when a diagram with the same name and owner already exists.</exception>
    public Task<UmlDiagram> CreateDiagramAsync(
        Guid ownerId,
        string name,
        CancellationToken ct = default
    );

    /// <summary>
    /// Creates a new UML class in the specified diagram.
    /// </summary>
    /// <param name="diagramId">The ID of the diagram to add the class to.</param>
    /// <param name="name">The name of the new class.</param>
    /// <param name="position">The position of the class in the diagram.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The created UML class.</returns>
    /// <exception cref="InvalidOperationException">Thrown when a class with the same name already exists in the diagram.</exception>
    public Task<UmlClass> CreateClassAsync(
        Guid diagramId,
        string name,
        UmlPosition position,
        CancellationToken ct = default
    );

    /// <summary>
    /// Adds an attribute to the specified class.
    /// </summary>
    /// <param name="classId">The ID of the class to add the attribute to.</param>
    /// <param name="visibility">The visibility of the attribute.</param>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="type">The type of the attribute.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The created UML attribute.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the class does not exist or an attribute with the same name already exists in the class.</exception>
    public Task<UmlAttribute> AddAttributeToClassAsync(
        Guid classId,
        UmlVisibility visibility,
        string name,
        string type,
        CancellationToken ct = default
    );

    /// <summary>
    /// Adds a method to the specified class.
    /// </summary>
    /// <param name="classId">The ID of the class to add the method to.</param>
    /// <param name="visibility">The visibility of the method.</param>
    /// <param name="name">The name of the method.</param>
    /// <param name="returnType">The return type of the method.</param>
    /// <param name="parameters">The parameters of the method (optional).</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The created UML method.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the class does not exist or a method with the same name already exists in the class.</exception>
    public Task<UmlMethod> AddMethodToClassAsync(
        Guid classId,
        UmlVisibility visibility,
        string name,
        string returnType,
        ICollection<UmlMethodParameter>? parameters = null,
        CancellationToken ct = default
    );

    /// <summary>
    /// Creates a relation between two classes in the specified diagram.
    /// </summary>
    /// <param name="diagramId">The ID of the diagram to add the relation to.</param>
    /// <param name="fromClassId">The ID of the class from which the relation originates.</param>
    /// <param name="toClassId">The ID of the class to which the relation points.</param>
    /// <param name="relationType">The type of the relation.</param>
    /// <param name="bidirectional">Whether the relation is bidirectional.</param>
    /// <param name="multiplicityOrigin">The multiplicity at the origin end (optional).</param>
    /// <param name="multiplicityDestination">The multiplicity at the destination end (optional).</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The created UML class relation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the diagram or classes do not exist, or when trying to create a relation between a class and itself.</exception>
    public Task<UmlClassRelation> CreateClassRelationAsync(
        Guid diagramId,
        Guid fromClassId,
        Guid toClassId,
        UmlClassRelationType relationType,
        bool bidirectional = false,
        string? multiplicityOrigin = null,
        string? multiplicityDestination = null,
        CancellationToken ct = default
    );
}
