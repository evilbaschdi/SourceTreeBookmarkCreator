using SourceTreeBookmarkCreator.Models;

namespace SourceTreeBookmarkCreator.Internal;

/// <inheritdoc />
public class WalkTheDirectoryTree : IWalkTheDirectoryTree
{
    /// <inheritdoc />
    public List<TreeViewNode> ValueFor(string directory)
    {
        if (directory == null)
        {
            throw new ArgumentNullException(nameof(directory));
        }

        var nodes = new List<TreeViewNode>();

        var tldGitFolders = Directory.GetDirectories(directory, ".git", SearchOption.TopDirectoryOnly);
        if (tldGitFolders.Any())
        {
            var bookmarkNode = new BookmarkNode
                               {
                                   Name = new DirectoryInfo(directory).Name,
                                   Path = directory,
                                   IsLeaf = true
                               };
            nodes.Add(bookmarkNode);
        }

        if (Directory.GetDirectories(directory, ".git", SearchOption.AllDirectories).Length.Equals(tldGitFolders.Length))
        {
            return nodes;
        }

        var folderNode = new BookmarkFolderNode
                         {
                             Name = new DirectoryInfo(directory).Name,
                             IsLeaf = false
                         };

        var subDirectories = Directory.GetDirectories(directory);
        foreach (var subDirectory in subDirectories)
        {
            folderNode.Children.AddRange(ValueFor(subDirectory));
        }

        nodes.Add(folderNode);

        return nodes;
    }
}