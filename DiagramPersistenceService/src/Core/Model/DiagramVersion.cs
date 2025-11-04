namespace Core.Model;

public class DiagramVersion : IValueObject
{
    public int Version { get; }
    public DateTime VersioningDateTime { get; }

    public DiagramVersion(int version, DateTime versioningDateTime)
    {
        Version = version;
        VersioningDateTime = versioningDateTime;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DiagramVersion other) return false;
        return Version == other.Version && VersioningDateTime == other.VersioningDateTime;
    }

    public override int GetHashCode() => HashCode.Combine(Version, VersioningDateTime);
}
