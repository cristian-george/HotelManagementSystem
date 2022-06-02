using MVP_Hotel.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP_Hotel.ViewModel
{
    public class ServiceAdminVM : BasePropertyChanged
    {
        ServiceBLL serviceBLL = new ServiceBLL();
        public ServiceAdminVM()
        {
            ServiceList = serviceBLL.GetAllServices();
        }

        #region Data Members

        public ObservableCollection<Service> ServiceList
        {
            get => serviceBLL.ServiceList;
            set => serviceBLL.ServiceList = value;
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
                    addCommand = new RelayCommand<Service>(serviceBLL.AddService);
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
                    updateCommand = new RelayCommand<Service>(serviceBLL.ModifyService);
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
                    deleteCommand = new RelayCommand<Service>(serviceBLL.DeleteService);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
