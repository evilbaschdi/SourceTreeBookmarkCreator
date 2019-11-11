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
        // ReSharper disable UnusedMember.Global
        // ReSharper disable once CollectionNeverQueried.Global
        /// <remarks />
        public List<TreeViewNode> Children { get; } = new List<TreeViewNode>();

        /// <remarks />
        public bool IsExpanded { get; set; }

        /// <remarks />
        public bool IsLeaf { get; set; } = true;

        /// <remarks />
        public int Level { get; set; }

        /// <remarks />
        public string Name { get; set; }
        // ReSharper restore UnusedMember.Global
    }
}