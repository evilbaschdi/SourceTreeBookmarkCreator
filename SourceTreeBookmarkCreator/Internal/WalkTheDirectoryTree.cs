using SourceTreeBookmarkCreator.Models;
using static System.Console;

namespace SourceTreeBookmarkCreator.Internal;

/// <inheritdoc />
public class WalkTheDirectoryTree : IWalkTheDirectoryTree
{
    /// <inheritdoc />
    public List<TreeViewNode> ValueFor((string CurrentDirectory, string ParentDirectory) value)
    {
        var (currentDirectory, parentDirectory) = value;

        ForegroundColor = ConsoleColor.Cyan;

        WriteLine();
        WriteLine($"    📁 Processing path {currentDirectory}...");

        var nodes = new List<TreeViewNode>();
        var directoryName = new DirectoryInfo(currentDirectory).Name;
        var folderNodeName = string.IsNullOrWhiteSpace(parentDirectory) ? directoryName : $"{parentDirectory}\\{directoryName}";

        var tldGitFolders = Directory.GetDirectories(currentDirectory, ".git", SearchOption.TopDirectoryOnly);
        if (tldGitFolders.Any())
        {
            var bookmarkNode = new BookmarkNode
                               {
                                   Name = directoryName,
                                   Path = currentDirectory,
                                   IsLeaf = true
                               };
            WriteLine($"        📂 Created node '{folderNodeName}'...");

            nodes.Add(bookmarkNode);
        }

        if (Directory.GetDirectories(currentDirectory, ".git", SearchOption.AllDirectories).Length.Equals(tldGitFolders.Length))
        {
            return nodes;
        }

        var folderNode = new BookmarkFolderNode
                         {
                             Name = directoryName,
                             IsLeaf = false
                         };

        WriteLine($"📂 Created folder node '{folderNodeName}'...");

        var subDirectories = Directory.GetDirectories(currentDirectory);

        foreach (var subDirectory in subDirectories)
        {
            folderNode.Children.AddRange(ValueFor((subDirectory, directoryName)));
        }

        nodes.Add(folderNode);

        return nodes;
    }
}