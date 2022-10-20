using EvilBaschdi.Core;
using SourceTreeBookmarkCreator.Models;

namespace SourceTreeBookmarkCreator;

/// <inheritdoc />
public interface IWalkTheDirectoryTree : IValueFor<string, List<TreeViewNode>>
{
}