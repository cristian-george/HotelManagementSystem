namespace MVP_Hotel.Model
{
    public class Reservation : BasePropertyChanged
    {
        private int? reservation_id;
        public int? Reservation_ID
        {
            get
            {
                return reservation_id;
            }
            set
            {
                reservation_id = value;
                NotifyPropertyChanged("Reservation_ID");
            }
        }

        private int? user_id;
        public int? User_ID
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
                NotifyPropertyChanged("User_ID");
            }
        }

        private string start_date;
        public string Start_Date
        {
            get
            {
                return start_date;
            }
            set
            {
                start_date = value;
                NotifyPropertyChanged("Start_Date");
            }
        }

        private string end_date;
        public string End_Date
        {
            get
            {
                return end_date;
            }
            set
            {
                end_date = value;
                NotifyPropertyChanged("End_Date");
            }
        }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }
    }
}
