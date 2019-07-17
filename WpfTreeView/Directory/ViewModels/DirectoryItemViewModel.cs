using System.Collections.ObjectModel;
using WpfTreeView;
using System.Linq;
using System;
using System.Windows.Input;

namespace WpfTreeView
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public properties
        //the type of this item
        public DirectoryItemType Type { get; set; }
        //the full path to item
        public string FullPath { get; set; }
        //name of this directory item
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
        //list of all childrens in this collection
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        //if this item can expand or not
        public bool canExpand { get { return this.Type != DirectoryItemType.File; } }
        //check if expanded or not, on clicking ui set will get called
        public bool isExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                //if ui tells to expand
                if (value == true)
                    //Find all children
                    Expand();
                else
                    //if ui wants to close expansion
                    this.clearChildren();
            }
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// the command that we'll bind with ui to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Constructor

        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);
            this.FullPath = fullPath;
            this.Type = type;

            this.clearChildren();
        }

        #endregion

        #region Helper Methods
        //removes all child from list adding a dummy item to show expand icon if required
        private void clearChildren()
        {
            //clear items
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            //show expand arrow only if not file
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);

        }
        #endregion

        //Expand this directory and find all children
        private void Expand()
        {
            //we cannot expand a file so return 
            if (this.Type == DirectoryItemType.File)
                return;
            //find all children
            this.Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(this.FullPath).Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));

        }
    }
}
