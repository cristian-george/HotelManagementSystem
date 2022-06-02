using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVP_Hotel.Model
{
    public class ReservationDAL
    {
        public ObservableCollection<Reservation> GetAllReservations()
        {
            SqlConnection connection = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllReservations", connection);
                ObservableCollection<Reservation> result = new ObservableCollection<Reservation>();
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reservation = new Reservation();
                    reservation.Reservation_ID = (int)(reader[0]);//reader.GetInt(0);
                    reservation.User_ID = (int)(reader[1]);
                    reservation.Start_Date = reader.GetValue(2).ToString();//reader[1].ToString();
                    reservation.End_Date = reader.GetValue(3).ToString();
                    reservation.Status = reader.GetString(4);

                    if (reservation.User_ID != null && reservation.User_ID != 0)
                    {
                        SqlCommand cmd2 = new SqlCommand("GetUsernameFromUserID", connection);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramUserID = new SqlParameter("@user_id", reservation.User_ID);
                        cmd2.Parameters.Add(paramUserID);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        reservation.Username = reader2.GetString(0);
                    }
                    result.Add(reservation);
                }
                reader.Close();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }

        public void ModifyReservation(Reservation reservation)
        {
            using (SqlConnection connection = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyReservation", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramReservationID = new SqlParameter("@reservation_id", reservation.Reservation_ID);
                SqlParameter paramStatus = new SqlParameter("@status", reservation.Status);


                cmd.Parameters.Add(paramReservationID);
                cmd.Parameters.Add(paramStatus);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
