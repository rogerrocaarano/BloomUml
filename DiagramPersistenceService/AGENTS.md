# Agents instructions

## Project Context

This project is a microservice designed to manage the persistence of UML
diagrams. The repository is structured to separate concerns clearly:

-   **/docs**: This directory contains documentation, including **Mermaid
    diagrams**. These diagrams serve as a primary source of context for
    understanding business requirements and system design.
-   **/src**: This directory contains the source code in a .NET solution, with a
    single project estructured in a Domain-Driven Design (DDD) architecture
    style.

## Generation Rules

### General Context

-   Always analyze the Mermaid diagrams located in the `/docs` folder as the
    primary context for understanding functional requirements before generating
    code.

### Core Project (Domain-Driven Design Principles)

-   Implement domain models using **Aggregate Roots**, **Entities**, and **Value
    Objects** within the **Core** project.
-   Enforce encapsulation by ensuring that external objects can only hold
    references to the **Aggregate Root**.

## External Library Dependencies

The project leverages specific frameworks to enforce architecture; **do not**
introduce new libraries for a purpose already covered by an existing one.

-   Utilize the **OpenDDD** library for implementing tactical DDD patterns.
-   Utilize the **FastEndpoints** library for all API endpoints; **do not** use
    standard .NET MVC Controllers or Minimal APIs.
