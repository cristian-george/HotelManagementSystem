using MVP_Hotel.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP_Hotel.ViewModel
{
    public class ImageAdminVM : BasePropertyChanged
    {
        ImageBLL imageBLL = new ImageBLL();
        public ImageAdminVM()
        {
            ImageList = imageBLL.GetAllImages();
        }

        #region Data Members

        public ObservableCollection<Image> ImageList
        {
            get => imageBLL.ImageList;
            set => imageBLL.ImageList = value;
        }

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Image>(imageBLL.AddImage);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Image>(imageBLL.ModifyImage);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Image>(imageBLL.DeleteImage);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
