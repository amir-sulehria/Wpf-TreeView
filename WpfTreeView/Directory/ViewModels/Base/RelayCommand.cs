using System;
using System.Windows.Input;

namespace WpfTreeView
{

    /// <summary>
    /// A basic command that runs an action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members
        /// <summary>
        /// The action to run
        /// </summary>
        private Action mAction;
        #endregion

        #region Public Event

        /// <summary>
        /// the event that fires when CanExecute(object) value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion

        /// <summary>
        /// a relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        
        #region Constructor
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        #endregion

        #region Command Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the command action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
        #endregion
    }
}
