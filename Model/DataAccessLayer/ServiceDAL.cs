using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Hotel.Model
{
    public class ServiceDAL
    {
        public ObservableCollection<Service> GetAllServices()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllServices", connection);
                ObservableCollection<Service> result = new ObservableCollection<Service>();
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Service service = new Service();
                    service.Service_ID = (int)(reader[0]);//reader.GetInt(0);
                    service.Name = reader.GetString(1);//reader[1].ToString();
                    service.Price = (int)(reader[2]);
                    result.Add(service);
                }
                reader.Close();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddService(ref Service service)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddService", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID;

                SqlCommand cmd2 = new SqlCommand("GetMaxServiceID", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                reader.Read();
                int result;
                if (int.TryParse(reader[0].ToString(), out result))
                    result = 1 + (int)reader[0];
                else result = 1;
                paramID = new SqlParameter("@service_id", result);
                reader.Close();
                connection.Close();

                service.Service_ID = result;

                SqlParameter paramName;
                if (string.IsNullOrEmpty(service.Name))
                {
                    paramName = new SqlParameter("@name", "");
                    service.Name = "";
                }
                else paramName = new SqlParameter("@name", service.Name);

                SqlParameter paramPrice = new SqlParameter("@price", service.Price);

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramPrice);
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteService(Service service)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteService", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramServiceID = new SqlParameter("@service_id", service.Service_ID);
                cmd.Parameters.Add(paramServiceID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ModifyService(Service service)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyService", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramServiceID = new SqlParameter("@service_id", service.Service_ID);
                SqlParameter paramName = new SqlParameter("@name", service.Name);
                SqlParameter paramPrice = new SqlParameter("@price", service.Price);

                cmd.Parameters.Add(paramServiceID);
                cmd.Parameters.Add(paramName);
                cmd.Parameters.Add(paramPrice);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
