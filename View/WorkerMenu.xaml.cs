using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVP_Hotel.View
{
    /// <summary>
    /// Interaction logic for WorkerMenu.xaml
    /// </summary>
    public partial class WorkerMenu : Window
    {
        public WorkerMenu()
        {
            InitializeComponent();
        }

        private void ViewRoomsClick(object sender, RoutedEventArgs e)
        {
            UnregisteredWindow unregisteredWindow = new UnregisteredWindow();
            unregisteredWindow.Show();
            //do something
        }

        private void EditServicesClick(object sender, RoutedEventArgs e)
        {
            ReservationWorker reservationWorker = new ReservationWorker();
            reservationWorker.Show();
            //do something
        }
    }
}
