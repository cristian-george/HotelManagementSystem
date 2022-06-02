using Microsoft.Win32;
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
    /// Interaction logic for ImageAdmin.xaml
    /// </summary>
    public partial class ImageAdmin : Window
    {
        public ImageAdmin()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*png;*.jpg;*.jpeg;*.gif;*.bmp)|*png;*.jpg;*.jpeg;*gif;*.bmp;";

            if (openFileDialog.ShowDialog() == true)
            {
                txtPath.Text = openFileDialog.FileName;
            }

        }
    }
}
