using MVP_Hotel.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVP_Hotel.ViewModel
{
    public class ReservationWorkerVM : BasePropertyChanged
    {
        ReservationBLL reservationBLL = new ReservationBLL();
        public ReservationWorkerVM()
        {
            ReservationList = reservationBLL.GetAllReservations();
        }

        #region Data Members

        public ObservableCollection<Reservation> ReservationList
        {
            get => reservationBLL.ReservationList;
            set => reservationBLL.ReservationList = value;
        }

        #endregion

        #region Command Members

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Reservation>(reservationBLL.ModifyReservation);
                }
                return updateCommand;
            }
        }
        #endregion
    }
}
