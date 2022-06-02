using MVP_Hotel.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVP_Hotel.ViewModel
{
    public class UnregisteredWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        RoomBLL roomBLL = new RoomBLL();
        ImageBLL imageBLL = new ImageBLL();
        Dictionary<int, List<string>> roomImages = new Dictionary<int, List<string>>();

        private string currentImage;
        public string CurrentImage { get => currentImage; set => SetProperty(ref currentImage, value); }
        public UnregisteredWindowVM()
        {
            RoomList = roomBLL.GetAllRooms();
            ImageList = imageBLL.GetAllImages();
            CurrentImage = "D:\\Facultate\\ANUL 2\\Semestrul 2\\Medii vizuale de programare\\Laboratoare\\Lab12\\MVP_Hotel\\noImage.jpg";

            foreach (Room room in RoomList)
            {
                List<string> tmp = new List<string>();
                foreach (Image image in ImageList)
                {
                    if (image.Room_ID == room.Room_ID)
                        tmp.Add(image.Path);
                }
                roomImages.Add((int)room.Room_ID, tmp);
            }
        }

        #region Data Members

        public ObservableCollection<Room> RoomList
        {
            get => roomBLL.RoomList;
            set => roomBLL.RoomList = value;
        }

        public ObservableCollection<Image> ImageList
        {
            get => imageBLL.ImageList;
            set => imageBLL.ImageList = value;
        }

        #endregion

        #region Command Members

        private ICommand leftCommand;
        public ICommand LeftCommand
        {
            get
            {
                if (leftCommand == null)
                {
                    leftCommand = new RelayCommand<Room>(Left);
                }
                return leftCommand;
            }
        }

        private ICommand rightCommand;
        public ICommand RightCommand
        {
            get
            {
                if (rightCommand == null)
                {
                    rightCommand = new RelayCommand<Room>(Right);
                }
                return rightCommand;
            }
        }

        #endregion

        void Left(Room room)
        {
            if (room == null)
                return;
            if (!roomImages.ContainsKey((int)room.Room_ID))
                return;
            List<string> currentImagePool = roomImages[(int)room.Room_ID];
            if (currentImagePool.Count == 0)
            {
                CurrentImage = "C:\\Users\\primp\\source\\repos\\MVP_Hotel\\Images\\noImage.jpg";
                return;
            }

            bool found = false;
            int index = 0;
            for (int i = 0; i < currentImagePool.Count; ++i)
            {
                if (currentImagePool[i] == CurrentImage)
                {
                    found = true;
                    index = i;
                    break;
                }
            }
            if (!found)
                CurrentImage = currentImagePool[index];
            else
            {
                if (index + 1 >= currentImagePool.Count)
                    CurrentImage = currentImagePool[0];
                else CurrentImage = currentImagePool[index + 1];
            }
            OnPropertyChanged(CurrentImage);
        }

        void Right(Room room)
        {
            if (room == null)
                return;
            if (!roomImages.ContainsKey((int)room.Room_ID))
                return;
            List<string> currentImagePool = roomImages[(int)room.Room_ID];
            if (currentImagePool.Count == 0)
            {
                CurrentImage = "C:\\Users\\primp\\source\\repos\\MVP_Hotel\\Images\\noImage.jpg";
                return;
            }

            bool found = false;
            int index = 0;
            for (int i = 0; i < currentImagePool.Count; ++i)
            {
                if (currentImagePool[i] == CurrentImage)
                {
                    found = true;
                    index = i;
                    break;
                }
            }
            if (!found)
                CurrentImage = currentImagePool[index];
            else
            {
                if (index - 1 < 0)
                    CurrentImage = currentImagePool[currentImagePool.Count - 1];
                else CurrentImage = currentImagePool[index - 1];
            }
            OnPropertyChanged(CurrentImage);
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
