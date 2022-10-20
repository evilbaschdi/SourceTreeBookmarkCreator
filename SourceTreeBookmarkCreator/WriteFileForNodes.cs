using System.Diagnostics;
using System.Security;
using System.Xml.Serialization;

namespace SourceTreeBookmarkCreator;

/// <inheritdoc />
public class WriteFileForNodes : IWriteFileForNodes
{
    private readonly IOutputPath _outputPath;
    private readonly IPrepareTreeViewNodes _prepareTreeViewNodes;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="prepareTreeViewNodes"></param>
    /// <param name="outputPath"></param>
    public WriteFileForNodes(IPrepareTreeViewNodes prepareTreeViewNodes, IOutputPath outputPath)
    {
        _prepareTreeViewNodes = prepareTreeViewNodes ?? throw new ArgumentNullException(nameof(prepareTreeViewNodes));
        _outputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath));
    }

    /// <inheritdoc />
    public void Run()
    {
        try
        {
            var treeViewNodes = _prepareTreeViewNodes.Value;
            var writer = new XmlSerializer(treeViewNodes.GetType());
            using var file = new StreamWriter(_outputPath.Value);
            writer.Serialize(file, treeViewNodes);
            file.Close();
        }
        catch (UnauthorizedAccessException unauthorizedAccessException) when (!Debugger.IsAttached)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(unauthorizedAccessException.Message);
            Console.ReadKey();
        }
        catch (IOException ioException) when (!Debugger.IsAttached)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ioException.Message);
            Console.ReadKey();
        }
        catch (SecurityException securityException) when (!Debugger.IsAttached)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(securityException.Message);
            Console.ReadKey();
        }
    }
}