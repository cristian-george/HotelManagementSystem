namespace MVP_Hotel.Model
{
    public class Room : BasePropertyChanged
    {
        private int? room_ID;
        public int? Room_ID
        {
            get
            {
                return room_ID;
            }
            set
            {
                room_ID = value;
                NotifyPropertyChanged("Room_ID");
            }
        }

        private string reservation_ID;
        public string Reservation_ID
        {
            get
            {
                return reservation_ID;
            }
            set
            {
                reservation_ID = value;
                NotifyPropertyChanged("Reservation_ID");
            }
        }

        private int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                NotifyPropertyChanged("Price");
            }
        }

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        private bool is_deleted;
        public bool Is_Deleted
        {
            get
            {
                return is_deleted;
            }
            set
            {
                is_deleted = value;
                NotifyPropertyChanged("Is_Deleted");
            }
        }
    }
}
