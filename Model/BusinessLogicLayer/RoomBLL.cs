using System.Collections.ObjectModel;
using System.Windows;

namespace MVP_Hotel.Model
{
    public class RoomBLL
    {
        public ObservableCollection<Room> RoomList { get; set; }

        readonly RoomDAL roomDAL = new RoomDAL();

        public ObservableCollection<Room> GetAllRooms()
        {
            return roomDAL.GetAllRooms();
        }

        public void AddRoom(Room room)
        {
            if (room.Price <= 0)
            {
                MessageBox.Show("Price can't be empty, zero or less!");
                return;
            }
            roomDAL.AddRoom(ref room);
            RoomList.Add(room);
        }

        public void ModifyRoom(Room room)
        {
            if (room == null)
            {
                MessageBox.Show("Select a room first!");
                return;
            }
            if (room.Room_ID == 0 || string.IsNullOrEmpty(room.Type) || room.Price == 0)
            {
                MessageBox.Show("The fields can't be left blank!");
                return;
            }
            roomDAL.ModifyRoom(room);
            MessageBox.Show("Successfully modified!");
        }

        public void DeleteRoom(Room room)
        {
            if (room == null)
            {
                MessageBox.Show("Select a room first!");
                return;
            }
            if (room.Room_ID == 0)
            {
                MessageBox.Show("The room ID can't be blank!");
                return;
            }
            roomDAL.DeleteRoom(room);
            RoomList.Remove(room);
            MessageBox.Show("Successfully deleted!");
        }
    }
}
