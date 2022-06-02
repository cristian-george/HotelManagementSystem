namespace MVP_Hotel.Model
{
    public class User : BasePropertyChanged
    {
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

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
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
    }
}
