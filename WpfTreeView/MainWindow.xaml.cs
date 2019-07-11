using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region on Loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Get every logical drive on machine
            foreach(var drive in Directory.GetLogicalDrives())
            {
                //create new item for it
                var item = new TreeViewItem()
                {
                    //set the header
                    Header = drive,
                    //set the path
                    Tag = drive
                };
            //add null item, purpose for it is to get expand this folder and apply appropriate logic 
            item.Items.Add(null);
                //listen out for item being expanded
                item.Expanded += Folder_Expanded;
                //add to tree view
                folderView.Items.Add(item);
            }
        }

        #endregion

        #region Folder Expanded
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial checks
            //now here first get the item itself
            var item = (TreeViewItem)sender;
            //if item contain only dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;
            //Clear dummy data
            item.Items.Clear();
            //Get full path
            var fullPath = (string)item.Tag;
            #endregion

            #region Get Folders
            //create blank list for directories
            var directories = new List<String>();
            //try and get directories from the folder
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch { }

            //For each directory... we want to to add all directory to item itself
            directories.ForEach(directoryPath => {
                var subitem = new TreeViewItem()
                {
                    //directory path will contain full path so make sure to grab only last part that will be used in header, however tag will contain full path
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath
                };
                //do same as above give dummy item so we can expand
                subitem.Items.Add(null);
                //handle expanding
                subitem.Expanded += Folder_Expanded;
                //now add subitem to parent item
                item.Items.Add(subitem);

            });
            #endregion

            #region Get Files
            //create blank list for directories
            var files = new List<String>();
            //try and get files from the folder
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }
            }
            catch { }

            //For each file... we want to to add all file to item itself
            files.ForEach(filePath => {
                var subitem = new TreeViewItem()
                {
                    //file Path will contain full path so make sure to grab only last part that will be used in header, however tag will contain full path
                    Header = GetFileFolderName(filePath),
                    Tag = filePath
                };
                //now add subitem to parent item
                item.Items.Add(subitem);

            });
            #endregion
        }

        #endregion
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
