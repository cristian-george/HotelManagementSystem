using System.Collections.ObjectModel;
using System.Windows;

namespace MVP_Hotel.Model
{
    public class ImageBLL
    {
        public ObservableCollection<Image> ImageList { get; set; }

        readonly ImageDAL imageDAL = new ImageDAL();

        public ObservableCollection<Image> GetAllImages()
        {
            return imageDAL.GetAllImages();
        }

        public void AddImage(Image image)
        {
            if (image.Room_ID <= 0)
            {
                MessageBox.Show("Room ID can't be empty, zero or less!");
                return;
            }
            if (string.IsNullOrEmpty(image.Path))
            {
                MessageBox.Show("Path can't be empty!");
                return;
            }
            imageDAL.AddImage(ref image);
            ImageList.Add(image);
        }

        public void ModifyImage(Image image)
        {
            if (image == null)
            {
                MessageBox.Show("Select an image first!");
                return;
            }
            if (image.Room_ID == 0 || string.IsNullOrEmpty(image.Path))
            {
                MessageBox.Show("The fields can't be left blank!");
                return;
            }
            imageDAL.ModifyImage(image);
            MessageBox.Show("Successfully modified!");
        }

        public void DeleteImage(Image image)
        {
            if (image == null)
            {
                MessageBox.Show("Select an image first!");
                return;
            }
            imageDAL.DeleteImage(image);
            ImageList.Remove(image);
            MessageBox.Show("Successfully deleted!");
        }
    }
}
