---
applyTo: "**/Core/**/**.cs"
---

# OPENDDD.net library usage instructions

## Building Blocks Overview

- OpenDDD.NET provides implementations of the tactical design building blocks
  used in Domain-Driven Design (DDD).
- Each block serves a specific purpose in organizing business logic, enforcing
  boundaries, and maintaining consistency.
- OpenDDD.NET provides implementations for Aggregate Roots, Entities, and Value
  Objects to maintain consistency and encapsulation.

### Aggregate Root

- An Aggregate Root is the entry point to an aggregate, enforcing invariants and
  ensuring all modifications go through it.
- In OpenDDD, this is implemented by inheriting from **AggregateRootBase<TId>**.
- Creation should be handled via **public static factory methods** (e.g.,
  `Create()`).
- Constructors should be kept **private** to enforce creation rules.
- All modifications to the aggregate's internal state must be exposed through
  **public methods** on the Root.

### Entity

- An Entity has a unique identity and a lifecycle managed by its Aggregate Root.
- Implement Entities by inheriting from **EntityBase<TId>**.
- Like Aggregate Roots, Entities should use **private constructors** and
  **public static factory methods** (e.g., `Create()`) to ensure valid
  instantiation.
- An Entity's consistency and lifecycle are managed by its parent **Aggregate
  Root**.

### Value Object

- A Value Object represents a concept with no unique identity, defined only by
  its attributes.
- Implement Value Objects by inheriting from **IValueObject**.
- They must be **immutable**; all properties should be **read-only** (e.g.,
  `public string Currency { get; }`).
- All attributes must be provided upon creation via a **public constructor**.
