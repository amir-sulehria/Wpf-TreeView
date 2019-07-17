using PropertyChanged;
using System.ComponentModel;

namespace WpfTreeView
{
    /// <summary>
    /// A base view model that fires property changed events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// the event that's fired when any child property changes its value
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};

        #region Without Extension
        //instead of writing code below u can simply write get; set; but for this u have to install fody property change extension
        //after installing u can simply use [AddINotifyPropertyChangedInterface] before class declaration, it will find all public properties
        //and smartly detect Test(property) as changing in it causes a lot of changing in other properties and then it inject property 
        //inject
        //private string mTest;
        //public string Test
        //{
        //    get
        //    {
        //        return mTest;
        //    }
        //    set
        //    {
        //        if (mTest == value)
        //            return;

        //        mTest = value;
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
        //    }
        //}
        #endregion
    }
}
