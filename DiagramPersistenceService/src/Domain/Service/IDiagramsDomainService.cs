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
}
