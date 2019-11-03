using System;
using System.IO;
using EvilBaschdi.Core;

namespace SourceTreeBookmarkCreator
{
    /// <inheritdoc cref="IOutputPath" />
    /// <inheritdoc cref="CachedValue{T}" />
    public class OutputPath : CachedValue<string>, IOutputPath
    {
        /// <inheritdoc />
        protected override string NonCachedValue => Path.Combine(Environment.GetEnvironmentVariable("LocalAppData") ?? throw new InvalidOperationException(),
            @"Atlassian\SourceTree", "bookmarks.xml");
    }
}