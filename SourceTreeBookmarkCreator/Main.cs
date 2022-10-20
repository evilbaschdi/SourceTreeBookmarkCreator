namespace SourceTreeBookmarkCreator;

/// <inheritdoc />
public class Main : IMain
{
    private readonly IBackupExistingBookmarksFile _backupExistingBookmarksFile;
    private readonly IWriteFileForNodes _writeFileForNodes;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="backupExistingBookmarksFile"></param>
    /// <param name="writeFileForNodes"></param>
    public Main(IBackupExistingBookmarksFile backupExistingBookmarksFile, IWriteFileForNodes writeFileForNodes)
    {
        _backupExistingBookmarksFile = backupExistingBookmarksFile ?? throw new ArgumentNullException(nameof(backupExistingBookmarksFile));
        _writeFileForNodes = writeFileForNodes ?? throw new ArgumentNullException(nameof(writeFileForNodes));
    }

    /// <inheritdoc />
    public void Run()
    {
        _backupExistingBookmarksFile.Run();
        _writeFileForNodes.Run();
    }
}