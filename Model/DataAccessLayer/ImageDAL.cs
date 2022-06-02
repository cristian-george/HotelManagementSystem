using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Hotel.Model
{
    public class ImageDAL
    {
        public ObservableCollection<Image> GetAllImages()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllImages", connection);
                ObservableCollection<Image> result = new ObservableCollection<Image>();
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Image image = new Image();
                    image.Image_ID = (int)(reader[0]);//reader.GetInt(0);
                    image.Room_ID = (int)(reader[1]);
                    image.Path = reader.GetString(2);//reader[1].ToString();
                    result.Add(image);
                }
                reader.Close();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddImage(ref Image image)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddImage", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramImageID;

                SqlCommand cmd2 = new SqlCommand("GetMaxImageID", connection);
                cmd2.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                reader.Read();
                int result;
                if (int.TryParse(reader[0].ToString(), out result))
                    result = 1 + (int)reader[0];
                else result = 1;
                paramImageID = new SqlParameter("@image_id", result);
                reader.Close();
                connection.Close();

                image.Image_ID = result;

                SqlParameter paramRoomID = new SqlParameter("@room_id", image.Room_ID);
                SqlParameter paramPath = new SqlParameter("@path", image.Path);

                cmd.Parameters.Add(paramImageID);
                cmd.Parameters.Add(paramRoomID);
                cmd.Parameters.Add(paramPath);

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

        public void DeleteImage(Image image)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteImage", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramImageID = new SqlParameter("@image_id", image.Image_ID);
                cmd.Parameters.Add(paramImageID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ModifyImage(Image image)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyImage", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramImageID = new SqlParameter("@image_id", image.Image_ID);
                SqlParameter paramRoomID = new SqlParameter("@room_id", image.Room_ID);
                SqlParameter paramPath = new SqlParameter("@path", image.Path);

                cmd.Parameters.Add(paramImageID);
                cmd.Parameters.Add(paramRoomID);
                cmd.Parameters.Add(paramPath);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
