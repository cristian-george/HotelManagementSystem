using System.Collections.ObjectModel;
using System.Windows;

namespace MVP_Hotel.Model
{
    public class ReservationBLL
    {
        public ObservableCollection<Reservation> ReservationList { get; set; }

        readonly ReservationDAL reservationDAL = new ReservationDAL();

        public ObservableCollection<Reservation> GetAllReservations()
        {
            return reservationDAL.GetAllReservations();
        }

        public void ModifyReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                MessageBox.Show("Select a reservation first!");
                return;
            }
            if (string.IsNullOrEmpty(reservation.Status))
            {
                MessageBox.Show("The status field can't be left blank!");
                return;
            }
            reservationDAL.ModifyReservation(reservation);
            MessageBox.Show("Successfully modified!");
        }
    }
}
