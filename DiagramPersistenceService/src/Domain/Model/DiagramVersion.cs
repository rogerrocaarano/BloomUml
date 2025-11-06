using OpenDDD.Domain.Model;

namespace DiagramPersistenceServiceApi.Domain.Model;

/// <summary>
/// Represents a version of a diagram, including the version number and the date/time it was versioned.
/// </summary>
public class DiagramVersion : IValueObject
{
    /// <summary>
    /// Gets the version number.
    /// </summary>
    public int Version { get; }

    /// <summary>
    /// Gets the date and time when this version was created.
    /// </summary>
    public DateTime VersioningDateTime { get; }

    /// <summary>
    /// Initializes a new instance of the DiagramVersion class.
    /// </summary>
    /// <param name="version">The version number.</param>
    /// <param name="versioningDateTime">The date and time of versioning.</param>
    public DiagramVersion(int version, DateTime versioningDateTime)
    {
        Version = version;
        VersioningDateTime = versioningDateTime;
    }

    /// <summary>
    /// Creates the initial version of a diagram.
    /// </summary>
    /// <returns>A DiagramVersion with version 1 and the current UTC date/time.</returns>
    public static DiagramVersion Initial() => new(1, DateTime.UtcNow);

    /// <summary>
    /// Increments the version number of the given diagram version.
    /// </summary>
    /// <param name="currentVersion">The current version to increment.</param>
    /// <returns>A new DiagramVersion with the incremented version number and current UTC date/time.</returns>
    public static DiagramVersion Increment(DiagramVersion currentVersion) =>
        new(currentVersion.Version + 1, DateTime.UtcNow);

    /// <summary>
    /// Determines whether the specified object is equal to the current DiagramVersion.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns>true if the specified object is equal to the current instance; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is not DiagramVersion other)
            return false;
        return Version == other.Version && VersioningDateTime == other.VersioningDateTime;
    }

    /// <summary>
    /// Returns a hash code for the current DiagramVersion.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(Version, VersioningDateTime);
}
