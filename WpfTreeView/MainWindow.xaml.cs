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
            this.DataContext = new DirectoryStructureViewModel();
            //data context is the root of of the ui in terms of data binding
        }
        #endregion

        
    }
}
