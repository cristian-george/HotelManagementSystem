using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Hotel.Model
{
    public class RoomDAL
    {
        public ObservableCollection<Room> GetAllRooms()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllRooms", connection);
                ObservableCollection<Room> result = new ObservableCollection<Room>();
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Room p = new Room();
                    p.Room_ID = (int)(reader[0]);//reader.GetInt(0);
                    p.Type = reader.GetString(2);//reader[1].ToString();
                    p.Price = (int)(reader[3]);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddRoom(ref Room room)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddRoom", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID;
                if (room.Room_ID == 0)
                {
                    SqlCommand cmd2 = new SqlCommand("GetMaxRoomID", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd2.ExecuteReader();
                    reader.Read();
                    int result = 1 + (int)reader[0];
                    paramID = new SqlParameter("@room_id", result);
                    reader.Close();
                    connection.Close();

                    room.Room_ID = result;
                }
                else paramID = new SqlParameter("@room_id", room.Room_ID);

                SqlParameter paramType;
                if (string.IsNullOrEmpty(room.Type))
                {
                    paramType = new SqlParameter("@type", "Type_A");
                    room.Type = "Type_A";
                }
                else paramType = new SqlParameter("@type", room.Type);

                SqlParameter paramPrice = new SqlParameter("@price", room.Price);

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramType);
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
                //room.Room_ID = paramIdPersoana.Value as int?;
            }
        }

        public void DeleteRoom(Room room)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteRoom", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramRoomID = new SqlParameter("@room_id", room.Room_ID);
                cmd.Parameters.Add(paramRoomID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ModifyRoom(Room room)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyRoom", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramRoomID = new SqlParameter("@room_id", room.Room_ID);
                SqlParameter paramType = new SqlParameter("@type", room.Type);
                SqlParameter paramPrice = new SqlParameter("@price", room.Price);
                
                cmd.Parameters.Add(paramRoomID);
                cmd.Parameters.Add(paramType);
                cmd.Parameters.Add(paramPrice);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
