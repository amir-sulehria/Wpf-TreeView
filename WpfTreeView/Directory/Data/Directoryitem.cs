using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{
    /// <summary>
    /// information about directory item such as file, drive or folder
    /// </summary>

    class Directoryitem
    {
        //the type of this item
        public DirectoryItemType Type { get; set; }
        //The absolute path to this item
        public string FullPath { get; set; }
        //Name of this directory item
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
    }
}
