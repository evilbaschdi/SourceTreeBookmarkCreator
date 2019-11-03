using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SourceTreeBookmarkCreator.Models
{
    /// <remarks />
    [XmlInclude(typeof(BookmarkNode))]
    [XmlInclude(typeof(BookmarkFolderNode))]
    [Serializable]
    public class TreeViewNode
    {
        /// <remarks />
        public List<TreeViewNode> Children { get; } = new List<TreeViewNode>();

        /// <remarks />
        public bool IsLeaf { get; set; } = true;

        /// <remarks />
        public string Name { get; set; }
    }
}