using OpenDDD.Domain.Model;

namespace DiagramPersistenceServiceApi.Domain.Model;

/// <summary>
/// Represents the position of a UML element in a diagram.
/// </summary>
public class UmlPosition : IValueObject
{
    /// <summary>
    /// Gets the X coordinate of the position.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Gets the Y coordinate of the position.
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Initializes a new instance of the UmlPosition class.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    public UmlPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current UmlPosition.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not UmlPosition other)
            return false;
        return X == other.X && Y == other.Y;
    }

    /// <summary>
    /// Returns a hash code for the current UmlPosition.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(X, Y);
}
