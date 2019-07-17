using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTreeView
{
    /// <summary>
    /// view model for application main directory view
    /// </summary>
    class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// a list of all directories on machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> items { get; set; }

        #endregion

        #region Constructor

        public DirectoryStructureViewModel()
        {
            this.items = new ObservableCollection<DirectoryItemViewModel>(
                DirectoryStructure.GetLogicalDrives().Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive))
                );
        }

        #endregion
    }
}
