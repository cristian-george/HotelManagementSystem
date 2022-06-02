using MVP_Hotel.Model;
using System.Windows.Input;

namespace MVP_Hotel.ViewModel
{
    public class MainWindowVM : BasePropertyChanged
    {
        readonly UserBLL userBLL = new UserBLL();

        private ICommand logInCommand;
        private ICommand registerCommand;

        public ICommand LogInCommand
        {
            get
            {
                if (logInCommand == null)
                {
                    logInCommand = new RelayCommand<User>(userBLL.FindUser);
                }
                return logInCommand;
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                if (registerCommand == null)
                {
                    registerCommand = new RelayCommand<User>(userBLL.AddUser);
                }
                return registerCommand;
            }
        }
    }
}