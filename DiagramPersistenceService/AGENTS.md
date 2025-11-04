# Agents instructions

## Project Context

This project is a microservice designed to manage the persistence of UML
diagrams. The repository is structured to separate concerns clearly:

- **/docs**: This directory contains documentation, including **Mermaid
  diagrams**. These diagrams serve as a primary source of context for
  understanding business requirements and system design.
- **/src**: This directory contains the source code in a .NET solution, which is
  divided into two main projects:
  - **Core**: This project holds the business logic of the application. It
    follows the principles of **Domain-Driven Design (DDD)**.
  - **Api**: This project exposes the application's functionality via an API. It
    is built using a **Vertical Slice Architecture**.

## Generation Rules

### General Context

- Always analyze the Mermaid diagrams located in the `/docs` folder as the
  primary context for understanding functional requirements before generating
  code.

### Core Project (Domain-Driven Design Principles)

- Implement domain models using **Aggregate Roots**, **Entities**, and **Value
  Objects** within the **Core** project.
- Enforce encapsulation by ensuring that external objects can only hold
  references to the **Aggregate Root**.

### Api Project (Vertical Slice Architecture Principles)

- Structure the **Api** project using a **slice architecture**; each feature or
  use case must be co-located in its own folder.
- Implement API endpoints using a minimal, endpoint-focused approach (avoiding
  traditional MVC **Controllers**).
- Each _feature slice_ should contain all components related to that feature
  (e.g., the endpoint definition, request/response DTOs, and any specific
  handlers or logic).

## External Library Dependencies

The project leverages specific frameworks to enforce architecture; **do not**
introduce new libraries for a purpose already covered by an existing one.

- Utilize the **OpenDDD** library for implementing tactical DDD patterns.
- Utilize the **FastEndpoints** library for all API endpoints; **do not** use
  standard .NET MVC Controllers or Minimal APIs.
