## Purpose

This file gives concise, repo-specific guidance to AI coding assistants to be
immediately productive in the DiagramPersistenceService codebase.

## High-level architecture (what to know first)

- This is a small microservice for persisting UML diagrams. See
  `docs/domain.mmd` (Mermaid) for the canonical domain model — core aggregates
  include `UmlDiagram`, `UmlClass`, `UmlClassRelation`, and value objects like
  `UmlPosition`.
- The solution is split into two projects under `src/`:
  - `Core` — domain logic following Domain-Driven Design (Aggregate Roots,
    Entities, Value Objects). Look in `src/Core/Model` and `src/Core/Services`.
  - `Api` — HTTP surface built with a Vertical Slice approach and FastEndpoints.
    See `src/Api/Program.cs` and `src/Api/Api.http` for examples.

## Important conventions and rules

- Primary source of truth for domain shapes: `docs/domain.mmd`. Consult/update
  it before changing domain code.
- Core must implement domain concepts as Aggregates. External code should hold
  references only to Aggregate Roots — follow the guidance already in
  `AGENTS.md`.
- API slice pattern: co-locate request/response DTOs, handlers, and mapping
  logic per feature. Do NOT add MVC Controllers; use FastEndpoints and OpenDDD
  patterns.
- Do not introduce new libraries for responsibilities already covered: the repo
  relies on OpenDDD for tactical DDD and FastEndpoints for endpoints — prefer
  using them.

## Developer workflows (concrete commands)

- Restore dependencies: `dotnet restore` (run at repo root).
- Build solution: `dotnet build src/DiagramPersistenceService.sln`.
- Run the API locally: `dotnet run --project src/Api` (Program.cs registers
  OpenAPI in Development).
- Use `src/Api/Api.http` for quick HTTP examples (VS Code REST Client
  compatible).
- Configuration: `src/Api/appsettings.json` and `appsettings.Development.json`.
  Use `launchSettings.json` for debugger setup.

## Key files to inspect when making changes

- Domain model and canonical shapes: `docs/domain.mmd` (Mermaid class diagram).
- Domain code and DDD primitives: `src/Core/Model`, `src/Core/Services`, and
  `src/Core/GlobalUsings.cs`.
- API entry and sample endpoints: `src/Api/Program.cs`, `src/Api/Api.http`,
  `src/Api/appsettings*.json`.
- Solution file: `src/DiagramPersistenceService.sln`.
- Project files: `src/Core/Core.csproj`, `src/Api/Api.csproj`.

## Example patterns to follow (concrete snippets)

- Feature slice: create `src/Api/Features/<FeatureName>/` with `Request`,
  `Response`, and handler classes, and register any DI in `Program.cs` or via
  extension methods.
- Domain change: if you add a new value object, update `docs/domain.mmd` and add
  the corresponding type under `src/Core/Model` as an immutable Value Object.

## Safety and scope

- Make minimal, localized changes. Prefer adding new feature slices over
  changing global wiring.
- If a change requires a new dependency, document why OpenDDD/FastEndpoints
  can't be used and get approval.

## What to ask the human

- If the domain model in `docs/domain.mmd` differs from code, ask which is
  authoritative before making changes.
- If adding persistence or external infra (DB, blob storage), ask where
  secrets/config should live and whether to extend the existing appsettings
  pattern.

---

If any part of this guidance is unclear or you want more examples (e.g., a
sample FastEndpoint slice using OpenDDD types), tell me which area and I'll
expand with concrete code examples.
