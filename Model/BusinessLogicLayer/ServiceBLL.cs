using System.Collections.ObjectModel;
using System.Windows;

namespace MVP_Hotel.Model
{
    public class ServiceBLL
    {
        public ObservableCollection<Service> ServiceList { get; set; }

        readonly ServiceDAL serviceDAL = new ServiceDAL();

        public ObservableCollection<Service> GetAllServices()
        {
            return serviceDAL.GetAllServices();
        }

        public void AddService(Service service)
        {
            if (service.Price <= 0)
            {
                MessageBox.Show("Price can't be empty, zero or less!");
                return;
            }
            serviceDAL.AddService(ref service);
            ServiceList.Add(service);
        }

        public void ModifyService(Service service)
        {
            if (service == null)
            {
                MessageBox.Show("Select a service first!");
                return;
            }
            if (service.Service_ID == 0 || string.IsNullOrEmpty(service.Name) || service.Price == 0)
            {
                MessageBox.Show("The fields can't be left blank!");
                return;
            }
            serviceDAL.ModifyService(service);
            MessageBox.Show("Successfully modified!");
        }

        public void DeleteService(Service service)
        {
            if (service == null)
            {
                MessageBox.Show("Select a service first!");
                return;
            }
            if (service.Service_ID == 0)
            {
                MessageBox.Show("The service ID can't be blank!");
                return;
            }
            serviceDAL.DeleteService(service);
            ServiceList.Remove(service);
            MessageBox.Show("Successfully deleted!");
        }
    }
}