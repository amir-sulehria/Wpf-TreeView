using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfTreeView
{
    /// <summary>
    /// a general class to query information about directory
    /// </summary>
    public static class DirectoryStructure
    {
        //Get every logical drive on machine
        internal static List<Directoryitem> GetLogicalDrives()
        {
            return Directory.GetLogicalDrives().Select(drive => new Directoryitem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }
        //Gets Directory top-level content
        internal static List<Directoryitem> GetDirectoryContents(string fullPath)
        {
            //create empty list
            var items = new List<Directoryitem>();

            #region Get Folders
            //try and get directories from the folder
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new Directoryitem { FullPath = dir, Type = DirectoryItemType.Folder }));
                }
            }
            catch { }
            #endregion

            #region Get Files
            //try and get files from the folder
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(f => new Directoryitem { FullPath = f, Type = DirectoryItemType.File }));
                }
            }
            catch { }
            #endregion

            return items;

        }

        public static string GetFileFolderName(string path)
        //finds file or folder name from full path
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }
            //just to make sure while processing we have same type slashes, \\ means escape special character
            var normalizedPath = path.Replace('/', '\\');
            //find last backslash in path
            var lastIndex = normalizedPath.LastIndexOf('\\');
            //if lastINdex = -1 it means it is already name so return 
            if (lastIndex <= 0)
                return path;
            return path.Substring(lastIndex + 1);
        }
    }
}
