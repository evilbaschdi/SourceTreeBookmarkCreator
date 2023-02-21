using EvilBaschdi.Core;
using EvilBaschdi.Core.Internal;
using JetBrains.Annotations;

namespace SourceTreeBookmarkCreator.Internal;

/// <inheritdoc cref="IDirectoriesToScan" />
/// <inheritdoc cref="CachedValue{T}" />
public class DirectoriesToScan : CachedValue<List<string>>, IDirectoriesToScan
{
    private readonly IReadKeyFromConsole _readKeyFromConsole;
    private readonly string[] _args;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="readKeyFromConsole"></param>
    /// <param name="args"></param>
    public DirectoriesToScan([NotNull] IReadKeyFromConsole readKeyFromConsole, [NotNull] string[] args)
    {
        _readKeyFromConsole = readKeyFromConsole ?? throw new ArgumentNullException(nameof(readKeyFromConsole));
        _args = args ?? throw new ArgumentNullException(nameof(args));
    }

    /// <inheritdoc />
    protected override List<string> NonCachedValue
    {
        get
        {
            var pathsFromArgs = _args.ToList();

            if (pathsFromArgs.Any())
            {
                return pathsFromArgs;
            }

            var value = _readKeyFromConsole.ValueFor("Please enter valid paths separated by ; and press enter");
            return value.Split(';').ToList();
        }
    }
}