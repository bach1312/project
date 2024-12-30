using disaster_management.ViewModels.ChildViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace disaster_management.Views.SubWindows
{
    /// <summary>
    /// Interaction logic for SelectOutbreak.xaml
    /// </summary>
    public partial class SelectOutbreak : MetroWindow
    {
        public SelectOutbreak()
        {
            InitializeComponent();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
