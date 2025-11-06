---
applyTo: "**.cs"
---

# OPENDDD.net library usage instructions

## Building Blocks Overview

-   OpenDDD.NET provides implementations of the tactical design building blocks
    used in Domain-Driven Design (DDD).
-   Each block serves a specific purpose in organizing business logic, enforcing
    boundaries, and maintaining consistency.
-   OpenDDD.NET provides implementations for Aggregate Roots, Entities, and
    Value Objects to maintain consistency and encapsulation.

### Aggregate Root

-   An Aggregate Root is the entry point to an aggregate, enforcing invariants
    and ensuring all modifications go through it.
-   In OpenDDD, this is implemented by inheriting from
    **AggregateRootBase<TId>**.
-   Creation should be handled via **public static factory methods** (e.g.,
    `Create()`).
-   Constructors should be kept **private** to enforce creation rules.
-   All modifications to the aggregate's internal state must be exposed through
    **public methods** on the Root.

### Entity

-   An Entity has a unique identity and a lifecycle managed by its Aggregate
    Root.
-   Implement Entities by inheriting from **EntityBase<TId>**.
-   Like Aggregate Roots, Entities should use **private constructors** and
    **public static factory methods** (e.g., `Create()`) to ensure valid
    instantiation.
-   An Entity's consistency and lifecycle are managed by its parent **Aggregate
    Root**.

### Value Object

-   A Value Object represents a concept with no unique identity, defined only by
    its attributes.
-   Implement Value Objects by inheriting from **IValueObject**.
-   They must be **immutable**; all properties should be **read-only** (e.g.,
    `public string Currency { get; }`).
-   All attributes must be provided upon creation via a **public constructor**.

### Repositories

-   Use repositories to provide a collection-like interface for retrieving and
    persisting Aggregates.
-   All repositories must implement the IRepository<TAggregateRoot, TId>
    interface.
-   This implementation ensures a consistent API and clear naming conventions.
-   Ensure the generic type TAggregateRoot implements IAggregateRoot<TId>.
-   Implement the standard data access methods: GetAsync, FindAsync,
    FindWithAsync, FindAllAsync, SaveAsync, and DeleteAsync.
-   Use Expression<Func<TAggregateRoot, bool>> as the parameter type for filter
    queries in FindWithAsync.
-   Be aware that aggregates are stored as serialized JSON documents in the
    database.

### Actions & Commands

-   Separate intent (using Commands) from execution (using Actions).
-   Commands represent an explicit request to perform an operation.
-   All Commands must implement the ICommand interface.
-   Commands should be simple data structures (DTOs) and must not contain any
    business logic.
-   Actions handle a command and execute the corresponding application logic.
-   Actions must implement the IAction<TCommand, TResult> interface (or
    IAction<TCommand> if no value is returned).
-   Actions should be stateless.
-   Implement the primary logic for the operation within the ExecuteAsync method
    of the Action.
-   Actions drive domain logic by delegating tasks to injected Domain Services
    or Aggregate Roots.

### Events and Publishing

-   Use events to capture state changes and enable decoupled communication.
-   Define Domain Events to represent significant changes within the domain.
-   Domain Events must implement the IDomainEvent interface.
-   Define Integration Events to communicate between bounded contexts.
-   Integration Events must implement the IIntegrationEvent interface.
-   Use the IDomainPublisher interface to publish Domain Events.
-   Use the IIntegrationPublisher interface to publish Integration Events.
-   When publishing from a Domain Service, inject the publisher
    (IDomainPublisher or IIntegrationPublisher) via the constructor.
-   In a Domain Service, publish the event after the state has been successfully
    persisted (e.g., after calling SaveAsync on a repository).
-   When publishing from an Aggregate Root, pass the IDomainPublisher as a
    method parameter (e.g., in ChangeNameAsync) to avoid infrastructure
    dependencies in the aggregate.

### Domain Services

-   Use Domain Services to implement domain-specific logic that does not
    naturally fit within an aggregate.
-   Ensure Domain Services belong to the domain layer and contain pure business
    logic.
-   Define an interface for the service (e.g., ICustomerDomainService) that
    inherits from the base IDomainService interface.
-   Implement the service as a stateless class that operates on domain objects.
-   Use constructor injection to provide the service with its required
    dependencies, such as Repositories (e.g., ICustomerRepository) or Publishers
    (e.g., IDomainPublisher).
-   Use Domain Services when business rules need to be shared across multiple
    use cases.
-   Do not use a service for simple operations that should be encapsulated
    within the aggregate root.
-   Do not use a service for coordinating application workflows; use Actions and
    domain events for that purpose.
-   Do not implement infrastructure concerns (like logging or email) in a Domain
    Service.
