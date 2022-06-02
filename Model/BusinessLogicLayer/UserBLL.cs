using MVP_Hotel.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace MVP_Hotel.Model
{
    public class UserBLL
    {
        readonly UserDAL userDAL = new UserDAL();

        public static User CurrentUser;

        public ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public void FindUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                MessageBox.Show("Username and password can't be blank!");
                return;
            }
            if (userDAL.FindUser(user))
            {
                MessageBox.Show("Logged in successfully!");
                CurrentUser = userDAL.GetUserFromUsername(user.Username);
                if (CurrentUser.Type == "admin")
                {
                    var adminMenu = new AdminMenu();
                    adminMenu.ShowDialog();
                }
                else if (CurrentUser.Type == "worker")
                {
                    var workerMenu = new WorkerMenu();
                    workerMenu.ShowDialog();
                }
            }
            else MessageBox.Show("Log in failed!");
        }

        public void AddUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                MessageBox.Show("Username and password can't be blank!");
                return;
            }
            userDAL.AddUser(user);
        }
    }
}
