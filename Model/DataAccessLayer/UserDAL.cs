using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Hotel.Model
{
    public class UserDAL
    {
        public ObservableCollection<User> GetAllUsers()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", connection);
                ObservableCollection<User> result = new ObservableCollection<User>();
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.User_ID = (int)(reader[0]);//reader.GetInt(0);
                    user.Username = reader.GetString(1);//reader[1].ToString();
                    user.Password = reader.GetString(2);
                    //p.Address = reader.IsDBNull(2) ? null : reader[2].ToString();
                    result.Add(user);
                }
                reader.Close();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool FindUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("FindUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", user.Username);
                SqlParameter paramPassword = new SqlParameter("@password", user.Password);
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int result = 0;
                reader.Read();
                result = (int)reader[0];
                reader.Close();
                cmd.ExecuteNonQuery();
                if (result == 1)
                    return true;
                return false;
            }
        }

        public User GetUserFromUsername(string username)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetUserFromUsername", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", username);
                cmd.Parameters.Add(paramUsername);
                connection.Open();

                User user = new User();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                user.User_ID = (int)reader[0];
                user.Username = reader[1].ToString();
                user.Password = reader[2].ToString();
                user.Type = reader[3].ToString();

                reader.Close();
                cmd.ExecuteNonQuery();

                return user;
            }
        }

        public void AddUser(User user)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", user.Username);
                SqlParameter paramPassword = new SqlParameter("@password", user.Password);
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
