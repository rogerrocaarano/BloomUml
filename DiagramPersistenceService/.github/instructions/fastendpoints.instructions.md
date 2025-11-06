---
applyTo: "**/**/WebApi/**/**.cs"
---
# FastEndpoints Instructions

## Project Context

This project uses FastEndpoints for building APIs. FastEndpoints is a
developer-friendly alternative to Minimal APIs and Controllers. It follows a
vertical slice architecture approach, where each endpoint is self-contained and
includes all necessary logic.

## Architecture Guidelines

### Endpoint Structure

Each endpoint should be organized in its own directory following this structure:

```
Features/
  FeatureName/
    EndpointName/
      EndpointNameEndpoint.cs
      EndpointNameDto.cs
      EndpointNameMapper.cs (optional)
      EndpointNameValidator.cs (optional)
```

### Naming Conventions

1. **Endpoints**: Name your endpoint classes with the suffix `Endpoint`

    ```csharp
    public class CreateDiagramEndpoint : Endpoint<CreateDiagramRequest, CreateDiagramResponse>
    ```

2. **DTOs**: Use the suffixes `Request` and `Response` for DTOs
    ```csharp
    public class CreateDiagramRequest
    {
        public string Name { get; init; } = string.Empty;
    }
    ```

### Implementation Rules

1. **One File Per Class**: Keep each class in its own file
2. **Configuration**: Override `Configure()` to set up the endpoint

    ```csharp
    public override void Configure()
    {
        Post("/api/diagrams");
        AllowAnonymous(); // or .RequireAuthorization();
        Description(d => d
            .WithTags("Diagrams")
            .ProducesValidationProblem()
            .Produces<CreateDiagramResponse>(201)
        );
    }
    ```

3. **Validation**: Create separate validator classes when needed
    ```csharp
    public class CreateDiagramValidator : Validator<CreateDiagramRequest>
    {
        public CreateDiagramValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
    ```

### Core Principles

1. **Separation of Concerns**:

    - Keep endpoints focused on request/response handling
    - Delegate business logic to domain services
    - Use mappers for DTO-to-Domain object conversions

2. **Error Handling**:
    - Use `ThrowIfNull()` for null checks
    - Use `ValidationFailures.Add()` for validation errors
    - Return appropriate HTTP status codes

### Example Implementation

```csharp
public class CreateDiagramEndpoint : Endpoint<CreateDiagramRequest, CreateDiagramResponse>
{
    private readonly IDiagramsDomainService _diagramsService;

    public CreateDiagramEndpoint(IDiagramsDomainService diagramsService)
    {
        _diagramsService = diagramsService;
    }

    public override void Configure()
    {
        Post("/api/diagrams");
        AllowAnonymous();
        Description(d => d
            .WithTags("Diagrams")
            .Produces<CreateDiagramResponse>(201)
        );
    }

    public override async Task HandleAsync(CreateDiagramRequest req, CancellationToken ct)
    {
        var diagram = await _diagramsService.CreateDiagramAsync(req.Name, ct);

        var response = new CreateDiagramResponse(
            Id: diagram.Id,
            Name: diagram.Name
        );

        await SendCreatedAtAsync<GetDiagramEndpoint>(
            new { id = diagram.Id },
            response,
            generateAbsoluteUrl: true,
            cancellation: ct
        );
    }
}
```

## Best Practices

1. **Request Validation**:

    - Always validate input using FluentValidation
    - Keep validation rules close to the business requirements
    - Use custom validators for complex rules

2. **Response Generation**:

    - Use appropriate status codes (201 for creation, 204 for deletion)
    - Include hypermedia links when relevant
    - Use proper content negotiation

3. **Security**:

    - Be explicit about authorization requirements
    - Use `[Claims]` attribute for fine-grained permissions
    - Validate all user input

4. **Documentation**:
    - Use XML comments for public APIs
    - Configure proper OpenAPI descriptions
    - Include examples in documentation when helpful

## Common Pitfalls to Avoid

1. Don't mix business logic in endpoints
2. Don't use static state
3. Don't bypass the validation pipeline
4. Don't return domain entities directly
5. Don't use constructor injection for stateful dependencies

## Testing Guidelines

1. Create separate test classes for endpoints
2. Use the FastEndpoints testing utilities
3. Mock external dependencies
4. Test both successful and error scenarios
5. Validate response status codes and content
