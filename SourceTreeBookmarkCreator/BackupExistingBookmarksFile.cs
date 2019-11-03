using System;
using System.Diagnostics;
using System.IO;
using System.Security;

namespace SourceTreeBookmarkCreator
{
    /// <inheritdoc />
    public class BackupExistingBookmarksFile : IBackupExistingBookmarksFile
    {
        private readonly IOutputPath _outputPath;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputPath"></param>
        public BackupExistingBookmarksFile(IOutputPath outputPath)
        {
            _outputPath = outputPath ?? throw new ArgumentNullException(nameof(outputPath));
        }

        /// <inheritdoc />
        public void Run()
        {
            try
            {
                if (File.Exists(_outputPath.Value))
                {
                    File.Move(_outputPath.Value, $"{_outputPath}_backup_{DateTime.Now:yyyy-dd-M--HH-mm-ss}");
                }
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
}