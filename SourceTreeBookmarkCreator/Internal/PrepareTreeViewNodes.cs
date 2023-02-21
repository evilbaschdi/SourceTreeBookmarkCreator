using SourceTreeBookmarkCreator.Models;

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
                Console.WriteLine("No paths found to process!");
            }

            Console.WriteLine("Processing...");

            foreach (var arg in directoriesToScan.Where(Directory.Exists))
            {
                _treeViewNodes.Value.AddRange(_walkTheDirectoryTree.ValueFor(arg));
            }

            return _treeViewNodes.Value;
        }
    }
}