# AI Coding Agent Instructions

## Project Overview

This is a microservice that manages UML diagram persistence using Domain-Driven
Design (DDD) principles. The service is built with .NET and follows a strict
architectural style.

## Key Architecture Patterns

### Domain-Driven Design Structure

-   Follows tactical DDD patterns using OpenDDD library
-   Core domain objects are in `Domain/Model/`:
    -   `UmlDiagram` is the main aggregate root
    -   `UmlClass` and `UmlClassRelation` are child aggregates
    -   Value objects (e.g., `UmlPosition`, `UmlVisibility`) for immutable
        concepts
-   Example aggregate relationships in `docs/domain.mmd` diagram
-   Domain models MUST follow OpenDDD base types:
    -   Use `AggregateRootBase` for aggregates
    -   Use `EntityBase` for entities
    -   Use `IValueObject` for value objects

### API Implementation

-   Uses FastEndpoints (NOT MVC Controllers or Minimal APIs)
-   Endpoint pattern (see `Infrastructure/WebAPI/CreateDiagram/`):
    1. DTO for request/response (`*Dto.cs`)
    2. Endpoint class inherits `Endpoint<TRequest, TResponse>`
    3. Configure with `Post/Get/etc(route)` in `Configure()`
    4. Implement logic in `HandleAsync()`
-   Actions in `Application/Actions/` handle business logic
    -   Command objects for input parameters
    -   Return domain objects directly

## Critical Conventions

### Project Structure

```
src/
├── Application/        # Application services and commands
├── Domain/            # Core domain model and interfaces
└── Infrastructure/    # External concerns (API, persistence)
    └── WebAPI/        # Endpoints grouped by feature
```

### Coding Rules

1. Keep aggregates isolated - external code should only reference aggregate
   roots
2. Use domain diagram (`docs/domain.mmd`) as source of truth for model
   relationships
3. In-memory repositories for now (see `Infrastructure/Repositories/`)

### Workflow Tips

1. Start with domain diagram when adding features
2. Create endpoint following FastEndpoints pattern
3. Implement domain logic in Action class
4. Add repository methods as needed

## Integration Points

-   Repositories (current: in-memory, future: persistent)
    -   `IUmlDiagramsRepository`
    -   `IUmlClassesRepository`
    -   `IUmlClassRelationsRepository`
-   Authentication/Authorization (TODO - currently AllowAnonymous)
