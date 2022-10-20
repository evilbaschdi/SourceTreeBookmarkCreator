namespace SourceTreeBookmarkCreator.Models;

/// <remarks />
public class BookmarkNode : TreeViewNode
{
    // ReSharper disable UnusedMember.Global
    /// <remarks />
    public string Path { get; init; }

    /// <remarks />

    public string RepoType { get; set; } = "Git";

    /// <remarks />
    public override string ToString() => $"Name: {Name} Path: {Path}";
    // ReSharper restore UnusedMember.Global
}