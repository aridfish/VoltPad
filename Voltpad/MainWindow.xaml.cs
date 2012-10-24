using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace Voltpad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Workspace = Voltpad.Properties.Settings.Default.Workspace;
        public MainWindow()
        {
            StyleManager.ApplicationTheme = new VistaTheme();
            InitializeComponent();
        }

        private void DragStart(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Maximise(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void Minimise(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MenuDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void CreateDirectoryItems()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Workspace);
            RadTreeViewItem TreeParent = new RadTreeViewItem();
            foreach (var directory in directoryInfo.GetDirectories())
            {
                TreeParent.Header = directoryInfo.Name;
                ProjectDir.Items.Remove(TreeParent);
                ProjectDir.Items.Add(TreeParent);
                foreach (var file in directoryInfo.GetFiles())
                {
                    RadTreeViewItem TreeChild = new RadTreeViewItem();
                    TreeChild.Header = directoryInfo.FullName;
                    TreeParent.Items.Add(TreeChild);
                }
            }
        }

        private void PopulateTree(object sender, EventArgs e)
        {
            CreateDirectoryItems();
        }
    }
}
