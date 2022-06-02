namespace MVP_Hotel.Model
{
    public class Service : BasePropertyChanged
    {
        private int? service_id;
        public int? Service_ID
        {
            get
            {
                return service_id;
            }
            set
            {
                service_id = value;
                NotifyPropertyChanged("Service_ID");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
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
    }
}
