using disaster_management.ViewModels;
using disaster_management.ViewModels.ChildViewModels;
using disaster_management.Views.SubWindows;
using System.Windows;
using System.Windows.Controls;

namespace disaster_management.Views.Usercontrols
{
    /// <summary>
    /// Interaction logic for DiseaseManagement.xaml
    /// </summary>
    public partial class DiseaseManagement : UserControl
    {
        public DiseaseManagement()
        {
            InitializeComponent();
          
        }

  

        private void Button_ChonLoaiDichBenh(object sender, RoutedEventArgs e)
        {
         //  SelectDisease selectDisease = new SelectDisease(DataContext as DiseaseViewModel);
          //  selectDisease.ShowDialog();
        }

        private void Button_ChonODichBenh(object sender, RoutedEventArgs e)
        {
          //  SelectOutbreak selectOutbreak = new SelectOutbreak(DataContext as DiseaseViewModel);
          //  selectOutbreak.ShowDialog();
        }

        private void TabItem_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           
        }
    }
}
