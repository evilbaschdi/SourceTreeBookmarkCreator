using EvilBaschdi.Core;
using SourceTreeBookmarkCreator.Models;

namespace SourceTreeBookmarkCreator.Internal;

/// <inheritdoc />
public interface IWalkTheDirectoryTree : IValueFor<(string CurrentDirectory, string ParentDirectory), List<TreeViewNode>>
{
}