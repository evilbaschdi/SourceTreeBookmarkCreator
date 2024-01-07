using SourceTreeBookmarkCreator.Models;
using static System.Console;

namespace SourceTreeBookmarkCreator.Internal;

/// <inheritdoc />
public class PrepareTreeViewNodes : IPrepareTreeViewNodes
{
    private readonly IDirectoriesToScan _directoriesToScan;
    private readonly ITreeViewNodes _treeViewNodes;
    private readonly IWalkTheDirectoryTree _walkTheDirectoryTree;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="directoriesToScan"></param>
    /// <param name="treeViewNodes"></param>
    /// <param name="walkTheDirectoryTree"></param>
    public PrepareTreeViewNodes(IDirectoriesToScan directoriesToScan, ITreeViewNodes treeViewNodes, IWalkTheDirectoryTree walkTheDirectoryTree)
    {
        _directoriesToScan = directoriesToScan ?? throw new ArgumentNullException(nameof(directoriesToScan));
        _treeViewNodes = treeViewNodes ?? throw new ArgumentNullException(nameof(treeViewNodes));
        _walkTheDirectoryTree = walkTheDirectoryTree ?? throw new ArgumentNullException(nameof(walkTheDirectoryTree));
    }

    /// <inheritdoc />
    public List<TreeViewNode> Value
    {
        get
        {
            var directoriesToScan = _directoriesToScan.Value;

            if (!directoriesToScan.Any())
            {
                WriteLine("No paths found to process!");
            }

            WriteLine();
            WriteLine($"📁 Processing paths {string.Join(", ", directoriesToScan)}...");

            foreach (var directoryToScan in directoriesToScan.Where(Directory.Exists))
            {
                _treeViewNodes.Value.AddRange(_walkTheDirectoryTree.ValueFor((directoryToScan, string.Empty)));
            }

            return _treeViewNodes.Value;
        }
    }
}