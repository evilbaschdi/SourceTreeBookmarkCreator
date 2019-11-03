namespace SourceTreeBookmarkCreator.Models
{
    /// <remarks />
    public class BookmarkNode : TreeViewNode
    {
        /// <remarks />
        public string Path { get; set; }

        /// <inheritdoc />
        public override string ToString() => $"Name: {Name} Path: {Path}";
    }
}