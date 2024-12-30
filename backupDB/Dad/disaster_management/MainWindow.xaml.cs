using disaster_management.ViewModels;
using MahApps.Metro.Controls;
using Microsoft.Extensions.DependencyInjection;
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

namespace disaster_management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
         
            DataContext = viewModel; // Gán ViewModel làm DataContext cho View
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var ViewModels = DataContext as MainViewModel;
                await ViewModels?.UserViewModel.LoadCurrentUserCommand.ExecuteAsync(null);
            }
            catch (Exception)
            {
            }
          
        }

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
          var res =   MessageBox.Show("Thoát ứng dụng", "Thoát", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if(res == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
    }
}