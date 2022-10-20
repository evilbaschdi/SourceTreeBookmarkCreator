using EvilBaschdi.Core;
using SourceTreeBookmarkCreator.Models;

namespace SourceTreeBookmarkCreator;

/// <inheritdoc cref="ITreeViewNodes" />
/// <inheritdoc cref="CachedValue{T}" />
public class TreeViewNodes : CachedValue<List<TreeViewNode>>, ITreeViewNodes
{
    /// <inheritdoc />
    protected override List<TreeViewNode> NonCachedValue => new();
}