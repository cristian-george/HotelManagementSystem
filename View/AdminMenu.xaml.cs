using MVP_Hotel.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVP_Hotel.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void EditRoomsClick(object sender, RoutedEventArgs e)
        {
            RoomAdmin roomAdmin = new RoomAdmin();
            roomAdmin.Show();
            //do something
        }

        private void EditServicesClick(object sender, RoutedEventArgs e)
        {
            ServiceAdmin serviceAdmin = new ServiceAdmin();
            serviceAdmin.Show();
            //do something
        }

        private void EditImagesClick(object sender, RoutedEventArgs e)
        {
            ImageAdmin imageAdmin = new ImageAdmin();
            imageAdmin.Show();
            //do something
        }
    }
}
