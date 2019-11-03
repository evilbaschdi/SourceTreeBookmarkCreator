using System;
using static System.Console;

namespace SourceTreeBookmarkCreator
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once ArrangeTypeModifiers
    class Program
    {
        /// <summary>
        ///     Finds .git repos on disk and creates a SourceTree bookmarks file with bookmark folders and bookmark for each
        ///     location
        /// </summary>
        /// <param name="args"></param>
        // ReSharper disable once ArrangeTypeMemberModifiers
        static void Main(string[] args)
        {
            WriteLine("Please make sure SourceTree is closed and press any key:");
            ReadKey();
            WriteLine("Processing...");

            IOutputPath outputPath = new OutputPath();
            IBackupExistingBookmarksFile backupExistingBookmarksFile = new BackupExistingBookmarksFile(outputPath);
            IDirectoriesToScan directoriesToScan = new DirectoriesToScan(args);
            IWalkTheDirectoryTree walkTheDirectoryTree = new WalkTheDirectoryTree();
            ITreeViewNodes treeViewNodes = new TreeViewNodes();
            IPrepareTreeViewNodes prepareTreeViewNodes = new PrepareTreeViewNodes(directoriesToScan, treeViewNodes, walkTheDirectoryTree);
            IWriteFileForNodes writeFileForNodes = new WriteFileForNodes(prepareTreeViewNodes, outputPath);

            IMain main = new Main(backupExistingBookmarksFile, writeFileForNodes);
            main.Run();

            ForegroundColor = ConsoleColor.Green;
            WriteLine("All Done!");
            ReadKey();
        }
    }
}