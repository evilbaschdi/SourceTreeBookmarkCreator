namespace SourceTreeBookmarkCreator.Models;

/// <inheritdoc />
public class BookmarkFolderNode : TreeViewNode
{
    /// <inheritdoc />
    public override string ToString() => $"FolderName: {Name}";
}