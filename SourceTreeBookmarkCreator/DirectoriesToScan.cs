using System;
using EvilBaschdi.Core;

namespace SourceTreeBookmarkCreator
{
    /// <inheritdoc cref="IDirectoriesToScan" />
    /// <inheritdoc cref="CachedValue{T}" />
    public class DirectoriesToScan : CachedValue<string[]>, IDirectoriesToScan
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="args"></param>
        public DirectoriesToScan(string[] args)
        {
            NonCachedValue = args ?? throw new ArgumentNullException(nameof(args));
        }

        /// <inheritdoc />
        protected override string[] NonCachedValue { get; }
    }
}