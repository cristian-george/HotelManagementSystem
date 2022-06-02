using System.Windows;

namespace MVP_Hotel.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UnregisteredWindow unregisteredWindow = new UnregisteredWindow();
            unregisteredWindow.ShowDialog();
        }
    }
}