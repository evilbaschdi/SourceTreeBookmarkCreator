using EvilBaschdi.Core;

namespace SourceTreeBookmarkCreator;

/// <inheritdoc cref="IDirectoriesToScan" />
/// <inheritdoc cref="CachedValue{T}" />
public class DirectoriesToScan : CachedValue<List<string>>, IDirectoriesToScan
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="args"></param>
    public DirectoriesToScan(string[] args)
    {
        NonCachedValue = args?.ToList() ?? throw new ArgumentNullException(nameof(args));
    }

    /// <inheritdoc />
    protected override List<string> NonCachedValue { get; }
}