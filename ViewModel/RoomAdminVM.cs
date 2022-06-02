using MVP_Hotel.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP_Hotel.ViewModel
{
    public class RoomAdminVM : BasePropertyChanged
    {
        RoomBLL roomBLL = new RoomBLL();
        public RoomAdminVM()
        {
            RoomList = roomBLL.GetAllRooms();
        }

        #region Data Members

        public ObservableCollection<Room> RoomList
        {
            get => roomBLL.RoomList;
            set => roomBLL.RoomList = value;
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
                    addCommand = new RelayCommand<Room>(roomBLL.AddRoom);
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
                    updateCommand = new RelayCommand<Room>(roomBLL.ModifyRoom);
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
                    deleteCommand = new RelayCommand<Room>(roomBLL.DeleteRoom);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
