using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SourceTreeBookmarkCreator.Models;

namespace SourceTreeBookmarkCreator
{
    /// <inheritdoc />
    public class PrepareTreeViewNodes : IPrepareTreeViewNodes
    {
        private readonly IDirectoriesToScan _directoriesToScan;
        private readonly ITreeViewNodes _treeViewNodes;
        private readonly IWalkTheDirectoryTree _walkTheDirectoryTree;
        /// <summary>
        /// Constructor
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
                
                if (directoriesToScan.Any())
                {
                    foreach (var arg in directoriesToScan)
                    {
                        if (Directory.Exists(arg))
                        {
                            _treeViewNodes.Value.AddRange(_walkTheDirectoryTree.ValueFor(arg));
                        }
                    }
                }
                else
                {
                    var rootPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    _treeViewNodes.Value.AddRange(_walkTheDirectoryTree.ValueFor(rootPath));
                }

                return _treeViewNodes.Value;
            }
        }
    }
}